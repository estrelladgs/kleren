
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Pedido_calcularDescuento) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class PedidoCP : GenericBasicCP
{
public double CalcularDescuento (int p_pedido)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Pedido_calcularDescuento) ENABLED START*/

        PedidoCEN pedidoCEN = null;

        double precioFinal = 0.0;


        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);

                PedidoEN pedidoen = pedidoCEN.DamePorId (p_pedido);
                UsuarioRegistradoEN usu = pedidoen.UsuarioRegistrado;
                int puntosUsuario = usu.Puntos;

                double totalPed = pedidoen.Total;

                int punt_tot = (int)(totalPed * 100);     //los puntos necesarios para que salga gratis
                int p_descuento;

                //cada punto equivale a 0,01?

                if (punt_tot > puntosUsuario) {
                        p_descuento = puntosUsuario;
                }
                else{
                        p_descuento = punt_tot;
                }

                double descEnDinero = p_descuento * 0.01;

                precioFinal = totalPed - descEnDinero;

                pedidoen.TotalDescuento = precioFinal;

                CPSession.Commit ();
        }
        catch (Exception)
        {
                CPSession.RollBack ();
                throw;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return precioFinal;


        /*PROTECTED REGION END*/
}
}
}
