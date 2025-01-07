
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int pedidoId
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int Nuevo (PedidoEN pedido);

void Modificar (PedidoEN pedido);


void BorrarPedido (int pedidoId
                   );


PedidoEN DamePorId (int pedidoId
                    );


System.Collections.Generic.IList<PedidoEN> DameTodos (int first, int size);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePedidosPorUsuario (int ? p_IdUsuario);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePorEstado (KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum ? p_Estado);
}
}
