
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Articulo_dameTallasDelArticulo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class ArticuloCP : GenericBasicCP
{
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.TallaEN> DameTallasDelArticulo (int p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Articulo_dameTallasDelArticulo) ENABLED START*/

        ArticuloCEN articuloCEN = null;

        IList<TallaEN> tallas = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                articuloCEN = new  ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                ArticuloEN articuloEN = articuloCEN.DamePorId (p_oid);

                HashSet<TallaEN> tallasDiferentes = new HashSet<TallaEN>(); //se usa HashSet para evitar duplicados

                foreach (VarianteEN variante in articuloEN.Variante) {
                        tallasDiferentes.Add (variante.Talla);
                }

                tallas = new List<TallaEN>(tallasDiferentes); //se pasa el HashSet a un IList

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
        return tallas;



        /*PROTECTED REGION END*/
}
}
}
