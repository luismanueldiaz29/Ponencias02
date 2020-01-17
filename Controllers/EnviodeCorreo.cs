using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Ponencias02.Models;

namespace  Ponencias02.Controllers
{
    public class EnvioDeEmail
    {
         
        private MailMessage CrearEmail(Docente docente, string encabezado, string body)
        {

            
            MailMessage email = new MailMessage();
            email.To.Add(docente.Email);
            email.From = new MailAddress("Ponencias02upc@gmail.com");
            email.Subject = encabezado; //"Registro de Usuario " + DateTime.Now.ToString("dd/ MMM / yyy hh:mm:ss");
            email.Body = body;//$"Estimado Docente : {docente.Nombres} {docente.Apellidos}\n se ha registrado su inventario exitosamente. Su Usuario: {docente.Email}\n Contraseña: {docente.Pass} ";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            return email;
        }
        private SmtpClient ConfigurarSMTP()
        {
            //protocolo de acceso al servidor de correos
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            //aca toca poner un correo con su contraseña, ojo con eso manito.
            smtp.Credentials = new System.Net.NetworkCredential("Ponencias02upc@gmail.com", "28082018");
            return smtp;
        }

        public string EnviarEmail(Docente docente, string encabezado, string body)
        {
            string resultado = string.Empty;
            try
            {
                SmtpClient smtp = ConfigurarSMTP();
                MailMessage email = CrearEmail(docente, encabezado, body);
                smtp.Send(email);
                email.Dispose();
                resultado = "Correo enviado";
            }
            catch (Exception er)
            {
                resultado = "Error enviando Correo electrónico: " + er.Message;
            }
            Console.WriteLine(resultado);
            return resultado;
        }
    }
}
