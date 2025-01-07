
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IPorcentajeRepository
{
void setSessionCP (GenericSessionCP session);

PorcentajeEN ReadOIDDefault (int id
                             );

void ModifyDefault (PorcentajeEN porcentaje);

System.Collections.Generic.IList<PorcentajeEN> ReadAllDefault (int first, int size);



int Nuevo (PorcentajeEN porcentaje);

void Modificar (PorcentajeEN porcentaje);


void Borrar (int id
             );


PorcentajeEN DamePorId (int id
                        );


System.Collections.Generic.IList<PorcentajeEN> DameTodos (int first, int size);
}
}
