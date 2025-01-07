
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_Articulo_dameMaterialesDelArticulo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class ArticuloCP : GenericBasicCP
{
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.MaterialEN> DameMaterialesDelArticulo (int p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_Articulo_dameMaterialesDelArticulo) ENABLED START*/

        ArticuloCEN articuloCEN = null;

        IList<MaterialEN> materiales = null;
        Console.WriteLine ("Se llama la funcion");


        try
        {
                CPSession.SessionInitializeTransaction ();
                articuloCEN = new  ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                ArticuloEN articuloEN = articuloCEN.DamePorId (p_oid);
                ComposicionEN composicionEN = articuloEN.Composicion;


                 if (composicionEN == null) {
                      Console.WriteLine ("No hay composición asociada con este artículo.");
                 } else
                 {
                  Console.WriteLine ("Composicion es: " + composicionEN.ComposicionId);
                
                
                  // Comprobación: ¿La composición tiene porcentajes?
                  if (composicionEN.Porcentaje == null) {
                          Console.WriteLine ("La composición no tiene ningún porcentaje asociado.");
                  }


                HashSet<MaterialEN> materialesDiferentes = new HashSet<MaterialEN>(); //se usa HashSet para evitar duplicados

                   foreach (PorcentajeEN porcentaje in composicionEN.Porcentaje) {
                           Console.WriteLine ("Porcentaje es: " + porcentaje.Porcentaje);
                           Console.WriteLine ("El material de ese porcentaje es: " + porcentaje.Material.Material);
                 
                           materialesDiferentes.Add (porcentaje.Material);
                   }
                 
                   materiales = new List<MaterialEN>(materialesDiferentes); //se pasa el HashSet a un IList
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
        return materiales ?? new List<MaterialEN>();


            /*PROTECTED REGION END*/
        }
}
}
