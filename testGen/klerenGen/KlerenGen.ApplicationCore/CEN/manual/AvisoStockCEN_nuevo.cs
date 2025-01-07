
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_AvisoStock_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class AvisoStockCEN
{
public int Nuevo (int p_variante, string p_email)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_AvisoStock_nuevo_customized) ENABLED START*/

        AvisoStockEN avisoStockEN = null;

        int oid;

        //Initialized AvisoStockEN
        avisoStockEN = new AvisoStockEN ();

        if (p_variante != -1) {
                avisoStockEN.Variante = new KlerenGen.ApplicationCore.EN.Kleren.VarianteEN ();
                avisoStockEN.Variante.VarianteId = p_variante;
        }

        avisoStockEN.Email = p_email;
        avisoStockEN.Estado = Enumerated.Kleren.EstadoAvisoStockEnum.sinEnviar;

        //Call to AvisoStockRepository

        oid = _IAvisoStockRepository.Nuevo (avisoStockEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
