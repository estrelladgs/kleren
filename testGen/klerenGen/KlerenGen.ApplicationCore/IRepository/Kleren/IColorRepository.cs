
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IColorRepository
{
void setSessionCP (GenericSessionCP session);

ColorEN ReadOIDDefault (int colorId
                        );

void ModifyDefault (ColorEN color);

System.Collections.Generic.IList<ColorEN> ReadAllDefault (int first, int size);



int Nuevo (ColorEN color);

void Modificar (ColorEN color);


void Borrar (int colorId
             );


ColorEN DamePorId (int colorId
                   );


System.Collections.Generic.IList<ColorEN> DameTodos (int first, int size);
}
}
