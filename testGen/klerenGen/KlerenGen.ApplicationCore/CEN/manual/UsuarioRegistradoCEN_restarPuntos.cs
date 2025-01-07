
using System;
using System.Text;
using System.Collections.Generic;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


/*PROTECTED REGION ID(usingKlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_restarPuntos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace KlerenGen.ApplicationCore.CEN.Kleren
{
public partial class UsuarioRegistradoCEN
{
public bool RestarPuntos (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(KlerenGen.ApplicationCore.CEN.Kleren_UsuarioRegistrado_restarPuntos) ENABLED START*/

        bool restar = false;

        UsuarioRegistradoEN usuarioEN = _IUsuarioRegistradoRepository.DamePorId (p_oid);

        if (usuarioEN.Puntos >= p_cantidad) {
                usuarioEN.Puntos -= p_cantidad;
                _IUsuarioRegistradoRepository.ModifyDefault (usuarioEN);
                restar = true;
        }

        return restar;

        /*PROTECTED REGION END*/
}
}
}
