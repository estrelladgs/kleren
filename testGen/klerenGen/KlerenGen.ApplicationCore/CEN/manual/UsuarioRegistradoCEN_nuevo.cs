
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_nuevo) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public int Nuevo (string p_nombre, string p_apellidos, string p_correo, string p_telefono, Nullable<DateTime> p_fecha_nac, String p_pass, int p_puntos)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_nuevo_customized) ENABLED START*/

        UsuarioRegistradoEN usuarioRegistradoEN = null;

        int oid;

        //Initialized UsuarioRegistradoEN
        usuarioRegistradoEN = new UsuarioRegistradoEN ();
        usuarioRegistradoEN.Nombre = p_nombre;

        usuarioRegistradoEN.Apellidos = p_apellidos;

        usuarioRegistradoEN.Correo = p_correo;

        usuarioRegistradoEN.Telefono = p_telefono;

        usuarioRegistradoEN.Fecha_nac = p_fecha_nac;

        usuarioRegistradoEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);

        usuarioRegistradoEN.Puntos = p_puntos;

        usuarioRegistradoEN.TokenCompartido = null;

        //Call to UsuarioRegistradoRepository

        oid = _IUsuarioRegistradoRepository.Nuevo (usuarioRegistradoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
