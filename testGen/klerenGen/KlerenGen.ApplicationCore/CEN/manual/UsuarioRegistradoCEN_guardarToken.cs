
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_guardarToken) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public void GuardarToken (int p_usuario, string p_token)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_guardarToken) ENABLED START*/

        UsuarioRegistradoEN usuarioRegistradoEN = _IUsuarioRegistradoRepository.DamePorId (p_usuario);

        usuarioRegistradoEN.TokenCompartido = p_token;

        _IUsuarioRegistradoRepository.ModifyDefault (usuarioRegistradoEN);

        /*PROTECTED REGION END*/
}
}
}
