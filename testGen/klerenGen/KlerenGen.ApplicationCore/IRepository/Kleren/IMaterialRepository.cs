
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IMaterialRepository
{
void setSessionCP (GenericSessionCP session);

MaterialEN ReadOIDDefault (int id
                           );

void ModifyDefault (MaterialEN material);

System.Collections.Generic.IList<MaterialEN> ReadAllDefault (int first, int size);



int Nuevo (MaterialEN material);

void Modificar (MaterialEN material);


void Borrar (int id
             );


MaterialEN DamePorId (int id
                      );


System.Collections.Generic.IList<MaterialEN> DameTodos (int first, int size);
}
}
