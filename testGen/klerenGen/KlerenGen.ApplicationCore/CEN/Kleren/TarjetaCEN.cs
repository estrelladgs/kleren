

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class TarjetaCEN
 *
 */
public partial class TarjetaCEN
{
private ITarjetaRepository _ITarjetaRepository;

public TarjetaCEN(ITarjetaRepository _ITarjetaRepository)
{
        this._ITarjetaRepository = _ITarjetaRepository;
}

public ITarjetaRepository get_ITarjetaRepository ()
{
        return this._ITarjetaRepository;
}

public int Nueva (string p_tarjetaId)
{
        TarjetaEN tarjetaEN = null;
        int oid;

        //Initialized TarjetaEN
        tarjetaEN = new TarjetaEN ();
        tarjetaEN.TarjetaId = p_tarjetaId;



        oid = _ITarjetaRepository.Nueva (tarjetaEN);
        return oid;
}

public void Modificar (int p_Tarjeta_OID, string p_tarjetaId)
{
        TarjetaEN tarjetaEN = null;

        //Initialized TarjetaEN
        tarjetaEN = new TarjetaEN ();
        tarjetaEN.MetodoId = p_Tarjeta_OID;
        tarjetaEN.TarjetaId = p_tarjetaId;
        //Call to TarjetaRepository

        _ITarjetaRepository.Modificar (tarjetaEN);
}

public void Borrar (int metodoId
                    )
{
        _ITarjetaRepository.Borrar (metodoId);
}

public TarjetaEN DamePorId (int metodoId
                            )
{
        TarjetaEN tarjetaEN = null;

        tarjetaEN = _ITarjetaRepository.DamePorId (metodoId);
        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> list = null;

        list = _ITarjetaRepository.DameTodos (first, size);
        return list;
}
}
}
