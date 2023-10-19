using _24CV_WEB.Models;

namespace _24CV_WEB.Services
{
    public interface IEmailService
    {
        bool SendEmail(string email);
        bool SendEmailWithData(EmailData data);
    }
}
