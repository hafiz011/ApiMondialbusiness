using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _submmitdata.GetAll();
            return Ok(data);
        }

        // ------------------ READ BY ID ------------------
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if(id == null) return BadRequest("ID is null.");
            var data = await _submmitdata.GetById(id);
            if (data == null) return NotFound("Form data not found.");
            return Ok(data);
        }



        // ------------------ DELETE ------------------
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(Guid id)
        {
            if(id == null) return BadRequest("ID is null.");
            var result = await _submmitdata.DeleteById(id);
            return NoContent();
        }
    }
}
