using SantaMarta.Data.Models.Mails;
using System;

namespace SantaMarta.Bussines.MailsBussines
{
    public interface IMailsB
    {
        int Create(Mails input);
        int Update(Mails input);
        Mails Get();
        int SendEmail(String toEmail, String subJect, String body);
    }
}
