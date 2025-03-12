
using WebApp.Models.DatabaseModels;

namespace WebApp.Services.Interface
{
    public interface IFAQsRepository
    {
        Task<IEnumerable<FAQsModel>> GetAllAsync();
        Task<FAQsModel> GetByIdAsync(string id);
        Task AddAsync(FAQsModel faq);
        Task UpdateAsync(string id, FAQsModel faq);
        Task DeleteAsync(string id);
    }
}
