using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_solicitarBorrarCuenta) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using KlerenGen.ApplicationCore.CP.Kleren;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
    public partial class UsuarioRegistradoCEN
    {
        public void SolicitarBorrarCuenta(int p_oid, String p_pass)
        {
            /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_solicitarBorrarCuenta) ENABLED START*/

            UsuarioRegistradoEN usuario = _IUsuarioRegistradoRepository.ReadOIDDefault(p_oid);

            if (usuario != null && usuario.Pass.Equals(Utils.Util.GetEncondeMD5(p_pass)))
            {
                Borrar(p_oid);
            }
            else
            {
                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                msg.From = new MailAddress("klerentienda@gmail.com");
                msg.To.Add(new MailAddress(usuario.Correo));

                msg.Subject = "Alerta de seguridad Kleren";

                string html = "<!DOCTYPE html>" +
                    "<html lang=\"es\">" +
                    "<head>" +
                    "    <meta charset=\"UTF-8\">" +
                    "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                    "    <title>Correo Kleren</title>" +
                    "</head>" +
                    "<body style=\"font-family: Arial, sans-serif; color: #010E18; margin: 0; padding: 0; text-align: center; background-color: #FFFFFE;\">" +
                    "    <div style=\"max-width: 600px; margin: 20px auto; padding: 20px; background-color: #FFFFFE; border-radius: 8px; box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);\">" +
                    "        <header style=\"background-color: #351e5c; padding: 20px; color: #D9BCFE;\">" +
                    $"            <h1 style=\"margin: 0;\">Alguien ha intentado borrar tu cuenta</h1>" +
                    "        </header>" +
                    "        <main style=\"padding: 20px;\">" +
                    $"            <h2 style=\"color: #351e5c; margin-bottom: 15px;\">Hola {usuario.Nombre},</h2>" +
                    $"            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">Desde Kleren deseamos avisarte de que alguien ha intentado eliminar tu cuenta.</p>" +
                    "            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">¿No has sido tú? Por favor, cambia tu contraseña lo antes posible. Si sí has sido tú no tienes de que preocuparte, aunque te echaremos de menos.</p>" +
                    "            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">No te vayas.</p>" +
                    "            <a href=\"#\" style=\"display: inline-block; padding: 12px 24px; margin: 20px auto; background-color: #D9BCFE; color: #351e5c; text-decoration: none; border-radius: 4px; font-weight: bold;\">Acceder a mi cuenta</a>" +
                    "        </main>" +
                    "        <footer style=\"background-color: #010E18; color: #D0D9E0; text-align: center; padding: 15px; font-size: 14px;\">" +
                    "            <p>&copy; 2024 Kleren. Todos los derechos reservados.</p>" +
                    "        </footer>" +
                    "    </div>" +
                    "</body>" +
                    "</html>";


                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                msg.AlternateViews.Add(htmlView);

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential("klerentienda@gmail.com", "fknglohjmnfjjprh");
                smtp.EnableSsl = true;

                smtp.Send(msg);
                Console.WriteLine("El correo se ha enviado correctamente!!");
            }

            /*PROTECTED REGION END*/
        }
    }
}