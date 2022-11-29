using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nft_project.Models
{
    public class Auction
    {
        public Auction()
        {
            this.createAt = DateTime.Now;
        }
        
        [Key]
        public int nft_id { get; set; }
        [Required]
        public int camp_id { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public DateTime createAt { get; set; }

 
 
    }
}
