namespace MyProfile.Models
{
    public interface IMailingService
    {
        bool SendEmail(MailRequest mailRequest);
    }
}
