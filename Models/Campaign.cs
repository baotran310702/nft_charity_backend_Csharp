using System.ComponentModel.DataAnnotations;

namespace nft_project.Models
{
    public class Campaign
    {
        [Key]
        public int id {get;set;}
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string img1_url { get; set; }
        [Required]
        public string img2_url { get; set; }
        [Required]
        public DateTime createAt { get; set; }
        [Required]
        public string zone { get; set; }

        public Campaign()
        {
            this.createAt = DateTime.Now;
        }
    }
}
