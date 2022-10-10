using Microsoft.EntityFrameworkCore;
using nft_project.Models;

namespace nft_project.Data
{
    public class TransDBContext :DbContext
    {
        public TransDBContext(DbContextOptions<TransDBContext> options) : base(options)
        {

        }

        public DbSet<Trans> Trans
        {
            get; set;
        }
    }
}
