using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace SMTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController: ControllerBase
    {
        [HttpPost("/api/Email")]
        public IActionResult SendEmail([FromBody] Persona persona)
        {
            try
            {
                EnviarCorreo(persona);
                return Ok(new { message = "Correo enviado correctamente." });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { error = ex.Message });
            }
        }

        private void EnviarCorreo(Persona persona)
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "jorgelituma094@gmail.com"; 
            string password = "pure mgej fvnc acwh"; 
            string emailTo = "jorgelituma096@gmail.com"; 
            string subject = "Nueva Persona Creada";
            string body = $"Detalles de la nueva persona:\n" +
                          $"Cédula: {persona.cedula}\n" +
                          $"Nombre: {persona.nombre}\n" +
                          $"Apellido: {persona.apellido}\n" +
                          $"Edad: {persona.edad}";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }

    public class Persona
    {
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
    }
}
