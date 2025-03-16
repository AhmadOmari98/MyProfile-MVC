using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyProfile.Models
{
    public class ContactUs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(1000)]
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        [RegularExpression(@"^[a-zA-Z\d\.\+_\'%-]+@([a-zA-Z\d-]+\.)+[a-zA-Z]{2,6}$", ErrorMessage = "The email entered is incorrect.")]
        [StringLength(600)]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[RegularExpression(@"^07[789]\d{7}$", ErrorMessage = "The PhoneNumber entered is incorrect.")]
        [StringLength(600)]
        [Required]
        [Display(Name = "Phonenumber")]
        public string Phonenumber { get; set; }

        [StringLength(4000)]
        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [StringLength(4000)]
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [StringLength(400)]
        [Display(Name = "Respond")]
        public string Respond { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
