using KlerenGen.ApplicationCore.CEN.Kleren;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.Infraestructure.Repository.Kleren;
using web_kleren.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_kleren.Assemblers
{
    public class PedidoAssembler
    {
        public PedidoViewModel ConvertirENToViewModel(PedidoEN en)
        {
            PedidoViewModel ped = new PedidoViewModel();
            ped.PedidoId = en.PedidoId;
            ped.Total = en.Total;
            ped.TotalDescuento = en.TotalDescuento;
            ped.Estado = en.Estado;
            ped.DirEnvioId = en.DirEnvio.DirEnvioId;
            ped.Calle = en.DirEnvio.Calle;
            ped.Numero = en.DirEnvio.Numero;
            ped.Escalera = en.DirEnvio.Escalera;
            ped.Piso = en.DirEnvio.Piso;
            ped.Puerta = en.DirEnvio.Puerta;
            ped.CodPos = en.DirEnvio.CodPost;
            ped.Ciudad = en.DirEnvio.Ciudad;
            ped.Provincia = en.DirEnvio.Provincia;
            ped.Nombre = en.UsuarioRegistrado.Nombre;
            ped.Apellidos = en.UsuarioRegistrado.Apellidos;
            ped.Correo = en.UsuarioRegistrado.Correo;
            ped.FechaProcesado = en.FechaProcesado ?? default(DateTime);
            ped.FechaEntregado = en.FechaEntregado ?? default(DateTime);
            ped.FechaEnviado = en.FechaEnviado ?? default(DateTime);
            ped.FechaPagado = en.FechaPagado ?? default(DateTime);
            


            // Relación con UsuarioRegistrado
            if (en.UsuarioRegistrado != null)
            {
                ped.Correo = en.UsuarioRegistrado.Correo;
            }
            return ped;
        }
    }
}
