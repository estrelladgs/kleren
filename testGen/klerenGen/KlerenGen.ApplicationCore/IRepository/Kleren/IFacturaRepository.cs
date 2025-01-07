
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IFacturaRepository
{
void setSessionCP (GenericSessionCP session);

FacturaEN ReadOIDDefault (int facturaId
                          );

void ModifyDefault (FacturaEN factura);

System.Collections.Generic.IList<FacturaEN> ReadAllDefault (int first, int size);



int Nueva (FacturaEN factura);

void Modificar (FacturaEN factura);


void Borrar (int facturaId
             );


FacturaEN DamePorId (int facturaId
                     );


System.Collections.Generic.IList<FacturaEN> DameTodos (int first, int size);
}
}
