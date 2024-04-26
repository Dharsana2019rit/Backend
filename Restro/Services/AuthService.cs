﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Restro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Restro.Models;
using Restro.Services;

namespace Restro.Services
{

    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly RestroDbContext _context; // Your Entity Framework database context

        public AuthService(IConfiguration config, RestroDbContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task<string> RegisterAdmin(Login admin)
        {
            // Check if any admin already exists
            var existingAdmin = await _context.Logins.FirstOrDefaultAsync(u => u.Role == "Admin");
            if (existingAdmin != null)
            {
                throw new Exception("An admin is already registered");
            }

            // Check if the provided email is already associated with an admin
            var existingAdminWithEmail = await _context.Logins.FirstOrDefaultAsync(u => u.Role == "Admin" && u.EmailId == admin.EmailId);
            if (existingAdminWithEmail != null)
            {
                throw new Exception("Email address is already associated with an admin");
            }

            // Create new admin
            admin.Role = "Admin";
            _context.Logins.Add(admin);
            await _context.SaveChangesAsync();

            // Generate and return JWT token
            return GenerateJwtToken(admin);
        }


        public async Task<string> RegisterUser(Login user)
        {
            // Check if the user already exists
            var existingUser = await _context.Logins.SingleOrDefaultAsync(u => u.EmailId == user.EmailId);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            // Check if the email is associated with an admin
            var adminWithEmail = await _context.Logins.FirstOrDefaultAsync(u => u.EmailId == user.EmailId && u.Role == "Admin");
            if (adminWithEmail != null)
            {
                throw new Exception("Email address is associated with an admin and cannot be registered as a user");
            }

            // Create new user
            user.Role = "User";
            _context.Logins.Add(user);
            await _context.SaveChangesAsync();

            // Generate and return JWT token
            return GenerateJwtToken(user);
        }



        public async Task<string> AdminLogin(Login admin)
        {
            // Check if the admin exists and password matches
            var existingAdmin = await _context.Logins.SingleOrDefaultAsync(u => u.EmailId == admin.EmailId && u.Password == admin.Password);
            if (existingAdmin == null || existingAdmin.Role != "Admin")
            {
                throw new Exception("Invalid email or password");
            }

            // Generate and return JWT token
            return GenerateJwtToken(existingAdmin);
        }

        public async Task<string> UserLogin(Login user)
        {
            // Check if the user exists and password matches
            var existingUser = await _context.Logins.SingleOrDefaultAsync(u => u.EmailId == user.EmailId && u.Password == user.Password);
            if (existingUser == null || existingUser.Role != "User")
            {
                throw new Exception("Invalid email or password");
            }

            // Generate and return JWT token
            return GenerateJwtToken(existingUser);
        }

        public async Task<string?> AuthenticateAsync(HttpContext httpContext, string? cookieToken = null)
        {
            try
            {
                // Check if the user is authenticated
                if (httpContext.User.Identity?.IsAuthenticated ?? false)
                {
                    // You may retrieve the authenticated user's email from the claims
                    var userEmail = httpContext.User.FindFirst(ClaimTypes.Email)?.Value;

                    // Retrieve the user from the database based on the email
                    var user = await _context.Logins.SingleOrDefaultAsync(u => u.EmailId == userEmail);

                    if (user != null)
                    {
                        // Generate and return JWT token for the authenticated user
                        return GenerateJwtToken(user);
                    }
                    else
                    {
                        // If the user is not found in the database, authentication fails
                        return null;
                    }
                }
                else
                {
                    // If the user is not authenticated, authentication fails
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during authentication
                // For example, log the exception
                Console.WriteLine($"Authentication failed: {ex.Message}");
                return null;
            }
        }

        private string GenerateJwtToken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.EmailId),
                new Claim(ClaimTypes.Role, user.Role), // Add role claim
                // Add additional claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}