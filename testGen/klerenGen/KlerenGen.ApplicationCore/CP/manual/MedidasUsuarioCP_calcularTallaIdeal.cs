
using System;
using System.Text;

using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CEN.Kleren;



/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CP.Kleren_MedidasUsuario_calcularTallaIdeal) ENABLED START*/
using KlerenGen.ApplicationCore.Enumerated.Kleren;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CP.Kleren
{
public partial class MedidasUsuarioCP : GenericBasicCP
{
public KlerenGen.ApplicationCore.EN.Kleren.TallaEN CalcularTallaIdeal (int p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CP.Kleren_MedidasUsuario_calcularTallaIdeal) ENABLED START*/

        MedidasUsuarioCEN medidasUsuarioCEN = null;

        KlerenGen.ApplicationCore.EN.Kleren.TallaEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                medidasUsuarioCEN = new MedidasUsuarioCEN (CPSession.UnitRepo.MedidasUsuarioRepository);

                TallaCEN tallaCEN = new TallaCEN (CPSession.UnitRepo.TallaRepository);

                MedidasUsuarioEN medidasUsuarioEN = medidasUsuarioCEN.DamePorId (p_oid);


                if (medidasUsuarioEN == null) {
                        throw new Exception ("Medidas de usuario no encontrado");
                }

                // Obtener las instancias de ParteArriba y ParteAbajo
                ParteArribaEN parteArribaXS = tallaCEN.DameParteArriba (TallasEnum.XS);
                ParteArribaEN parteArribaS = tallaCEN.DameParteArriba (TallasEnum.S);
                ParteArribaEN parteArribaM = tallaCEN.DameParteArriba (TallasEnum.M);
                ParteArribaEN parteArribaL = tallaCEN.DameParteArriba (TallasEnum.L);
                ParteArribaEN parteArribaXL = tallaCEN.DameParteArriba (TallasEnum.XL);


                ParteAbajoEN parteAbajoXS = tallaCEN.DameParteAbajo (TallasEnum.XS);
                ParteAbajoEN parteAbajoS = tallaCEN.DameParteAbajo (TallasEnum.S);
                ParteAbajoEN parteAbajoM = tallaCEN.DameParteAbajo (TallasEnum.M);
                ParteAbajoEN parteAbajoL = tallaCEN.DameParteAbajo (TallasEnum.L);
                ParteAbajoEN parteAbajoXL = tallaCEN.DameParteAbajo (TallasEnum.XL);

                // Determinar la talla ideal para la parte superior
                medidasUsuarioEN.TallaIdealSuperior = CalcularTallaSuperior (
                        medidasUsuarioEN.Pecho,
                        medidasUsuarioEN.AnchoEspalda,
                        medidasUsuarioEN.LargoBrazo,
                        parteArribaXS, parteArribaS, parteArribaM, parteArribaL, parteArribaXL
                        );

                medidasUsuarioEN.TallaIdealInferior = CalcularTallaInferior (
                        medidasUsuarioEN.Cintura,
                        medidasUsuarioEN.Caderas,
                        medidasUsuarioEN.LargoPierna,
                        parteAbajoXS, parteAbajoS, parteAbajoM, parteAbajoL, parteAbajoXL
                        );

                string CalcularTallaSuperior (int pecho, int anchoEspalda, int largo, ParteArribaEN xs, ParteArribaEN s, ParteArribaEN m, ParteArribaEN l, ParteArribaEN xl)
                {
                        if (pecho <= xs.Pecho && largo <= xs.Largo && anchoEspalda <= xs.Hombros)
                                return "XS";
                        else if (pecho <= s.Pecho && largo <= s.Largo && anchoEspalda <= s.Hombros)
                                return "S";
                        else if (pecho <= m.Pecho && largo <= m.Largo && anchoEspalda <= m.Hombros)
                                return "M";
                        else if (pecho <= l.Pecho && largo <= l.Largo && anchoEspalda <= l.Hombros)
                                return "L";
                        else
                                return "XL";
                }

                string CalcularTallaInferior (int cintura, int cadera, int largoPierna, ParteAbajoEN xs, ParteAbajoEN s, ParteAbajoEN m, ParteAbajoEN l, ParteAbajoEN xl)
                {
                        if (cintura <= xs.Cintura && cadera <= xs.Cadera && largoPierna <= xs.Largo)
                                return "XS";
                        else if (cintura <= s.Cintura && cadera <= s.Cadera && largoPierna <= s.Largo)
                                return "S";
                        else if (cintura <= m.Cintura && cadera <= m.Cadera && largoPierna <= m.Largo)
                                return "M";
                        else if (cintura <= l.Cintura && cadera <= l.Cadera && largoPierna <= l.Largo)
                                return "L";
                        else
                                return "XL";
                }

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
        return result;


        /*PROTECTED REGION END*/
}
}
}
