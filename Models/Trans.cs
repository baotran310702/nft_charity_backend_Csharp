using System.ComponentModel.DataAnnotations;

namespace nft_project.Models
{
    public class Trans
    {
        [Key]
        public string trans_id { get; set; }
        [Required]
        public string account_address { get; set; }
        [Required]
        public double amount { get; set; }
        [Required]
        public int is_nft_trans { get; set; }
        [Required]
        public DateTime createAt { get; set; }
    }
}
