
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Pedido_calcularDescuento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class PedidoCEN
{
public double CalcularDescuento (int p_pedido)
{
            /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Pedido_calcularDescuento) ENABLED START*/

            PedidoEN pedido = _IPedidoRepository.DamePorId(p_pedido);
            UsuarioRegistradoEN usu = pedido.UsuarioRegistrado;

            double totalPed = pedido.Total;

            int punt_tot = (int)(totalPed * 100); //los puntos necesarios para que salga gratis
            int p_descuento;

            //cada punto equivale a 0,01 

            if (punt_tot > usu.Puntos)
            {
                p_descuento = usu.Puntos;
            }
            else
            {
                p_descuento = punt_tot;
            }

            double descEnDinero = p_descuento * 0.01;

            double precioFinal = totalPed - descEnDinero;

            return precioFinal;

            /*PROTECTED REGION END*/
        }
}
}
