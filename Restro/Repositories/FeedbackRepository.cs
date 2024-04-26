using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Data;
using Restro.Models;
using Microsoft.EntityFrameworkCore;

namespace Restro.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly RestroDbContext _context;

        public FeedbackRepository(RestroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync() => await _context.Feedbacks.ToListAsync();

        public async Task<Feedback> GetFeedbackByIdAsync(int id) => await _context.Feedbacks.FindAsync(id);

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task UpdateFeedbackAsync(Feedback feedback)
        {
            _context.Entry(feedback).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedbackAsync(Feedback feedback)
        {
            _context.Feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();
        }
    }
}

