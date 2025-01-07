
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IImagenResenaRepository
{
void setSessionCP (GenericSessionCP session);

ImagenResenaEN ReadOIDDefault (int imagenResenaId
                               );

void ModifyDefault (ImagenResenaEN imagenResena);

System.Collections.Generic.IList<ImagenResenaEN> ReadAllDefault (int first, int size);



int Nueva (ImagenResenaEN imagenResena);

void Modificar (ImagenResenaEN imagenResena);


void Borrar (int imagenResenaId
             );


ImagenResenaEN DamePorId (int imagenResenaId
                          );


System.Collections.Generic.IList<ImagenResenaEN> DameTodos (int first, int size);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN> DameImagenesPorResena (int p_resena);
}
}
