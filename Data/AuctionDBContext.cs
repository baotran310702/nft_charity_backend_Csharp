using Microsoft.EntityFrameworkCore;
using nft_project.Models;

namespace nft_project.Data
{
    public class AuctionDBContext : DbContext
    {
        public AuctionDBContext(DbContextOptions<AuctionDBContext> options) : base(options)
        {

        }

        public DbSet<Auction> Auction
        {
            get; set;
        }

        public DbSet<Campaign> Campaign { get; set; }
 
    }
}
