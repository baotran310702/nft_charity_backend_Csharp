using nft_project.Data;
using nft_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace nft_project.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TransController : ControllerBase
    {
        public readonly TransDBContext _context;
        public TransController(TransDBContext context)
        {
            _context = context;
        }

        [HttpGet("trans")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IEnumerable<Trans>> Get()
        {
            var list_result = await _context.Trans.ToListAsync();

            return list_result;
        }

        [HttpGet("trans/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _context.Trans.FindAsync(id);
            return result == null ? NotFound() : Ok(result) ;
        }

        [HttpPost("trans")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Trans trans)
        {
            await _context.Trans.AddAsync(trans);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = trans.trans_id, trans });
        }

        [HttpPut("trans")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string trans_id, Trans trans)
        {
            if (trans_id != trans.trans_id) return BadRequest();

            _context.Entry(trans).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
