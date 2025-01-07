
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_modificar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public void Modificar (string p_nombre, string p_apellidos, string p_correo, string p_telefono, Nullable<DateTime> p_fecha_nac, int p_oid)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_modificar_customized) START*/

        UsuarioRegistradoEN usuarioRegistradoEN = null;

        //Initialized UsuarioRegistradoEN
        usuarioRegistradoEN = new UsuarioRegistradoEN ();
        usuarioRegistradoEN.Nombre = p_nombre;
        usuarioRegistradoEN.Apellidos = p_apellidos;
        usuarioRegistradoEN.Correo = p_correo;
        usuarioRegistradoEN.Telefono = p_telefono;
        usuarioRegistradoEN.Fecha_nac = p_fecha_nac;
        usuarioRegistradoEN.UsuarioRegistradoId = p_oid;
        //Call to UsuarioRegistradoRepository

        _IUsuarioRegistradoRepository.Modificar (usuarioRegistradoEN);

        /*PROTECTED REGION END*/
}
}
}
