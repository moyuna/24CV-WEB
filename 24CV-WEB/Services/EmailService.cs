using System.Net.Mail;
using System.Net;
using _24CV_WEB.Models;

namespace _24CV_WEB.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string email)
        {
            bool result = false;

            try
            {

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");

                mail.From = new MailAddress("moises.puc@shapp.mx", "Admistrador");
                mail.To.Add(email);
                mail.Subject = "Notificación de contacto.";
                mail.IsBodyHtml = true;
                mail.Body = $"Se ha recibido información del correo <h1>{email}</h1> <br/> <p></p>";

                smtp.Send(mail);
            }
            catch (Exception e)
            {

            }

            return  result;
        }

        public bool SendEmailWithData(EmailData data)
        {
            bool result = false;

            try
            {

                MailMessage mail = new MailMessage();

                SmtpClient smtp = new SmtpClient("mail.shapp.mx", 587);

                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("moises.puc@shapp.mx", "Dhaserck_999");

                mail.From = new MailAddress("moises.puc@shapp.mx", "Admistrador");
                mail.To.Add(data.Email);
                mail.Subject = data.Subject;
                mail.IsBodyHtml = true;
                mail.Body = data.Content;

                smtp.Send(mail);
            }
            catch (Exception e)
            {

            }

            return result;
        }
    }
}
