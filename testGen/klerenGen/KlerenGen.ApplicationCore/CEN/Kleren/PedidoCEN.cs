

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void BorrarPedido (int pedidoId
                          )
{
        _IPedidoRepository.BorrarPedido (pedidoId);
}

public PedidoEN DamePorId (int pedidoId
                           )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.DamePorId (pedidoId);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePedidosPorUsuario (int ? p_IdUsuario)
{
        return _IPedidoRepository.DamePedidosPorUsuario (p_IdUsuario);
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePorEstado (KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum ? p_Estado)
{
        return _IPedidoRepository.DamePorEstado (p_Estado);
}
}
}
