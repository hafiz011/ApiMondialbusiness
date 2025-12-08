using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApp.DbContext;
using WebApp.Models.DatabaseModels;
using WebApp.Services.Interface;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormdataController : ControllerBase
    {
        private readonly ISubmmitdata _submmitdata;
        public FormdataController(ISubmmitdata submmitdata)
        {
            _submmitdata = submmitdata;
        }


        // ------------------ CREATE ------------------
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitForm(FormData formData)
        {
            if (formData == null) return BadRequest("Form data is null.");

            formData.Id = Guid.NewGuid();
            await _submmitdata.AddDataAsync(formData);

            return Ok(new { message = "Form data submitted successfully." });
        }

        // ------------------ READ ALL ------------------
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _submmitdata.GetAll();
            return Ok(data);
        }

        // ------------------ READ BY ID ------------------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if(id == null) return BadRequest("ID is null.");
            var data = await _submmitdata.GetById(id);
            if (data == null) return NotFound("Form data not found.");
            return Ok(data);
        }

      

        //// ------------------ DELETE ------------------
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteForm(Guid id)
        //{
        //    var result = await Collection.DeleteOneAsync(f => f.Id == id);
        //    if (result.DeletedCount == 0) return NotFound("Form data not found.");

        //    return Ok(new { message = "Form data deleted successfully." });
        //}
    }
}
