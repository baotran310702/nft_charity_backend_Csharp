using Microsoft.EntityFrameworkCore;
using nft_project.Models;


namespace nft_project.Data
{
    public class CampaignDBContext:DbContext
    {
        public CampaignDBContext(DbContextOptions<CampaignDBContext> options) : base(options)
        {

        }

        public DbSet<Campaign> Campaign { get; set; }
    }
}
