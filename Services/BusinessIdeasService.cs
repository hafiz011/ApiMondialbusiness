using WebApp.Models.DatabaseModels;
using WebApp.Services.Interface;
using WebApp.Services.Repository;

namespace WebApp.Services
{
    public class BusinessIdeasService : IBusinessIdeasService
    {
        private readonly BusinessIdeasRepository _repo;

        public BusinessIdeasService(BusinessIdeasRepository repo)
        {
            _repo = repo;
        }

        public async Task<BusinessIdeas> CreateIdeaAsync(BusinessIdeas idea)
        {
            await _repo.AddAsync(idea);
            return idea;
        }

        public async Task DeleteIdeaAsync(string id)
        {
            await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<BusinessIdeas>> GetAllIdeasAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<BusinessIdeas> GetByIdAsync(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BusinessIdeas>> GetByCreatorAsync(string creatorId)
        {
            return await _repo.GetByCreatorIdAsync(creatorId);
        }

        public async Task<IEnumerable<BusinessIdeas>> GetPendingIdeasAsync()
        {
            return await _repo.GetPendingIdeasAsync();
        }

        public async Task<BusinessIdeas> UpdateIdeaAsync(string id, BusinessIdeas idea)
        {
            await _repo.UpdatePartialAsync(id, idea);
            return idea;
        }


    }
}
