

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class MetodoPagoCEN
 *
 */
public partial class MetodoPagoCEN
{
private IMetodoPagoRepository _IMetodoPagoRepository;

public MetodoPagoCEN(IMetodoPagoRepository _IMetodoPagoRepository)
{
        this._IMetodoPagoRepository = _IMetodoPagoRepository;
}

public IMetodoPagoRepository get_IMetodoPagoRepository ()
{
        return this._IMetodoPagoRepository;
}

public int Nuevo ()
{
        MetodoPagoEN metodoPagoEN = null;
        int oid;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();


        oid = _IMetodoPagoRepository.Nuevo (metodoPagoEN);
        return oid;
}

public void Modificar (int p_MetodoPago_OID)
{
        MetodoPagoEN metodoPagoEN = null;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.MetodoId = p_MetodoPago_OID;
        //Call to MetodoPagoRepository

        _IMetodoPagoRepository.Modificar (metodoPagoEN);
}

public void Borrar (int metodoId
                    )
{
        _IMetodoPagoRepository.Borrar (metodoId);
}

public MetodoPagoEN DamePorId (int metodoId
                               )
{
        MetodoPagoEN metodoPagoEN = null;

        metodoPagoEN = _IMetodoPagoRepository.DamePorId (metodoId);
        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> list = null;

        list = _IMetodoPagoRepository.DameTodos (first, size);
        return list;
}
}
}
