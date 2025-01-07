

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class TallaCEN
 *
 */
public partial class TallaCEN
{
private ITallaRepository _ITallaRepository;

public TallaCEN(ITallaRepository _ITallaRepository)
{
        this._ITallaRepository = _ITallaRepository;
}

public ITallaRepository get_ITallaRepository ()
{
        return this._ITallaRepository;
}

public int NuevaTalla (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla)
{
        TallaEN tallaEN = null;
        int oid;

        //Initialized TallaEN
        tallaEN = new TallaEN ();
        tallaEN.Talla = p_talla;



        oid = _ITallaRepository.NuevaTalla (tallaEN);
        return oid;
}

public void ModficarTalla (int p_Talla_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla)
{
        TallaEN tallaEN = null;

        //Initialized TallaEN
        tallaEN = new TallaEN ();
        tallaEN.TallaId = p_Talla_OID;
        tallaEN.Talla = p_talla;
        //Call to TallaRepository

        _ITallaRepository.ModficarTalla (tallaEN);
}

public void BorrarTalla (int tallaId
                         )
{
        _ITallaRepository.BorrarTalla (tallaId);
}

public TallaEN DamePorId (int tallaId
                          )
{
        TallaEN tallaEN = null;

        tallaEN = _ITallaRepository.DamePorId (tallaId);
        return tallaEN;
}

public System.Collections.Generic.IList<TallaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<TallaEN> list = null;

        list = _ITallaRepository.DameTodos (first, size);
        return list;
}
}
}
