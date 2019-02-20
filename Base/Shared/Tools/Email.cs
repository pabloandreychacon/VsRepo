using System;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace Tools
{
    public class Email
    {
        public static void SendEmail(string mensajeBody, int port, int timeout, string host, string userName, string password,
            string asunto, string fromEmail, string displayName, string destinos, bool isHtml = false)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                SmtpClient smtp = new SmtpClient
                {
                    Port = port,// 25;//El puerto debe ser correctamente configurado. (puertos: 25,587, o 465)
                    Timeout = timeout, //60000;//Tiempo de conexión en milisegundos
                    Host = host,// ;
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential
                    { UserName = userName, Password = password }
                };
                //Objeto referente a quién envía el correo
                MailAddress from = new MailAddress(fromEmail, displayName, System.Text.Encoding.UTF8);
                var mails = destinos.Split(';');
                using (MailMessage message = new MailMessage())
                {
                    message.From = from;
                    message.Subject = asunto;
                    //Cargamos el contenido del mail.
                    message.Body = mensajeBody;
                    message.Priority = MailPriority.High;
                    message.IsBodyHtml = isHtml;

                    //Cargamos todos los mails que se ingresaron
                    //en el campor de text
                    foreach (string dir in mails)
                        message.To.Add(dir);
                    try
                    {
                        //Se envía el mail
                        smtp.Send(message);
                        //MessageBox.Show("El email fue enviado");
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            else
            {
                var myType = typeof(Email);
                var ns = myType.Namespace;
                throw new Exception("No hay conexión a Internet, imposible enviar correo. " + ns);
            }
        }
    }
}
