
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Talla_dameParteAbajo) ENABLED START*/
//  references to other libraries
using KlerenGen.ApplicationCore.Enumerated.Kleren;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class TallaCEN
{
public KlerenGen.ApplicationCore.EN.Kleren.ParteAbajoEN DameParteAbajo (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Talla_dameParteAbajo) ENABLED START*/

        try
        {
                // Crear objeto ParteAbajoEN y asignar medidas seg�n la talla (p_oid)
                ParteAbajoEN parteAbajo = new ParteAbajoEN ();

                // Asignar valores espec�ficos de medidas para cada talla
                switch (p_oid) {
                case TallasEnum.XS:
                        parteAbajo.Cintura = 64;
                        parteAbajo.Cadera = 88;
                        parteAbajo.Largo = 96;
                        break;

                case TallasEnum.S:
                        parteAbajo.Cintura = 68;
                        parteAbajo.Cadera = 92;
                        parteAbajo.Largo = 98;
                        break;

                case TallasEnum.M:
                        parteAbajo.Cintura = 72;
                        parteAbajo.Cadera = 96;
                        parteAbajo.Largo = 100;
                        break;

                case TallasEnum.L:
                        parteAbajo.Cintura = 76;
                        parteAbajo.Cadera = 100;
                        parteAbajo.Largo = 102;
                        break;

                case TallasEnum.XL:
                        parteAbajo.Cintura = 80;
                        parteAbajo.Cadera = 104;
                        parteAbajo.Largo = 104;
                        break;

                default:
                        throw new ArgumentOutOfRangeException ("Talla no v�lida");
                }

                return parteAbajo;
        }
        catch (Exception ex)
        {
                throw new Exception ("Error al obtener la parte inferior para la talla proporcionada", ex);
        }

/*PROTECTED REGION END*/
}
}
}
