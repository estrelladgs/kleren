
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IComposicionRepository
{
void setSessionCP (GenericSessionCP session);

ComposicionEN ReadOIDDefault (int composicionId
                              );

void ModifyDefault (ComposicionEN composicion);

System.Collections.Generic.IList<ComposicionEN> ReadAllDefault (int first, int size);



int Nueva (ComposicionEN composicion);

void Modificar (ComposicionEN composicion);


void Borrar (int composicionId
             );


ComposicionEN DamePorId (int composicionId
                         );


System.Collections.Generic.IList<ComposicionEN> DameTodos (int first, int size);


void AsociarArticulo (int p_Composicion_OID, int p_articulo_OID);
}
}
