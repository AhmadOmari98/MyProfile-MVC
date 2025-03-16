using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MyProfile.Models
{
    public class Experience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [StringLength(5000)]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [StringLength(1000)]
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [StringLength(1000)]
        [Display(Name = "Company Logo Path")]
        public string CompanyLogoPath { get; set; }


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
        [Display(Name = "Upload Company Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
