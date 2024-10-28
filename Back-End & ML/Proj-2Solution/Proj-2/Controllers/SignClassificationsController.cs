using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Proj_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignClassificationsController : ControllerBase
    {
        private readonly ISignClassificationService _signClassificationService;

        public SignClassificationsController(ISignClassificationService signClassificationService)
        {
            _signClassificationService = signClassificationService;
        }

        // GET: api/SignClassifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignClassification>>> GetSignClassifications()
        {
            var result = await _signClassificationService.GetSignClassificationsAsync();
            return Ok(result);
        }

        // GET: api/SignClassifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignClassification>> GetSignClassification(int id)
        {
            var result = await _signClassificationService.GetSignClassificationAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // PUT: api/SignClassifications/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSignClassification(int id, SignClassification signClassification)
        {
            var result = await _signClassificationService.UpdateSignClassificationAsync(id, signClassification);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // POST: api/SignClassifications
        [HttpPost]
        public async Task<ActionResult<SignClassification>> PostSignClassification(SignClassification signClassification)
        {
            var result = await _signClassificationService.AddSignClassificationAsync(signClassification);
            return CreatedAtAction("GetSignClassification", new { id = signClassification.Id }, result);
        }

        // DELETE: api/SignClassifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignClassification(int id)
        {
            var result = await _signClassificationService.DeleteSignClassificationAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
