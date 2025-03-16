using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MyProfile.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [StringLength(10000)]
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }


        [StringLength(1500)]
        [Required]
        [Display(Name = "Link")]
        public string Link { get; set; }


        [StringLength(1000)]
        [Display(Name = "Project Logo Path")]
        public string ProjectLogoPath { get; set; }


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

        [Display(Name = "Upload Project Logo")]
        public IFormFile LogoFile { get; set; }
    }
}
