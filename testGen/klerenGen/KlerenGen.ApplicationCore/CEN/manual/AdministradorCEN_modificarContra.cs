
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_Administrador_modificarContra) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class AdministradorCEN
{
public void ModificarContra (int p_oid, string pass)
{
            /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_Administrador_modificarContra) ENABLED START*/

            if (string.IsNullOrEmpty(pass))
            {
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(pass));
            }
            AdministradorEN AdminEN = null;

            if (AdminEN == null)
            {
                return;
            }

            //Initialized UsuarioRegistradoEN
            AdminEN = new AdministradorEN();
            AdminEN.AdminId = p_oid;
            AdminEN.Pass = Utils.Util.GetEncondeMD5(pass);
            //Call to UsuarioRegistradoRepository

            _IAdministradorRepository.Modificar(AdminEN);

            /*PROTECTED REGION END*/
        }
}
}
