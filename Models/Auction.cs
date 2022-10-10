using System.ComponentModel.DataAnnotations;

namespace nft_project.Models
{
    public class Auction
    {
        [Key]
        public string nft_id { get; set; }
        [Required]
        public string camp_id { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public DateTime createAt { get; set; }
    }
}
