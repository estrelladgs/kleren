
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_LinPed_nueva) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class LinPedCP : GenericBasicCP
{
public KlerenGen.ApplicationCore.EN.Kleren.LinPedEN Nueva (int p_cantidad, int p_pedido, int p_variante)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_LinPed_nueva) ENABLED START*/

        LinPedCEN linPedCEN = null;

        KlerenGen.ApplicationCore.EN.Kleren.LinPedEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                linPedCEN = new  LinPedCEN (CPSession.UnitRepo.LinPedRepository);

                PedidoCEN pedidoCEN = new PedidoCEN (CPSession.UnitRepo.PedidoRepository);

                VarianteCEN varianteCEN = new VarianteCEN (CPSession.UnitRepo.VarianteRepository);

                ArticuloCEN articuloCEN = new ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);


                int oid;
                //Initialized LinPedEN
                LinPedEN linPedEN;
                linPedEN = new LinPedEN ();
                linPedEN.Cantidad = p_cantidad;


                if (p_pedido != -1) {
                        linPedEN.Pedido = new KlerenGen.ApplicationCore.EN.Kleren.PedidoEN ();
                        linPedEN.Pedido.PedidoId = p_pedido;
                }


                if (p_variante != -1) {
                        linPedEN.Variante = new KlerenGen.ApplicationCore.EN.Kleren.VarianteEN ();
                        linPedEN.Variante.VarianteId = p_variante;
                }

                PedidoEN pedidoEN = pedidoCEN.DamePorId (p_pedido);
                VarianteEN varianteEN = varianteCEN.DamePorId (p_variante);
                ArticuloEN articuloEN = varianteEN.Articulo;

                if (articuloEN.Promocion == true) {
                        linPedEN.Precio = articuloEN.Precio_oferta * p_cantidad;
                }
                else{
                        linPedEN.Precio = articuloEN.Precio * p_cantidad;
                }



                pedidoEN.Total += linPedEN.Cantidad * articuloEN.Precio;

                oid = linPedCEN.get_ILinPedRepository ().Nueva (linPedEN);

                result = linPedCEN.get_ILinPedRepository ().ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
