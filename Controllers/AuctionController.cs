using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using nft_project.Data;
using nft_project.Models;


namespace nft_project.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        public readonly AuctionDBContext _context;
        public AuctionController(AuctionDBContext context)
        {
            _context = context;
        }

        [HttpGet("auction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Auction>> Get()
        {
            var list_result =  await _context.Auction.ToListAsync();            

            return list_result;
        }

        [HttpGet("auction/id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var camp = await _context.Auction.FindAsync(id);
            return camp == null ? NotFound() : Ok(camp);
        }

        [HttpPost("auction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Auction auction)
        {
            await _context.AddAsync(auction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = auction.nft_id }, auction);
        }


    }
}
