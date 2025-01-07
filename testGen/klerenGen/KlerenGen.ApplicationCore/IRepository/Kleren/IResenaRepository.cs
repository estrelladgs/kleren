
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IResenaRepository
{
void setSessionCP (GenericSessionCP session);

ResenaEN ReadOIDDefault (int resenaId
                         );

void ModifyDefault (ResenaEN resena);

System.Collections.Generic.IList<ResenaEN> ReadAllDefault (int first, int size);



int Nueva (ResenaEN resena);

void Modificar (ResenaEN resena);


void Borrar (int resenaId
             );


ResenaEN DamePorId (int resenaId
                    );


System.Collections.Generic.IList<ResenaEN> DameTodos (int first, int size);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> DameResenasPorArticulo (int p_articulo);
}
}
