

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ComposicionCEN
 *
 */
public partial class ComposicionCEN
{
private IComposicionRepository _IComposicionRepository;

public ComposicionCEN(IComposicionRepository _IComposicionRepository)
{
        this._IComposicionRepository = _IComposicionRepository;
}

public IComposicionRepository get_IComposicionRepository ()
{
        return this._IComposicionRepository;
}

public int Nueva ()
{
        ComposicionEN composicionEN = null;
        int oid;

        //Initialized ComposicionEN
        composicionEN = new ComposicionEN ();


        oid = _IComposicionRepository.Nueva (composicionEN);
        return oid;
}

public void Modificar (int p_Composicion_OID)
{
        ComposicionEN composicionEN = null;

        //Initialized ComposicionEN
        composicionEN = new ComposicionEN ();
        composicionEN.ComposicionId = p_Composicion_OID;
        //Call to ComposicionRepository

        _IComposicionRepository.Modificar (composicionEN);
}

public void Borrar (int composicionId
                    )
{
        _IComposicionRepository.Borrar (composicionId);
}

public ComposicionEN DamePorId (int composicionId
                                )
{
        ComposicionEN composicionEN = null;

        composicionEN = _IComposicionRepository.DamePorId (composicionId);
        return composicionEN;
}

public System.Collections.Generic.IList<ComposicionEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ComposicionEN> list = null;

        list = _IComposicionRepository.DameTodos (first, size);
        return list;
}
public void AsociarArticulo (int p_Composicion_OID, int p_articulo_OID)
{
        //Call to ComposicionRepository

        _IComposicionRepository.AsociarArticulo (p_Composicion_OID, p_articulo_OID);
}
}
}
