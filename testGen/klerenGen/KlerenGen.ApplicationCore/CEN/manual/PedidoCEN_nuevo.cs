
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Pedido_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class PedidoCEN
{
public int Nuevo (int p_dirEnvio, int p_metodoPago, int p_usuarioRegistrado)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Pedido_nuevo_customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_dirEnvio != -1) {
                pedidoEN.DirEnvio = new KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN ();
                pedidoEN.DirEnvio.DirEnvioId = p_dirEnvio;
        }


        if (p_metodoPago != -1) {
                pedidoEN.MetodoPago = new KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN ();
                pedidoEN.MetodoPago.MetodoId = p_metodoPago;
        }


        if (p_usuarioRegistrado != -1) {
                pedidoEN.UsuarioRegistrado = new KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN ();
                pedidoEN.UsuarioRegistrado.UsuarioRegistradoId = p_usuarioRegistrado;
        }

        pedidoEN.Estado = Enumerated.Kleren.EstadoPedidoEnum.cesta;
        pedidoEN.FechaEnviado = null;
        pedidoEN.FechaPagado = null;
        pedidoEN.FechaProcesado = null;
        pedidoEN.FechaEntregado = null;

        //Call to PedidoRepository

        oid = _IPedidoRepository.Nuevo (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
