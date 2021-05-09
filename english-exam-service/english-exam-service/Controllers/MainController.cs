using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnglishExamService.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet("sendResult")]
        public bool sendResultByEmail(string name, string email, int score, int correctAnswer, int totalAnswer)
        {
            try
            {
                string from = "davidnth12171@gmail.com";
                string password = "ngotrungtinh";
                //for working, please make sure you did allow accessing to less secure apps when using gmail
                //string cc = "email";
                string content = "Hi " + name + "<br> This is a result of TOEIC English Examination you just got<br><br>"
                    + "Name: " + name + "<br>"
                    + "Email: " + email + "<br>"
                    + "Score: " + score + " ("+correctAnswer+"/"+totalAnswer+")<br><br>"
                    + "Notice: This is an automatic email, please do not reply it";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential(from, password);
                // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.Subject = "Result of TOEIC English Examination";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = content;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.Priority = MailPriority.High;

                //Setting From , To and CC
                mail.From = new MailAddress(from, "TOEIC English Examination");
                mail.To.Add(new MailAddress(email));
                //mail.CC.Add(new MailAddress(cc));

                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Cannot send email, message: " + e.Message);
                return false;
            }
            System.Diagnostics.Debug.WriteLine("The email has been sent");
            return true;

        }
    }
}
