using System.ComponentModel.DataAnnotations;

namespace MyProfile.Models
{
    public class MailRequest
    {
        [Required]
        public string ToEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public string Attachments { get; set; }
        //public IFormFile Attachments { get; set; }
    }
}
