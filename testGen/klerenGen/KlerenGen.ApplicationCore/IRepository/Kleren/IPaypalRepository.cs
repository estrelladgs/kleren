
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IPaypalRepository
{
void setSessionCP (GenericSessionCP session);

PaypalEN ReadOIDDefault (int metodoId
                         );

void ModifyDefault (PaypalEN paypal);

System.Collections.Generic.IList<PaypalEN> ReadAllDefault (int first, int size);



int Nuevo (PaypalEN paypal);

void Modificar (PaypalEN paypal);


void Borrar (int metodoId
             );


PaypalEN DamePorId (int metodoId
                    );


System.Collections.Generic.IList<PaypalEN> DameTodos (int first, int size);
}
}
