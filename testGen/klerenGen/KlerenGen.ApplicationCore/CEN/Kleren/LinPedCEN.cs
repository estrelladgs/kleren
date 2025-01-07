

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class LinPedCEN
 *
 */
public partial class LinPedCEN
{
private ILinPedRepository _ILinPedRepository;

public LinPedCEN(ILinPedRepository _ILinPedRepository)
{
        this._ILinPedRepository = _ILinPedRepository;
}

public ILinPedRepository get_ILinPedRepository ()
{
        return this._ILinPedRepository;
}

public void Borrar (int lineaId
                    )
{
        _ILinPedRepository.Borrar (lineaId);
}

public LinPedEN DamePorId (int lineaId
                           )
{
        LinPedEN linPedEN = null;

        linPedEN = _ILinPedRepository.DamePorId (lineaId);
        return linPedEN;
}

public System.Collections.Generic.IList<LinPedEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<LinPedEN> list = null;

        list = _ILinPedRepository.DameTodos (first, size);
        return list;
}
public KlerenGen.ApplicationCore.EN.Kleren.LinPedEN DamePorPedidoYVariante (int p_variante, int p_pedido)
{
        return _ILinPedRepository.DamePorPedidoYVariante (p_variante, p_pedido);
}
}
}
