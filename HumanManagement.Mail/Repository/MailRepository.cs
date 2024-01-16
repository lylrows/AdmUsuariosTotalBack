using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.Mail.Dto;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace HumanManagement.Mail.Repository
{
    public class MailRepository: IMailRepository
    {
        public IConfiguration Configuration { get; }
        private string m_exePath = string.Empty;

        public MailRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<bool> SendMail(MailRequestDto mailRequest)
        {
            var email = new MimeMessage();
            
            email.From.Add(new MailboxAddress(Configuration["AppSettings:FromNameNotification"].ToString(), Configuration["AppSettings:FromMailNotification"].ToString()));
            
            foreach (var semail in mailRequest.To)
            {
                email.To.Add(MailboxAddress.Parse(semail));
            }
            if (mailRequest.Cc != null)
            {
                foreach (var semail in mailRequest.Cc)
                {
                    email.Cc.Add(MailboxAddress.Parse(semail));
                }
            }
            if (mailRequest.Bcc != null)
            {
                foreach (var semail in mailRequest.Bcc)
                {
                    email.Bcc.Add(MailboxAddress.Parse(semail));
                }
            }
            email.Subject = mailRequest.Message.Subject;


            var builder = new BodyBuilder();

            if (mailRequest.Message.Body.Format ==  EnumBodyMail.Flowed)
            {
                builder.TextBody = mailRequest.Message.Body.Value;
            }
            if (mailRequest.Message.Body.Format ==  EnumBodyMail.Html)
            {
                builder.HtmlBody = mailRequest.Message.Body.Value;
            }
            List<string> strPathFiles = new List<string>();
            if (mailRequest.Message.Attachment != null)
            {

                string newPath = Configuration["AppSettings:PathTempMailFiles"].ToString();
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                foreach (var file64b in mailRequest.Message.Attachment)
                {
                    Byte[] bytes = Convert.FromBase64String(file64b.Value);
                    string pathfile = newPath + file64b.FileName;

                    File.WriteAllBytes(pathfile, bytes);
                    builder.Attachments.Add(pathfile);
                    strPathFiles.Add(pathfile);
                }
            }

            email.Body = builder.ToMessageBody();
            try
            {
                LogWrite("Declarando el cliente");
                using var smtp = new SmtpClient();

                LogWrite("Checking certificate revocation to false");
                smtp.CheckCertificateRevocation = false;
                LogWrite("Setting callback validation");
                smtp.ServerCertificateValidationCallback = (s, c, ch, e) => true;
                LogWrite("Conectando al servidor ");
                LogWrite("MailServer: " + Configuration["AppSettings:MailServer"].ToString());
                LogWrite("Puerto: " + int.Parse(Configuration["AppSettings:MailPort"].ToString()));
                smtp.Connect(Configuration["AppSettings:MailServer"].ToString(), int.Parse(Configuration["AppSettings:MailPort"].ToString()), SecureSocketOptions.StartTls);

                LogWrite("Conectando al correo: " + Configuration["AppSettings:MailUser"].ToString());
                smtp.Authenticate(Configuration["AppSettings:MailUser"].ToString(), Configuration["AppSettings:MailPassword"].ToString());
                LogWrite("Se conectó de manera correcta");
                LogWrite("Enviando el correo...");
                smtp.Send(email);
                LogWrite("Se envió de manera correcta");
                LogWrite("Desconectando...");
                smtp.Disconnect(true);
                LogWrite("Terminado");
            }
            catch (Exception ex)
            {
                foreach (var path in strPathFiles)
                {

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }
                }
                LogWrite("Ocurrio un error:");
                LogWrite(ex.Message);

                return false;
            }

            foreach (var path in strPathFiles)
            {

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }


            
            
            LogWrite("log something");

            
            return true;
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = Configuration["AppSettings:PathSaveFile"].ToString();
            try
            {
                
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(),DateTime.Now.ToLongDateString(), logMessage);
            }
            catch (Exception ex)
            {
            }
        }

    }
}
