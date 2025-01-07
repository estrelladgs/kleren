
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IVarianteRepository
{
void setSessionCP (GenericSessionCP session);

VarianteEN ReadOIDDefault (int varianteId
                           );

void ModifyDefault (VarianteEN variante);

System.Collections.Generic.IList<VarianteEN> ReadAllDefault (int first, int size);



int Nueva (VarianteEN variante);

void Modificar (VarianteEN variante);


void Borrar (int varianteId
             );


VarianteEN DamePorId (int varianteId
                      );


System.Collections.Generic.IList<VarianteEN> DameTodos (int first, int size);


KlerenGen.ApplicationCore.EN.Kleren.VarianteEN DamePorTallaYColorYArticulo (int p_talla, int p_color, int p_articulo);
}
}
