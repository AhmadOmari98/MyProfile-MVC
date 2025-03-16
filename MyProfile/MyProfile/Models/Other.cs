using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace MyProfile.Models
{
    public class Other
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(1000)]
        [Display(Name = "Cv *pdf")]
        public string CvPath { get; set; }


        [StringLength(1000)]
        [Display(Name = "Image SiteBar")]
        public string ImageSiteBarPath { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }



        [NotMapped]
        [Display(Name = "Cv File")]
        public IFormFile CvFile { get; set; }

        [NotMapped]
        [Display(Name = "Image SiteBar File")]
        public IFormFile ImageSiteBarFile { get; set; }


    }
}
