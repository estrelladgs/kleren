
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public string Login (string p_correo, string p_pass)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_login) ENABLED START*/

        string result = null;
        UsuarioRegistradoEN en = _IUsuarioRegistradoRepository.DamePorCorreo (p_correo);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.UsuarioRegistradoId);

        return result;


        /*PROTECTED REGION END*/
}
}
}
