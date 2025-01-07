
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_modificarContra) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public void ModificarContra (int p_UsuarioRegistrado_OID, String p_pass)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_modificarContra_customized) START*/

        if (string.IsNullOrEmpty(p_pass))
        {
            throw new ArgumentException("La contraseña no puede estar vacía.", nameof(p_pass));
        }
        UsuarioRegistradoEN usuarioRegistradoEN = null;

        if (usuarioRegistradoEN == null)
        {
            return;
        }

            //Initialized UsuarioRegistradoEN
            usuarioRegistradoEN = new UsuarioRegistradoEN ();
        usuarioRegistradoEN.UsuarioRegistradoId = p_UsuarioRegistrado_OID;
        usuarioRegistradoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        //Call to UsuarioRegistradoRepository

        _IUsuarioRegistradoRepository.Modificar (usuarioRegistradoEN);

        /*PROTECTED REGION END*/
}
}
}
