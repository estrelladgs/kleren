
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IDirEnvioRepository
{
void setSessionCP (GenericSessionCP session);

DirEnvioEN ReadOIDDefault (int dirEnvioId
                           );

void ModifyDefault (DirEnvioEN dirEnvio);

System.Collections.Generic.IList<DirEnvioEN> ReadAllDefault (int first, int size);



int Nueva (DirEnvioEN dirEnvio);

void Modificar (DirEnvioEN dirEnvio);


void Borrar (int dirEnvioId
             );


DirEnvioEN DamePorId (int dirEnvioId
                      );


System.Collections.Generic.IList<DirEnvioEN> DameTodos (int first, int size);
}
}
