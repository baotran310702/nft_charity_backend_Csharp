using System.ComponentModel.DataAnnotations;

namespace nft_project.Models
{
    public class Campaign
    {
        [Key]
        public string camp_id {get;set;}
        [Required]
        public string title { get; set; }
        [Required]
        public string desciption { get; set; }
        [Required]
        public string img1_url { get; set; }
        [Required]
        public string img2_url { get; set; }
        [Required]
        public DateTime createAt { get; set; }
        [Required]
        public DateTime endAt { get; set; }

    }
}
