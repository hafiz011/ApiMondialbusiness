using WebApp.Models.DatabaseModels;

namespace WebApp.Services.Interface
{
    public interface ISubmmitdata
    {
        Task AddDataAsync(FormData formData);
        Task<List<FormData>> GetAll();
        Task<FormData> GetById(Guid id);
    }
}
