

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class MaterialCEN
 *
 */
public partial class MaterialCEN
{
private IMaterialRepository _IMaterialRepository;

public MaterialCEN(IMaterialRepository _IMaterialRepository)
{
        this._IMaterialRepository = _IMaterialRepository;
}

public IMaterialRepository get_IMaterialRepository ()
{
        return this._IMaterialRepository;
}

public int Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum p_material)
{
        MaterialEN materialEN = null;
        int oid;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Material = p_material;



        oid = _IMaterialRepository.Nuevo (materialEN);
        return oid;
}

public void Modificar (int p_Material_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum p_material)
{
        MaterialEN materialEN = null;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Id = p_Material_OID;
        materialEN.Material = p_material;
        //Call to MaterialRepository

        _IMaterialRepository.Modificar (materialEN);
}

public void Borrar (int id
                    )
{
        _IMaterialRepository.Borrar (id);
}

public MaterialEN DamePorId (int id
                             )
{
        MaterialEN materialEN = null;

        materialEN = _IMaterialRepository.DamePorId (id);
        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> list = null;

        list = _IMaterialRepository.DameTodos (first, size);
        return list;
}
}
}
