using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Interface;
using WebApp.Services.Repository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IInfoRepository _infoRepository;
        private readonly IFAQsRepository _faqRepository;

        public HomeController(IInfoRepository infoRepository,
            IFAQsRepository faqRepository)
        {
            _infoRepository = infoRepository;
            _faqRepository = faqRepository;
        }







        // Get: api/home/contact
        [HttpGet("about")]
        public async Task<IActionResult> About()
        {
            string id = "7b4a446c-0ddf-4538-8d19-7a7bd9e6d0f8";
            var about = await _infoRepository.GetAboutByIdAsync(id);
            if (about == null)
            {
                return NotFound(new { Message = "About info not found." });
            }
            return Ok(about);
        }

        // Get: api/home/contact
        [HttpGet("contact")]
        public async Task<IActionResult> Contact()
        {
            string id = "cb7a4b9e-d238-456e-882b-734fc21db4f0";
            var info = await _infoRepository.GetContactByIdAsync(id);
            if (info == null)
            {
                return NotFound(new { Message = "Contact info not found." });
            }
            return Ok(info);
        }

        [HttpGet("FAQ-List")]
        public async Task<IActionResult> FAQsList()
        {
            var faqs = await _faqRepository.GetAllAsync();
            if (faqs == null || !faqs.Any())
            {
                return NotFound(new { Message = "No FAQs found." });
            }
            return Ok(faqs);
        }

    }
}
