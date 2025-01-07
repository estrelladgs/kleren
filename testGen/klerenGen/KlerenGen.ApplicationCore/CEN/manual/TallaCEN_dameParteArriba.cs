
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Talla_dameParteArriba) ENABLED START*/
//  references to other libraries
using KlerenGen.ApplicationCore.Enumerated.Kleren;
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class TallaCEN
{
public KlerenGen.ApplicationCore.EN.Kleren.ParteArribaEN DameParteArriba (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_enum)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Talla_dameParteArriba) ENABLED START*/

        // M�todo para devolver la talla correspondiente en ParteArribaEN
        try
        {
                // Crear objeto ParteArribaEN y asignar medidas seg�n la talla (p_enum)
                ParteArribaEN parteArriba = new ParteArribaEN ();

                // Asignar valores espec�ficos de medidas para cada talla
                switch (p_enum) {
                case TallasEnum.XS:
                        parteArriba.Pecho = 80;
                        parteArriba.Hombros = 36;
                        parteArriba.Largo = 58;
                        break;

                case TallasEnum.S:
                        parteArriba.Pecho = 84;
                        parteArriba.Hombros = 38;
                        parteArriba.Largo = 60;
                        break;

                case TallasEnum.M:
                        parteArriba.Pecho = 88;
                        parteArriba.Hombros = 40;
                        parteArriba.Largo = 62;
                        break;

                case TallasEnum.L:
                        parteArriba.Pecho = 92;
                        parteArriba.Hombros = 42;
                        parteArriba.Largo = 64;
                        break;

                case TallasEnum.XL:
                        parteArriba.Pecho = 96;
                        parteArriba.Hombros = 44;
                        parteArriba.Largo = 66;
                        break;

                default:
                        throw new ArgumentOutOfRangeException ("Talla no v�lida");
                }

                return parteArriba;
        }
        catch (Exception ex)
        {
                throw new Exception ("Error al obtener la parte superior para la talla proporcionada", ex);
        }

        /*PROTECTED REGION END*/
}
}
}
