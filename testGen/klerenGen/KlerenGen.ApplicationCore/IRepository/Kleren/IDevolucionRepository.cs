
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IDevolucionRepository
{
void setSessionCP (GenericSessionCP session);

DevolucionEN ReadOIDDefault (int devolucionId
                             );

void ModifyDefault (DevolucionEN devolucion);

System.Collections.Generic.IList<DevolucionEN> ReadAllDefault (int first, int size);



int Nueva (DevolucionEN devolucion);

void Modificar (DevolucionEN devolucion);


void Eliminar (int devolucionId
               );



DevolucionEN DamePorId (int devolucionId
                        );


System.Collections.Generic.IList<DevolucionEN> DameTodos (int first, int size);
}
}
