using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.Models
{
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Language Name")]
        public string LanguageName { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
