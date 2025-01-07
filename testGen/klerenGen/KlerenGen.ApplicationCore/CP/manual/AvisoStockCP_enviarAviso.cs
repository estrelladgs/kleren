using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_AvisoStock_enviarAviso) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
    public partial class AvisoStockCP : GenericBasicCP
    {
        public void EnviarAviso(int p_oid)
        {
            /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_AvisoStock_enviarAviso) ENABLED START*/

            AvisoStockCEN avisoStockCEN = null;
            VarianteCEN varianteCEN = null;
            ArticuloCEN articuloCEN = null;



            try
            {
                CPSession.SessionInitializeTransaction();
                avisoStockCEN = new AvisoStockCEN(CPSession.UnitRepo.AvisoStockRepository);
                articuloCEN = new ArticuloCEN(CPSession.UnitRepo.ArticuloRepository);
                varianteCEN = new VarianteCEN(CPSession.UnitRepo.VarianteRepository);

                AvisoStockEN avisoStocken = avisoStockCEN.DamePorId(p_oid);

                if (avisoStocken == null)
                {
                    Console.WriteLine("No se ha encontrado un aviso con el ID proporcionado.");
                    return;
                }

                MailMessage msg = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                msg.From = new MailAddress("klerentienda@gmail.com");
                msg.To.Add(new MailAddress(avisoStocken.Email));

                msg.Subject = $"{avisoStocken.Variante.Articulo.Nombre} ya disponible";

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
                    $"            <h1 style=\"margin: 0;\">¡{avisoStocken.Variante.Articulo.Nombre} ya está disponible!</h1>" +
                    "        </header>" +
                    "        <main style=\"padding: 20px;\">" +
                    "            <h2 style=\"color: #351e5c; margin-bottom: 15px;\">Hola de nuevo,</h2>" +
                    $"            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">¡Buenas noticias desde Kleren! La prenda que estabas esperando, <strong>{avisoStocken.Variante.Articulo.Nombre}</strong>, ya se encuentra disponible.</p>" +
                    "            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">No pierdas la oportunidad de verte espectacular.</p>" +
                    $"            <img src=\"{avisoStocken.Variante.ImagenVariante.RutaArchivo}\" alt=\"{avisoStocken.Variante.ImagenVariante.TextoAlternativo}\" style=\"max-width: 80%; border-radius: 8px; margin: 20px auto; display: block;\">" +
                    "            <p style=\"line-height: 1.6; color: #010E18; margin-bottom: 15px;\">¡Corre que vuela!, no esperes más.</p>" +
                    "            <a href=\"#\" style=\"display: inline-block; padding: 12px 24px; margin: 20px auto; background-color: #D9BCFE; color: #351e5c; text-decoration: none; border-radius: 4px; font-weight: bold;\">Comprar ahora</a>" +
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

                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                Console.WriteLine("Error al enviar el correo " + ex.ToString());
                throw;
            }
            finally
            {
                CPSession.SessionClose();
            }


            /*PROTECTED REGION END*/
        }
    }
}