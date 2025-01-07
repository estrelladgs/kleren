

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class CuidadoCEN
 *
 */
public partial class CuidadoCEN
{
private ICuidadoRepository _ICuidadoRepository;

public CuidadoCEN(ICuidadoRepository _ICuidadoRepository)
{
        this._ICuidadoRepository = _ICuidadoRepository;
}

public ICuidadoRepository get_ICuidadoRepository ()
{
        return this._ICuidadoRepository;
}

public int Nuevo (string p_nombre)
{
        CuidadoEN cuidadoEN = null;
        int oid;

        //Initialized CuidadoEN
        cuidadoEN = new CuidadoEN ();
        cuidadoEN.Nombre = p_nombre;



        oid = _ICuidadoRepository.Nuevo (cuidadoEN);
        return oid;
}

public void Modificar (int p_Cuidado_OID, string p_nombre)
{
        CuidadoEN cuidadoEN = null;

        //Initialized CuidadoEN
        cuidadoEN = new CuidadoEN ();
        cuidadoEN.CuiadoId = p_Cuidado_OID;
        cuidadoEN.Nombre = p_nombre;
        //Call to CuidadoRepository

        _ICuidadoRepository.Modificar (cuidadoEN);
}

public void Borrar (int cuiadoId
                    )
{
        _ICuidadoRepository.Borrar (cuiadoId);
}

public CuidadoEN DamePorId (int cuiadoId
                            )
{
        CuidadoEN cuidadoEN = null;

        cuidadoEN = _ICuidadoRepository.DamePorId (cuiadoId);
        return cuidadoEN;
}

public System.Collections.Generic.IList<CuidadoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<CuidadoEN> list = null;

        list = _ICuidadoRepository.DameTodos (first, size);
        return list;
}
}
}
