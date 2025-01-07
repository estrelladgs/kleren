
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IUsuarioRegistradoRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioRegistradoEN ReadOIDDefault (int usuarioRegistradoId
                                    );

void ModifyDefault (UsuarioRegistradoEN usuarioRegistrado);

System.Collections.Generic.IList<UsuarioRegistradoEN> ReadAllDefault (int first, int size);



int Nuevo (UsuarioRegistradoEN usuarioRegistrado);

void Modificar (UsuarioRegistradoEN usuarioRegistrado);


void Borrar (int usuarioRegistradoId
             );


UsuarioRegistradoEN DamePorId (int usuarioRegistradoId
                               );


System.Collections.Generic.IList<UsuarioRegistradoEN> DameTodos (int first, int size);







KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN DamePorCorreo (string p_correo);


void ModificarContra (UsuarioRegistradoEN usuarioRegistrado);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnListaDeseos (int p_usuario);



string DameTokenPorUsuario (int p_usuario);
}
}
