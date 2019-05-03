using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ExternalServices
{
    public class EmailUtility
    {
        //public static string Send(EmailContent content)
        //{
        //    try
        //    {
        //        //    //string userName = ConfigurationManager.AppSettings["MailuserName"].ToString();
        //        //    //string password = ConfigurationManager.AppSettings["Mailpassword"].ToString();
        //        //    //string address = ConfigurationManager.AppSettings["MailFrom"].ToString();
        //        //    //string host = ConfigurationManager.AppSettings["Mailhost"].ToString();
        //        //    //int port = Convert.ToInt32(ConfigurationManager.AppSettings["Mailport"].ToString());
        //        //    SmtpClient smtpClient = new SmtpClient();
        //        //    smtpClient.UseDefaultCredentials = false;
        //        //    //smtpClient.Credentials = new NetworkCredential(userName, password);
        //        //    //smtpClient.Host = host;
        //        //    //smtpClient.Port = port;
        //        //    //smtpClient.EnableSsl = false;
        //        //    //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        //    //MailMessage mailMessage = new MailMessage();
        //        //    //mailMessage.From = new MailAddress(address, "PME");
        //        //    mailMessage.Subject = content.Subject;
        //        //    mailMessage.Body = content.Body;

        //        //    foreach (string item in content.To)
        //        //    {
        //        //        if (IsValid(item))
        //        //            mailMessage.To.Add(new MailAddress(item));
        //        //    }
        //        //    foreach (string item in content.CC)
        //        //    {
        //        //        if (IsValid(item))
        //        //            mailMessage.CC.Add(new MailAddress(item));
        //        //    }
        //        //    if (mailMessage.To.Count == 0) return "";
        //        //    mailMessage.IsBodyHtml = true;
        //        //    mailMessage.SubjectEncoding = Encoding.UTF8;
        //        //    mailMessage.BodyEncoding = Encoding.UTF8;
        //        //    smtpClient.Send(mailMessage);
        //        //    return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        MDLog.Error(ex);
        //        return ex.Message;
        //    }
        //}

        //private static bool IsValid(string emailaddress)
        //{
        //    if (String.IsNullOrEmpty(emailaddress)) return false;
        //    try
        //    {
        //        MailAddress m = new MailAddress(emailaddress);
        //        return true;
        //    }
        //    catch (FormatException)
        //    {
        //        return false;
        //    }
        //}
    }
}
