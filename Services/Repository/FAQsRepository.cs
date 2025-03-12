using WebApp.Models.DatabaseModels;
using WebApp.Services.Interface;
using MongoDB.Driver;
using WebApp.DbContext;
namespace WebApp.Services.Repository
{
    public class FAQsRepository : IFAQsRepository
    {
        private readonly MongoDbContext _context;

        public FAQsRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FAQsModel faq)
        {
            await _context.FAQs.InsertOneAsync(faq);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.FAQs.DeleteOneAsync(id);
        }

        public async Task<IEnumerable<FAQsModel>> GetAllAsync()
        {
            return await _context.FAQs.Find(_ => true).ToListAsync();
        }

        public async Task<FAQsModel> GetByIdAsync(string id)
        {
            return await _context.FAQs.Find(f => f.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(string id, FAQsModel faq)
        {
            await _context.FAQs.ReplaceOneAsync(f => f.Id == id, faq);
        }
    }
}
