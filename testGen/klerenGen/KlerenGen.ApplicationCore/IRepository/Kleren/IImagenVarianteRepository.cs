
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IImagenVarianteRepository
{
void setSessionCP (GenericSessionCP session);

ImagenVarianteEN ReadOIDDefault (int imagenVarianteId
                                 );

void ModifyDefault (ImagenVarianteEN imagenVariante);

System.Collections.Generic.IList<ImagenVarianteEN> ReadAllDefault (int first, int size);



int Nueva (ImagenVarianteEN imagenVariante);

void Modificar (ImagenVarianteEN imagenVariante);


void Borrar (int imagenVarianteId
             );


ImagenVarianteEN DamePorId (int imagenVarianteId
                            );


System.Collections.Generic.IList<ImagenVarianteEN> DameTodos (int first, int size);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN> DameImagenesPorVariante ();


void AsociarAVariante (int p_ImagenVariante_OID, System.Collections.Generic.IList<int> p_variante_OIDs);
}
}
