
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IMetodoPagoRepository
{
void setSessionCP (GenericSessionCP session);

MetodoPagoEN ReadOIDDefault (int metodoId
                             );

void ModifyDefault (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size);



int Nuevo (MetodoPagoEN metodoPago);

void Modificar (MetodoPagoEN metodoPago);


void Borrar (int metodoId
             );


MetodoPagoEN DamePorId (int metodoId
                        );


System.Collections.Generic.IList<MetodoPagoEN> DameTodos (int first, int size);
}
}
