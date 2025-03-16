using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MyProfile.Models
{
    public class Education
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Degreet Name")]
        public string DegreeName { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Section Name")]
        public string SectionName { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Grade")]
        public string Grade { get; set; }



        [StringLength(1000)]
        [Required]
        [Display(Name = "Institution")]
        public string Institution { get; set; }


        [StringLength(1000)]
        [Display(Name = "Institution Logo Path")]
        public string InstitutionLogoPath { get; set; }


        [Required]
        [Display(Name = "Date From")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }


        [Required]
        [Display(Name = "Date To")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }


        [NotMapped]
        [Display(Name = "Upload Institution Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
