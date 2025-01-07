
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_sumarPuntos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public void SumarPuntos (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_sumarPuntos) ENABLED START*/

        UsuarioRegistradoEN usuarioEN = _IUsuarioRegistradoRepository.DamePorId (p_oid);

        usuarioEN.Puntos += p_cantidad;
        _IUsuarioRegistradoRepository.ModifyDefault (usuarioEN);

        /*PROTECTED REGION END*/
}
}
}
