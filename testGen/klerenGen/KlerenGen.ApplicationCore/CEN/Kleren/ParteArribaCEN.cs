

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ParteArribaCEN
 *
 */
public partial class ParteArribaCEN
{
private IParteArribaRepository _IParteArribaRepository;

public ParteArribaCEN(IParteArribaRepository _IParteArribaRepository)
{
        this._IParteArribaRepository = _IParteArribaRepository;
}

public IParteArribaRepository get_IParteArribaRepository ()
{
        return this._IParteArribaRepository;
}

public int Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla, int p_pecho, int p_largo, int p_hombros)
{
        ParteArribaEN parteArribaEN = null;
        int oid;

        //Initialized ParteArribaEN
        parteArribaEN = new ParteArribaEN ();
        parteArribaEN.Talla = p_talla;

        parteArribaEN.Pecho = p_pecho;

        parteArribaEN.Largo = p_largo;

        parteArribaEN.Hombros = p_hombros;



        oid = _IParteArribaRepository.Nuevo (parteArribaEN);
        return oid;
}

public void Modificar (int p_ParteArriba_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla, int p_pecho, int p_largo, int p_hombros)
{
        ParteArribaEN parteArribaEN = null;

        //Initialized ParteArribaEN
        parteArribaEN = new ParteArribaEN ();
        parteArribaEN.TallaId = p_ParteArriba_OID;
        parteArribaEN.Talla = p_talla;
        parteArribaEN.Pecho = p_pecho;
        parteArribaEN.Largo = p_largo;
        parteArribaEN.Hombros = p_hombros;
        //Call to ParteArribaRepository

        _IParteArribaRepository.Modificar (parteArribaEN);
}

public void Borrar (int tallaId
                    )
{
        _IParteArribaRepository.Borrar (tallaId);
}

public ParteArribaEN DamePorId (int tallaId
                                )
{
        ParteArribaEN parteArribaEN = null;

        parteArribaEN = _IParteArribaRepository.DamePorId (tallaId);
        return parteArribaEN;
}

public System.Collections.Generic.IList<ParteArribaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ParteArribaEN> list = null;

        list = _IParteArribaRepository.DameTodos (first, size);
        return list;
}
}
}
