using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using web_kleren.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_kleren.Assemblers
{
    public class DevolucionAssembler
    {
        public DevolucionViewModel ConvertirENToViewModel(DevolucionEN en)
        {
            DevolucionViewModel dev = new DevolucionViewModel();
            dev.DevolucionId = en.DevolucionId;
            dev.Total = en.Pedido.Total;
            dev.Estado = en.Estado;
            dev.Calle = en.Pedido.DirEnvio.Calle;
            dev.Numero = en.Pedido.DirEnvio.Numero;
            dev.Escalera = en.Pedido.DirEnvio.Escalera;
            dev.Piso = en.Pedido.DirEnvio.Piso;
         
            dev.CodPos = en.Pedido.DirEnvio.CodPost;
            dev.Ciudad = en.Pedido.DirEnvio.Ciudad;
            dev.Provincia = en.Pedido.DirEnvio.Provincia;
            dev.Nombre = en.Pedido.UsuarioRegistrado.Nombre;
            dev.Apellidos = en.Pedido.UsuarioRegistrado.Apellidos;
            dev.Correo = en.Pedido.UsuarioRegistrado.Correo;



            // Relación con UsuarioRegistrado
            /* if (en.UsuarioRegistrado != null)
             {
                 ped.Correo = en.UsuarioRegistrado.Correo;
             }*/


            return dev;
        }
    }
}
