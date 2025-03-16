using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MyProfile.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }



        [StringLength(1000)]
        [Required]
        [Display(Name = "Institution Name")]
        public string InstitutionName { get; set; }


        [StringLength(1000)]
        [Display(Name = "Institution Logo Path")]
        public string InstitutionLogoPath { get; set; }


        [StringLength(1500)]
        [Required]
        [Display(Name = "Link")]
        public string Link { get; set; }


        [Required]
        [Display(Name = "Date Course")]
        [DataType(DataType.Date)]
        public DateTime DateCourse { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }


        [NotMapped]
        [Display(Name = "Upload Institution Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
