

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ColorCEN
 *
 */
public partial class ColorCEN
{
private IColorRepository _IColorRepository;

public ColorCEN(IColorRepository _IColorRepository)
{
        this._IColorRepository = _IColorRepository;
}

public IColorRepository get_IColorRepository ()
{
        return this._IColorRepository;
}

public int Nuevo (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum p_nombre, string p_codigo)
{
        ColorEN colorEN = null;
        int oid;

        //Initialized ColorEN
        colorEN = new ColorEN ();
        colorEN.Nombre = p_nombre;

        colorEN.Codigo = p_codigo;



        oid = _IColorRepository.Nuevo (colorEN);
        return oid;
}

public void Modificar (int p_Color_OID, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum p_nombre, string p_codigo)
{
        ColorEN colorEN = null;

        //Initialized ColorEN
        colorEN = new ColorEN ();
        colorEN.ColorId = p_Color_OID;
        colorEN.Nombre = p_nombre;
        colorEN.Codigo = p_codigo;
        //Call to ColorRepository

        _IColorRepository.Modificar (colorEN);
}

public void Borrar (int colorId
                    )
{
        _IColorRepository.Borrar (colorId);
}

public ColorEN DamePorId (int colorId
                          )
{
        ColorEN colorEN = null;

        colorEN = _IColorRepository.DamePorId (colorId);
        return colorEN;
}

public System.Collections.Generic.IList<ColorEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ColorEN> list = null;

        list = _IColorRepository.DameTodos (first, size);
        return list;
}
}
}
