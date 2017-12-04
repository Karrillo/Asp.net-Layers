using SantaMarta.Data.Models.Mails;
using SantaMarta.DataAccess.Entity;
using System;
using System.Net.Mail;

namespace SantaMarta.DataAccess.Emails
{
    public class EmailsAccess
    {
        private ContextDb db;

        public EmailsAccess()
        {
            db = new ContextDb();
        }

        //Create Email
        public int Create(Mails emails)
        {
            try
            {
                emails.Password = Encrypt(emails.Password);
                db.Insert_Email(emails);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Update Email
        public int Update(Mails emails)
        {
            try
            {
                emails.Password = Encrypt(emails.Password);
                db.Update_Email(emails);
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        //Get Email
        public Mails Get()
        {
            Mails emails = new Mails();
            try
            {
                emails = db.View_Email();
                if (emails == null)
                {
                    return emails;
                }
                else
                {
                    emails.Password = Decrypt(emails.Password);
                    return emails;
                }
            }
            catch (Exception)
            {
                return emails;
            }
        }

        //Send Email
        public int SendEmail(String toEmail, String subJect, String body)
        {
            Mails email = db.View_Email();
            email.Password = Decrypt(email.Password);

            if (email != null)
            {
                try
                {
                    MailMessage mail = new MailMessage();

                    SmtpClient SmtpServer = new SmtpClient();

                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(email.Email, email.Password);
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                    mail.From = new MailAddress(email.Email);
                    mail.To.Add(toEmail);
                    mail.Subject = subJect;
                    mail.Body = body;

                    SmtpServer.Send(mail);
                    return 200;
                }
                catch (Exception)
                {
                    return 500;
                }
            }
            return 400;
        }

        //Encrypt passwords
        private String Encrypt(String password)
        {
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(password);
            String passEncrypt = Convert.ToBase64String(encrypted);
            return passEncrypt;
        }

        //Decrypt passwords
        private String Decrypt(String password)
        {
            byte[] decrypted = Convert.FromBase64String(password);
            String passDecryted = System.Text.Encoding.Unicode.GetString(decrypted);
            return passDecryted;
        }
    }
}
