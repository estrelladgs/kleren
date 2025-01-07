
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Pedido_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class PedidoCEN
{
public void Modificar (int p_Pedido_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum p_estado)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Pedido_modificar_customized) ENABLED START*/

        PedidoEN pedidoEN = _IPedidoRepository.DamePorId (p_Pedido_OID);

        if (pedidoEN == null) {
                throw new Exception ("Pedido no encontrado");
        }

        // Actualizar el estado y la fecha correspondiente dependiendo del nuevo estado
        pedidoEN.Estado = p_estado;

        switch (p_estado) {
        case Enumerated.Kleren.EstadoPedidoEnum.pagado:
                pedidoEN.FechaPagado = DateTime.Now;
                break;

        case Enumerated.Kleren.EstadoPedidoEnum.procesado:
                pedidoEN.FechaProcesado = DateTime.Now;
                break;

        case Enumerated.Kleren.EstadoPedidoEnum.enviado:
                pedidoEN.FechaEnviado = DateTime.Now;
                break;

        case Enumerated.Kleren.EstadoPedidoEnum.entregado:
                pedidoEN.FechaEntregado = DateTime.Now;
                break;

        default:
                throw new Exception ("Estado de pedido no valido");
        }

        _IPedidoRepository.Modificar (pedidoEN);

        /*PROTECTED REGION END*/
}
}
}
