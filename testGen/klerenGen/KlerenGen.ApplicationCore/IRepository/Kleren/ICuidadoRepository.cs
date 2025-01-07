
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface ICuidadoRepository
{
void setSessionCP (GenericSessionCP session);

CuidadoEN ReadOIDDefault (int cuiadoId
                          );

void ModifyDefault (CuidadoEN cuidado);

System.Collections.Generic.IList<CuidadoEN> ReadAllDefault (int first, int size);



int Nuevo (CuidadoEN cuidado);

void Modificar (CuidadoEN cuidado);


void Borrar (int cuiadoId
             );


CuidadoEN DamePorId (int cuiadoId
                     );


System.Collections.Generic.IList<CuidadoEN> DameTodos (int first, int size);
}
}
