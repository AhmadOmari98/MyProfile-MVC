using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.Models
{
    public class Resume
    {

        //Data Annotations
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(150)]
        [Required]
        [Display(Name="Cv Owner Name")]
        public string Name { get; set; }



        
        public virtual ICollection<BasicInfo> BasicInfos { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Education> Educations { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<ContactUs> ContactUss { get; set; }

        public virtual ICollection<Other> Others { get; set; }
    }
}
