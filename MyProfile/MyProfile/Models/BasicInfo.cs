using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;

namespace MyProfile.Models
{
    public class BasicInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }


        [StringLength(150)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }


        [StringLength(1000)]
        [Required]
        [Display(Name = "Link-Linkedin")]
        public string LinkLinkedin { get; set; }


        [StringLength(1000)]
        [Required]
        [Display(Name = "Link-GitHub")]
        public string LinkGitHub { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "E-mail")]
        public string Email  { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [StringLength(4000)]
        [Required]
        [Display(Name = "AboutMe")]
        public string AboutMe { get; set; }



        [Required]
        [Display(Name = "Birthday")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }



        [StringLength(1000)]
        [Display(Name = "ImagePath")]
        public string ImagePath { get; set; }



        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }



        [NotMapped]
        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; }



    }
}
