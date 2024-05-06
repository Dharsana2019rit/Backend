import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import Cookies from 'js-cookie';
import './Login.css';
import Navbar from './Navbar';

const Logincomp = () => {
  const [emailId, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [role, setRole] = useState('User');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    // Check if the user is already authenticated
    const token = Cookies.get('token');
    if (token) {
      authenticateToken(token);
    }
  }, []);

  const handleLogin = async () => {
    try {
      const response = await axios.post(`https://localhost:44384/api/auth/login/${role}`, { emailId, password, role });
      const { token } = response.data;
      // Store token in cookie
      Cookies.set('token', token);
      Cookies.set("email",emailId);

      // Authenticate token
      authenticateToken(token);
    } catch (error) {
      setError('Failed to log in. Please check your credentials.');
    }
  };

  const authenticateToken = async (token) => {
    try {
      const response = await axios.get('https://localhost:44384/api/auth/authenticate', {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
      // If authentication succeeds, redirect to the appropriate dashboard
      if (response.status === 200) {
        const { token } = response.data;
        if (role === 'Admin') {
          navigate('/admindashboard');
        } else {
          navigate('/homepage');
        }
      } else {
        setError('Authentication failed. Please try logging in again.');
      }
    } catch (error) {
      setError('Failed to authenticate. Please try again later.');
    }
  };

  const handleSignup = () => {
    navigate('/');
  };

  return (
    <div className="background-image-container">
      <Navbar/>
      <div className="login-container">
        <h2>Login</h2>
        <input type="text" placeholder="Email" value={emailId} onChange={(e) => setEmail(e.target.value)} />
        <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} />
        <select className='login-select' value={role} onChange={(e) => setRole(e.target.value)}>
          <option value="User">User</option>
          <option value="Admin">Admin</option>
        </select>
        <button onClick={handleLogin}>Login</button>
        <div>New user? Sign up here!</div>
        <button onClick={handleSignup}>Sign Up</button>
        {error && <div className="error-message">{error}</div>}
      </div>
    </div>
  );
};

export default Logincomp;
