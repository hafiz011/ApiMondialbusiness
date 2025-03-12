using WebApp.Models.DatabaseModels;

namespace WebApp.Services.Interface
{
    public interface IInfoRepository
    {
        Task<ContactModel> GetContactByIdAsync(string id);
        //Task CreateContactAsync(ContactModel contact);
        Task UpdateContactAsync(string id, ContactModel contact);
        Task UpdateAboutAsync(string id, AboutModel model);
        Task<AboutModel> GetAboutByIdAsync(string id);
    }
}
