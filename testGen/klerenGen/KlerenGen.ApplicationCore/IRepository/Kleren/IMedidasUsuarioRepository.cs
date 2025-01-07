
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IMedidasUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

MedidasUsuarioEN ReadOIDDefault (int medidasUsuarioId
                                 );

void ModifyDefault (MedidasUsuarioEN medidasUsuario);

System.Collections.Generic.IList<MedidasUsuarioEN> ReadAllDefault (int first, int size);



int Nuevo (MedidasUsuarioEN medidasUsuario);

void Modificar (MedidasUsuarioEN medidasUsuario);


void Borrar (int medidasUsuarioId
             );


MedidasUsuarioEN DamePorId (int medidasUsuarioId
                            );


System.Collections.Generic.IList<MedidasUsuarioEN> DameTodos (int first, int size);




KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN DameMedidasUsuario (int p_usuario);
}
}
