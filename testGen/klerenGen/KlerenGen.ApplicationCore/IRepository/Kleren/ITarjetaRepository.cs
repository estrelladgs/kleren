
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface ITarjetaRepository
{
void setSessionCP (GenericSessionCP session);

TarjetaEN ReadOIDDefault (int metodoId
                          );

void ModifyDefault (TarjetaEN tarjeta);

System.Collections.Generic.IList<TarjetaEN> ReadAllDefault (int first, int size);



int Nueva (TarjetaEN tarjeta);

void Modificar (TarjetaEN tarjeta);


void Borrar (int metodoId
             );


TarjetaEN DamePorId (int metodoId
                     );


System.Collections.Generic.IList<TarjetaEN> DameTodos (int first, int size);
}
}
