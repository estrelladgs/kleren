
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface ILinPedRepository
{
void setSessionCP (GenericSessionCP session);

LinPedEN ReadOIDDefault (int lineaId
                         );

void ModifyDefault (LinPedEN linPed);

System.Collections.Generic.IList<LinPedEN> ReadAllDefault (int first, int size);



int Nueva (LinPedEN linPed);

void Modificar (LinPedEN linPed);


void Borrar (int lineaId
             );


LinPedEN DamePorId (int lineaId
                    );


System.Collections.Generic.IList<LinPedEN> DameTodos (int first, int size);


KlerenGen.ApplicationCore.EN.Kleren.LinPedEN DamePorPedidoYVariante (int p_variante, int p_pedido);
}
}
