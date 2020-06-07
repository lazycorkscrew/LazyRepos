using MedicalManager.IDAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MedicalManager.Entities;

namespace MedicalManager.DAL
{
    public class EmailAccessor :IEmailAccessorContracts
    {
        public EmailSettings GetEmailSettings()
        {
            return new EmailSettings
            {
                Host = Properties.SettingsDB.Default.EmailHost,
                Port = Properties.SettingsDB.Default.EmailPort,
                Address = Properties.SettingsDB.Default.EmailAddress,
                Password = Properties.SettingsDB.Default.EmailPassword,
                EnableSSL = Properties.SettingsDB.Default.EmailEnableSSL
            };
        }
        public bool SetEmailSettings(EmailSettings emailSettings)
        {
            try
            {
                Properties.SettingsDB.Default.EmailHost = emailSettings.Host;
                Properties.SettingsDB.Default.EmailPort = emailSettings.Port;
                Properties.SettingsDB.Default.EmailAddress = emailSettings.Address;
                Properties.SettingsDB.Default.EmailPassword = emailSettings.Password;
                Properties.SettingsDB.Default.EmailEnableSSL = emailSettings.EnableSSL;
                Properties.SettingsDB.Default.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SendMail(string mailto, string caption, string message, string[] attachFiles)
        {
            using (SmtpClient smtpClient = new SmtpClient(Properties.SettingsDB.Default.EmailHost, (int)Properties.SettingsDB.Default.EmailPort))
            {
                smtpClient.EnableSsl = Properties.SettingsDB.Default.EmailEnableSSL;
                smtpClient.Credentials = new NetworkCredential(
                    Properties.SettingsDB.Default.EmailAddress.Split('@')[0],
                    Properties.SettingsDB.Default.EmailPassword,
                    Properties.SettingsDB.Default.EmailHost
                    );

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                if (
                    string.IsNullOrWhiteSpace(mailto) ||
                    string.IsNullOrWhiteSpace(caption) ||
                    string.IsNullOrWhiteSpace(message)
                    )
                {
                    return false;
                }

                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(Properties.SettingsDB.Default.EmailAddress);
                        mail.To.Add(new MailAddress(mailto));
                        mail.Subject = caption;
                        mail.Body = message;
                        mail.Sender = new MailAddress(Properties.SettingsDB.Default.EmailAddress);
                        if (attachFiles != null)
                        {
                            foreach (string attachFile in attachFiles)
                            {
                                mail.Attachments.Add(new Attachment(attachFile));
                            }
                        }

                        smtpClient.EnableSsl = Properties.SettingsDB.Default.EmailEnableSSL;
                        smtpClient.Credentials = new NetworkCredential(Properties.SettingsDB.Default.EmailAddress.Split('@')[0], Properties.SettingsDB.Default.EmailPassword);
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtpClient.Send(mail);
                        mail.Dispose();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
