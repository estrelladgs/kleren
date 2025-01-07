
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_LinPed_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class LinPedCP : GenericBasicCP
{
public void Modificar (int p_LinPed_OID, int p_cantidad, int p_variante)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_LinPed_modificar) ENABLED START*/

        LinPedCEN linPedCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                linPedCEN = new  LinPedCEN (CPSession.UnitRepo.LinPedRepository);


                LinPedEN linPedEN = linPedCEN.DamePorId (p_LinPed_OID);
                //Initialized LinPedEN
                //linPedEN = new LinPedEN ();
                //linPedEN.LineaId = p_LinPed_OID;
                if (p_variante == 0) {
                        if (p_cantidad != 0) {
                                VarianteEN var = linPedEN.Variante;
                                ArticuloEN art = var.Articulo;
                                PedidoEN ped = linPedEN.Pedido;

                                int cant = linPedEN.Cantidad;
                                int res = 0;

                                res = cant + p_cantidad;
                                if (var.Stock >= res) {
                                        if (res > cant) {
                                                linPedEN.Cantidad = res;
                                                if (art.Promocion == true) {
                                                        float c1 = art.Precio_oferta * p_cantidad;
                                                        double c2 = art.Precio_oferta * p_cantidad;
                                                        linPedEN.Precio += c1;
                                                        ped.Total += c2;
                                                }
                                                else{
                                                        float c1 = art.Precio * p_cantidad;
                                                        double c2 = art.Precio * p_cantidad;
                                                        linPedEN.Precio += c1;
                                                        ped.Total += c2;
                                                }
                                        }
                                        if (res < cant) {
                                                if (res > 0) {
                                                        linPedEN.Cantidad += p_cantidad;
                                                        float camf = p_cantidad;
                                                        double camd = p_cantidad;

                                                        if (art.Promocion == true) {
                                                                float c1 = art.Precio_oferta * camf;
                                                                double c2 = art.Precio_oferta * camd;
                                                                linPedEN.Precio += c1;
                                                                ped.Total += c2;
                                                        }
                                                        else{
                                                                float c1 = art.Precio * camf;
                                                                double c2 = art.Precio * camd;
                                                                linPedEN.Precio += c1;
                                                                ped.Total += c2;
                                                        }
                                                }
                                                if (res == 0) {
                                                        linPedEN.Precio = 0;
                                                        ped.Total = 0;
                                                }
                                        }
                                }
                        }
                }
                else{
                        VarianteCEN varianteCEN = new VarianteCEN (CPSession.UnitRepo.VarianteRepository);
                        linPedEN.Variante = varianteCEN.DamePorId (p_variante);
                }


                //linPedCEN.get_IKlerenRepository ().Modificar (linPedEN);


                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
