using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
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

        //[HttpGet("auctionAll")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IEnumerable<Auction>> Get()
        //{
        //    var list_result =  await _context.Auction.ToListAsync();            

        //    return list_result;
        //}

        [HttpGet("auctionAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Object> GetAuctionInfor()
        {
            var auctionInfor = from a in _context.Auction
                               join c in _context.Campaign
                               on a.camp_id equals c.id
                               select new
                               {
                                   id = a.camp_id,
                                   nft_id = a.nft_id,
                                   camp_id = a.camp_id,
                                   status = a.status,
                                   endAt = a.endAt,
                                   title = c.title,
                                   description = c.description,
                                   img1_url = c.img1_url,
                                   img2_url =c.img2_url,
                                   zone = c.zone,
                               };
            return auctionInfor;
        }


        [HttpGet("auction/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Object> GetAuctionInfor(int id)
        {
            var auctionInfor = from a in _context.Auction
                               join c in _context.Campaign
                               on a.camp_id equals c.id
                               where a.nft_id == id
                               select new
                               {
                                   id = a.camp_id,
                                   nft_id = a.nft_id,
                                   camp_id = a.camp_id,
                                   title = c.title,
                                   description = c.description,
                                   img1_url = c.img1_url,
                                   img2_url = c.img2_url,
                                   zone = c.zone,
                               };
            return auctionInfor;
        }

        [HttpPost("auction")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Auction auction)
        {
            await _context.AddAsync(auction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuctionInfor), new { id = auction.nft_id }, auction);
        }

        [HttpPut("auction")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id)
        {

            var auctionData = from a in _context.Auction
                              where a.nft_id == id
                              select new
                              {
                                  nft_id = a.nft_id,
                                  camp_id = a.camp_id,
                                  status = "Done",
                                  createAt = a.createAt

                               };
            Auction auction = new Auction();

            foreach (var data in auctionData)
            {
                auction.nft_id = data.nft_id;
                auction.camp_id = data.camp_id;
                auction.status = "Done";
                auction.createAt = data.createAt;
            }

            _context.Entry(auction).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
