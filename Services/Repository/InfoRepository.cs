using WebApp.Models.DatabaseModels;
using WebApp.Services.Interface;
using MongoDB.Driver;
using WebApp.DbContext;

namespace WebApp.Services.Repository
{
    public class InfoRepository : IInfoRepository
    {
        private readonly MongoDbContext _context;

        public InfoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<ContactModel> GetContactByIdAsync(string id)
        {
            return await _context.Contacts.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateContactAsync(ContactModel contact)
        {
            await _context.Contacts.InsertOneAsync(contact);
        }

        public async Task UpdateContactAsync(string id, ContactModel contact)
        {
            await _context.Contacts.ReplaceOneAsync(c => c.Id == id, contact);
        }

        public async Task UpdateAboutAsync(string id, AboutModel model)
        {
            await _context.About.ReplaceOneAsync(c => c.Id == id, model);
        }

        public async Task<AboutModel> GetAboutByIdAsync(string id)
        {
            return await _context.About.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
