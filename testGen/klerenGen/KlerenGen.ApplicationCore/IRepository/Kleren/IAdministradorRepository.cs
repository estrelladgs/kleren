
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IAdministradorRepository
{
void setSessionCP (GenericSessionCP session);

AdministradorEN ReadOIDDefault (int adminId
                                );

void ModifyDefault (AdministradorEN administrador);

System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size);



int Nuevo (AdministradorEN administrador);

void Modificar (AdministradorEN administrador);


void Borrar (int adminId
             );


AdministradorEN DamePorId (int adminId
                           );


System.Collections.Generic.IList<AdministradorEN> DameTodos (int first, int size);




KlerenGen.ApplicationCore.EN.Kleren.AdministradorEN DamePorCorreo (string p_correo);
}
}
