

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class AvisoStockCEN
 *
 */
public partial class AvisoStockCEN
{
private IAvisoStockRepository _IAvisoStockRepository;

public AvisoStockCEN(IAvisoStockRepository _IAvisoStockRepository)
{
        this._IAvisoStockRepository = _IAvisoStockRepository;
}

public IAvisoStockRepository get_IAvisoStockRepository ()
{
        return this._IAvisoStockRepository;
}

public void Modificar (int p_AvisoStock_OID, string p_email, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum p_estado)
{
        AvisoStockEN avisoStockEN = null;

        //Initialized AvisoStockEN
        avisoStockEN = new AvisoStockEN ();
        avisoStockEN.AvisoId = p_AvisoStock_OID;
        avisoStockEN.Email = p_email;
        avisoStockEN.Estado = p_estado;
        //Call to AvisoStockRepository

        _IAvisoStockRepository.Modificar (avisoStockEN);
}

public void Borrar (int avisoId
                    )
{
        _IAvisoStockRepository.Borrar (avisoId);
}

public AvisoStockEN DamePorId (int avisoId
                               )
{
        AvisoStockEN avisoStockEN = null;

        avisoStockEN = _IAvisoStockRepository.DamePorId (avisoId);
        return avisoStockEN;
}

public System.Collections.Generic.IList<AvisoStockEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<AvisoStockEN> list = null;

        list = _IAvisoStockRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> DamePorVarianteYEstado (int p_variante, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum ? p_estado)
{
        return _IAvisoStockRepository.DamePorVarianteYEstado (p_variante, p_estado);
}
}
}
