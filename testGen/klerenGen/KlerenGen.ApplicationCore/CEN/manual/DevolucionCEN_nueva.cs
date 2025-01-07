
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Devolucion_nueva) ENABLED START*/
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class DevolucionCEN
{
public int Nueva (int p_pedido, string p_motivoRechazo)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Devolucion_nueva_customized) START*/

        DevolucionEN devolucionEN = null;

        int oid;

        //Initialized DevolucionEN
        devolucionEN = new DevolucionEN ();

        if (p_pedido != -1) {
                devolucionEN.Pedido = new KlerenGen.ApplicationCore.EN.Kleren.PedidoEN ();
                devolucionEN.Pedido.PedidoId = p_pedido;
        }

        devolucionEN.MotivoRechazo = p_motivoRechazo;

        //Call to DevolucionRepository

        oid = _IDevolucionRepository.Nueva (devolucionEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
