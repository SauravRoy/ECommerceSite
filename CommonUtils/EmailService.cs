using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtils
{
    public class EmailService : IMail
    {
        public void SendMail(string Email, string password)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("imsauravroy007@gmail.com", "Password Remainder");
            mail.To.Add(Email);
            mail.IsBodyHtml = true;
            mail.Subject = "Your account information !";
            mail.Body = "Your account Id and Password are " + Email + "-" + password;
            mail.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("jamalindia234@gmail.com", "Victory#123");
            smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
             smtp.Send(mail);
        }


        public void Notify(string Email)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("imsauravroy007@gmail.com", "Password Remainder");
            mail.To.Add(Email);
            mail.IsBodyHtml = true;
            mail.Subject = "Order Creation";
            mail.Body = "Your order has been created";
            mail.Priority = MailPriority.High;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //smtp.UseDefaultCredentials = true;
            smtp.Credentials = new System.Net.NetworkCredential("jamalindia234@gmail.com", "Victory#123");
            smtp.EnableSsl = true;
            //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
        }


    }
}
