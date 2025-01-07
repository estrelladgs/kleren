
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Articulo_dameColoresDelArticulo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class ArticuloCP : GenericBasicCP
{
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ColorEN> DameColoresDelArticulo (int p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Articulo_dameColoresDelArticulo) ENABLED START*/

        ArticuloCEN articuloCEN = null;

        IList<ColorEN> colores = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                articuloCEN = new  ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                ArticuloEN articuloEN = articuloCEN.DamePorId (p_oid);

                HashSet<ColorEN> coloresDiferentes = new HashSet<ColorEN>(); //se usa HashSet para evitar duplicados

                foreach (VarianteEN variante in articuloEN.Variante) {
                        coloresDiferentes.Add (variante.Color);
                }

                colores = new List<ColorEN>(coloresDiferentes); //se pasa el HashSet a un IList

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
        return colores;


        /*PROTECTED REGION END*/
}
}
}
