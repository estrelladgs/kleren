
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IParteArribaRepository
{
void setSessionCP (GenericSessionCP session);

ParteArribaEN ReadOIDDefault (int tallaId
                              );

void ModifyDefault (ParteArribaEN parteArriba);

System.Collections.Generic.IList<ParteArribaEN> ReadAllDefault (int first, int size);



int Nuevo (ParteArribaEN parteArriba);

void Modificar (ParteArribaEN parteArriba);


void Borrar (int tallaId
             );


ParteArribaEN DamePorId (int tallaId
                         );


System.Collections.Generic.IList<ParteArribaEN> DameTodos (int first, int size);
}
}
