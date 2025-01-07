using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class TramitarAssembler
    {
        public TramitarViewModel ConvertirENToViewModel(PedidoEN en)
        {
            TramitarViewModel ped = new TramitarViewModel();
            ped.PedidoId = en.PedidoId;
            ped.Total = en.Total;
            ped.TotalDescuento = en.TotalDescuento;
            ped.EstadoP = en.Estado;
            ped.DirEnvioId = en.DirEnvio.DirEnvioId;
            ped.Calle = en.DirEnvio.Calle;
            ped.Numero = en.DirEnvio.Numero;
            ped.Escalera = en.DirEnvio.Escalera;
            ped.Piso = en.DirEnvio.Piso;
            ped.Puerta = en.DirEnvio.Puerta;
            ped.CodPos = en.DirEnvio.CodPost;
            ped.Ciudad = en.DirEnvio.Ciudad;
            ped.Provincia = en.DirEnvio.Provincia;
            ped.Puntos = en.UsuarioRegistrado.Puntos;
            return ped;
        }

        public FacturaViewModel ConvertirENFactToViewModel(FacturaEN en)
        {
            FacturaViewModel fac = new FacturaViewModel();
            fac.FacturaId = en.FacturaId;
            fac.PedidoId = en.Pedido.PedidoId;
            fac.Descuento = en.Descuento;
            fac.Telefono = en.Telefono;
            fac.Iva = en.Iva; 
            fac.Total = en.Total;
            fac.Apellidos = en.Apellidos;
            fac.Email = en.Email;
            fac.Fecha = en.Fecha;
            fac.Nombre = en.Nombre;
            fac.SubTotal = en.Subtotal;
            return fac;
        }
    }
}
