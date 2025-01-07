

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ParteAbajoCEN
 *
 */
public partial class ParteAbajoCEN
{
private IParteAbajoRepository _IParteAbajoRepository;

public ParteAbajoCEN(IParteAbajoRepository _IParteAbajoRepository)
{
        this._IParteAbajoRepository = _IParteAbajoRepository;
}

public IParteAbajoRepository get_IParteAbajoRepository ()
{
        return this._IParteAbajoRepository;
}

public int Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla, int p_cintura, int p_cadera, int p_largo)
{
        ParteAbajoEN parteAbajoEN = null;
        int oid;

        //Initialized ParteAbajoEN
        parteAbajoEN = new ParteAbajoEN ();
        parteAbajoEN.Talla = p_talla;

        parteAbajoEN.Cintura = p_cintura;

        parteAbajoEN.Cadera = p_cadera;

        parteAbajoEN.Largo = p_largo;



        oid = _IParteAbajoRepository.Nuevo (parteAbajoEN);
        return oid;
}

public void Modificar (int p_ParteAbajo_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum p_talla, int p_cintura, int p_cadera, int p_largo)
{
        ParteAbajoEN parteAbajoEN = null;

        //Initialized ParteAbajoEN
        parteAbajoEN = new ParteAbajoEN ();
        parteAbajoEN.TallaId = p_ParteAbajo_OID;
        parteAbajoEN.Talla = p_talla;
        parteAbajoEN.Cintura = p_cintura;
        parteAbajoEN.Cadera = p_cadera;
        parteAbajoEN.Largo = p_largo;
        //Call to ParteAbajoRepository

        _IParteAbajoRepository.Modificar (parteAbajoEN);
}

public void Borrar (int tallaId
                    )
{
        _IParteAbajoRepository.Borrar (tallaId);
}

public ParteAbajoEN DamePorId (int tallaId
                               )
{
        ParteAbajoEN parteAbajoEN = null;

        parteAbajoEN = _IParteAbajoRepository.DamePorId (tallaId);
        return parteAbajoEN;
}

public System.Collections.Generic.IList<ParteAbajoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ParteAbajoEN> list = null;

        list = _IParteAbajoRepository.DameTodos (first, size);
        return list;
}
}
}
