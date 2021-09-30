using NUnit.Framework;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System;

namespace DataDrivenForFB.Email
{
    public class EmailClass
    { 
        public static ExcelOperationForEmail excel;
        //Here we are reading the data from excel
        public static void ReadDataFromExcel()
        {
            excel = new ExcelOperationForEmail();
            excel.PopulateFromExcel(@"C:\Users\vedhashni.v\source\repos\DataDrivenForFB\DataDrivenForFB\Data\EmailData.xlsx");
        }

        public static void email_send()
        {
            try
            {
                string FromMail = ConfigurationManager.AppSettings.Get("frommail");
                string ToMail = ConfigurationManager.AppSettings.Get("tomail");
                string Password = ConfigurationManager.AppSettings.Get("password");
                string AttachFile = ConfigurationManager.AppSettings.Get("attachfile");
                excel = new ExcelOperationForEmail();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //we are sending our from mail id
                mail.From = new MailAddress(FromMail);
                //we are adding to mail id
                mail.To.Add(ToMail);
                //Subject of the mail is added
                mail.Subject = "Amazon test mail";
                //Body of the mail is added
                mail.Body = "mail with amazon report attachmement";
                Attachment attachment;
                attachment = new Attachment(AttachFile);
                Assert.NotNull(attachment);
                //here we attach the report of the automation
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential(FromMail, Password);
                SmtpServer.EnableSsl = true;
                //Here we click send mail 
                SmtpServer.Send(mail);
            }
            catch
            {
                Console.WriteLine("Error Occured");
            }
        }
    }
}
