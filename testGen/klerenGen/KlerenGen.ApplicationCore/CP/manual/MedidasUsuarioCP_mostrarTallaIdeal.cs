
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_MedidasUsuario_mostrarTallaIdeal) ENABLED START*/
using KlerenGen.ApplicationCore.Enumerated;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class MedidasUsuarioCP : GenericBasicCP
{
public string MostrarTallaIdeal (int p_oid, int p_articulo)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_MedidasUsuario_mostrarTallaIdeal) ENABLED START*/

        MedidasUsuarioCEN medidasUsuarioCEN = null;

        ArticuloEN articuloEN = null;

        string tallaIdeal = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                medidasUsuarioCEN = new MedidasUsuarioCEN (CPSession.UnitRepo.MedidasUsuarioRepository);


                MedidasUsuarioEN medidasUsuarioEN = medidasUsuarioCEN.DamePorId (p_oid);

                if (medidasUsuarioEN == null) {
                        throw new Exception ("Medidas de usuario no encontradas");
                }

                // Obtener la entidad Articulo
                ArticuloCEN articuloCEN = new ArticuloCEN (CPSession.UnitRepo.ArticuloRepository);
                articuloEN = articuloCEN.DamePorId (p_articulo);

                if (articuloEN == null) {
                        throw new Exception ("Articulo no encontrado");
                }



                // Comprobar si el articulo es parte superior o inferior
                if (articuloEN.Parte == Enumerated.Kleren.PartesEnum.arriba) {
                        tallaIdeal = medidasUsuarioEN.TallaIdealSuperior;
                }
                else if (articuloEN.Parte == Enumerated.Kleren.PartesEnum.abajo) {
                        tallaIdeal = medidasUsuarioEN.TallaIdealInferior;
                }
                else{
                        throw new Exception ("El tipo de articulo no esta definido.");
                }

                return tallaIdeal;
        }
        catch (Exception ex)
        {
                throw new Exception ("Error al mostrar la talla ideal: " + ex.Message);
        }


        /*PROTECTED REGION END*/
}
}
}
