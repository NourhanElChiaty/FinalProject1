using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MoviME.Models
{
    public class Email
    {
        public void sendMail(String mailBody)
        {
            MailAddress from = new MailAddress("nurhanelchiaty@gmail.com");
            MailAddress to = new MailAddress("nurhanelchiaty@outlook.com");
            MailMessage message = new MailMessage(from, to);

            message.Subject = "Notify";


            message.Body = mailBody;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("nurhanelchiaty@gmail.com", "instagram96");


            client.Send(message);
        }
    }
}

    