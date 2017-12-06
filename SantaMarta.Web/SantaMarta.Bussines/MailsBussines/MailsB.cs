using SantaMarta.Data.Models.Mails;
using SantaMarta.DataAccess.Emails;
using System;

namespace SantaMarta.Bussines.MailsBussines
{
    public class MailsB
    {
        private EmailsAccess emailsAccess = new EmailsAccess();
        public int Create(Mails input)
        {
            return emailsAccess.Create(input);
        }
        public Mails Get()
        {
            return emailsAccess.Get();
        }

        public int Update(Mails input)
        {
            return emailsAccess.Update(input);
        }

        public int SendEmail(String toEmail, String subJect, String body)
        {
            return emailsAccess.SendEmail(toEmail, subJect, body);
        }
    }
}
