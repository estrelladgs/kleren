
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Articulo_dameArticulosFiltrados) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class ArticuloCP : GenericBasicCP
{
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosFiltrados (System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> p_articulos, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ColorEN> p_colores, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.MaterialEN> p_materiales, float p_precio_min, float p_precio_max)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Articulo_dameArticulosFiltrados) ENABLED START*/

        ArticuloCEN articuloCEN = null;
        ColorCEN colorCEN = null;

        IList<ArticuloEN> articulos = null;


        try
        {
                CPSession.SessionInitializeTransaction ();

                articuloCEN = new ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                colorCEN = new ColorCEN (CPSession.UnitRepo.ColorRepository);

                IList<ArticuloEN> articulosFiltrados = new List<ArticuloEN>();
                Boolean cumpleCriterioPrecioMin = false;
                Boolean cumpleCriterioPrecioMax = false;
                Boolean cumpleCriterioColor = false;
                Boolean cumpleCriterioMaterial = false;


                // Recorremos todos los articulos pasados por parametro

                foreach (ArticuloEN articulo in p_articulos) {
                        // Filtrar por precio minimo ( p_precio_min == -1 si no hay precio minimo )

                        if (p_precio_min == -1 || articulo.Precio >= p_precio_min) {
                                cumpleCriterioPrecioMin = true;
                        }

                        // Filtrar por precio maximo ( p_precio_max == -1 si no hay precio maximo )

                        if (p_precio_max == -1 || articulo.Precio <= p_precio_max) {
                                cumpleCriterioPrecioMax = true;
                        }

                        // Filtrar por colores ( p_colores.Count == 0 si no hay colores )

                        if (p_colores.Count == 0) {
                                cumpleCriterioColor = true;
                        }
                        else if (p_colores.Count > 0) {
                                foreach (VarianteEN variante in articulo.Variante) {
                                }
                        }



                        CPSession.Commit ();
                }
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
        return articulos;


        /*PROTECTED REGION END*/
}
}
}
