
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IListaDeseosRepository
{
void setSessionCP (GenericSessionCP session);

ListaDeseosEN ReadOIDDefault (int listaDeseosID
                              );

void ModifyDefault (ListaDeseosEN listaDeseos);

System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size);



int Nuevo (ListaDeseosEN listaDeseos);

void Modificar (ListaDeseosEN listaDeseos);


void Borrar (int listaDeseosID
             );


ListaDeseosEN DamePorId (int listaDeseosID
                         );


System.Collections.Generic.IList<ListaDeseosEN> DameTodos (int first, int size);


KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN DameListaDeDeseos (int p_usuario, int p_articulo);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> DameListaDeseosPorUsuarioYArticulo (int p_usuario, int p_articulo);
}
}
