using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyProfile.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(500)]
        [Required]
        [Display(Name = "Skill Name")]
        public string SkillName { get; set; }


        [StringLength(500)]
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }


        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
        public Resume Resume { get; set; }


    }
}
