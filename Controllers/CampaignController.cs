using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using nft_project.Data;
using nft_project.Models;


namespace nft_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        public readonly CampaignDBContext _context;
        public CampaignController(CampaignDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Campaign>> Get()
        {
            var list_result =  await _context.Campaign.ToListAsync();            

            return list_result;
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var camp = await _context.Campaign.FindAsync(id);
            return camp == null ? NotFound() : Ok(camp);            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> Create(Campaign campaign)
        {
            await _context.AddAsync(campaign);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = campaign.id}, campaign);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id,Campaign campaign)
        {
            if (id != campaign.id) return BadRequest();

            _context.Entry(campaign).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
