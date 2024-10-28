using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Proj_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModesController : ControllerBase
    {
        private readonly IModeService _modeService;

        public ModesController(IModeService modeService)
        {
            _modeService = modeService;
        }

        // GET: api/Modes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mode>>> GetModes()
        {
            var modes = await _modeService.GetModes();
            return Ok(modes);
        }

        // GET: api/Modes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mode>> GetMode(int id)
        {
            var mode = await _modeService.GetMode(id);
            if (mode == null)
            {
                return NotFound();
            }
            return mode;
        }

        // PUT: api/Modes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMode(int id, Mode mode)
        {
            if (id != mode.ModeId)
            {
                return BadRequest();
            }

            var result = await _modeService.UpdateMode(id, mode);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Modes
        [HttpPost]
        public async Task<ActionResult<Mode>> PostMode(Mode mode)
        {
            var createdMode = await _modeService.CreateMode(mode);
            return CreatedAtAction("GetMode", new { id = createdMode.ModeId }, createdMode);
        }

        // DELETE: api/Modes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMode(int id)
        {
            var result = await _modeService.DeleteMode(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
