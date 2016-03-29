using AnimalsParty.Models;
using AnimalsParty.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AnimalsParty.Services
{
    public static class EmailService
    {
        public static void SendEmail(User user)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("no-reply@animals-party.com");
            mail.To.Add("antoncholakov14@gmail.com");
            mail.Subject = "Somebody has logged in!";
            mail.Body = "Dear admin, " + user.Username + " has logged in!";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testforhallmanager@gmail.com", "hallmanager");

            smtp.Send(mail);
        }


        /// <summary>
        /// Sends Emails to all users in the system that admin has logged in!
        /// </summary>
        /// <param name="users"></param>
        public static void SendEmails()
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("no-reply@animals-party.com");
            mail.Subject = "Somebody has logged in!";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("testforhallmanager@gmail.com", "hallmanager");

            foreach (User user in new UsersRepository().GetAll())
            {
                if (user.ID != AuthenticationService.LoggedUser.ID)
                {
                    mail.To.Add(user.Email);
                    mail.Body = "Dear " + user.Username + ", admin has logged in!";

                    smtp.Send(mail);
                    mail.To.Clear();
                }
            }
        }
    }
}