
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IParteAbajoRepository
{
void setSessionCP (GenericSessionCP session);

ParteAbajoEN ReadOIDDefault (int tallaId
                             );

void ModifyDefault (ParteAbajoEN parteAbajo);

System.Collections.Generic.IList<ParteAbajoEN> ReadAllDefault (int first, int size);



int Nuevo (ParteAbajoEN parteAbajo);

void Modificar (ParteAbajoEN parteAbajo);


void Borrar (int tallaId
             );


ParteAbajoEN DamePorId (int tallaId
                        );


System.Collections.Generic.IList<ParteAbajoEN> DameTodos (int first, int size);
}
}
