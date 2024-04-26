using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Models;
using Restro.Repositories;
using Restro.Services;

namespace Restro.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync() => await _feedbackRepository.GetAllFeedbacksAsync();

        public async Task<Feedback> GetFeedbackByIdAsync(int id) => await _feedbackRepository.GetFeedbackByIdAsync(id);

        public async Task<Feedback> CreateFeedbackAsync(Feedback feedback) => await _feedbackRepository.CreateFeedbackAsync(feedback);

        public async Task UpdateFeedbackAsync(Feedback feedback) => await _feedbackRepository.UpdateFeedbackAsync(feedback);

        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await _feedbackRepository.GetFeedbackByIdAsync(id);
            if (feedback != null)
            {
                await _feedbackRepository.DeleteFeedbackAsync(feedback);
            }
        }
    }
}

