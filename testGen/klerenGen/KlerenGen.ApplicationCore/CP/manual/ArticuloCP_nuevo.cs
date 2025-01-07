
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Articulo_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class ArticuloCP : GenericBasicCP
{
public KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN Nuevo (float p_precio, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum p_categoria, KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum p_sexo, bool p_promocion, float p_precio_oferta, string p_nombre, string p_trazabilidad, KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum p_parte, int p_stock_inicial)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Articulo_nuevo) ENABLED START*/

        ArticuloCEN articuloCEN = null;

        KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articuloENCreado = null;


        try
        {
                CPSession.SessionInitializeTransaction ();

                articuloCEN = new  ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                VarianteCEN varianteCEN = new  VarianteCEN (CPSession.UnitRepo.VarianteRepository);
                ColorCEN colorCEN = new  ColorCEN (CPSession.UnitRepo.ColorRepository);
                TallaCEN tallaCEN = new  TallaCEN (CPSession.UnitRepo.TallaRepository);

                int oidArticuloCreado;

                ArticuloEN articuloEN;
                articuloEN = new ArticuloEN ();
                articuloEN.Precio = p_precio;
                articuloEN.Categoria = p_categoria;
                articuloEN.Sexo = p_sexo;
                articuloEN.Promocion = p_promocion;
                articuloEN.Precio_oferta = p_precio_oferta;
                articuloEN.Nombre = p_nombre;
                articuloEN.Trazabilidad = p_trazabilidad;
                articuloEN.Parte = p_parte;

                // Crear articulo
                oidArticuloCreado = articuloCEN.get_IArticuloRepository ().Nuevo (articuloEN);
                articuloENCreado = articuloCEN.get_IArticuloRepository ().ReadOIDDefault (oidArticuloCreado);

                // Obtener todos los colores existentes
                IList<ColorEN> coloresEN = colorCEN.get_IColorRepository ().DameTodos (0, -1);

                // Obtener todas las tallas existentes
                IList<TallaEN> tallasEN = tallaCEN.get_ITallaRepository ().DameTodos (0, -1);

                // Crear las variantes del articulo con todas las posibles combinaciones de color y talla existenes
                foreach (ColorEN colorEN in coloresEN) {
                        foreach (TallaEN tallaEN in tallasEN) {
                                varianteCEN.Nueva (p_stock_inicial, oidArticuloCreado, tallaEN.TallaId, colorEN.ColorId);
                        }
                }

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
        return articuloENCreado;


        /*PROTECTED REGION END*/
}
}
}
