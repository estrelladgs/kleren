

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ImagenVarianteCEN
 *
 */
public partial class ImagenVarianteCEN
{
private IImagenVarianteRepository _IImagenVarianteRepository;

public ImagenVarianteCEN(IImagenVarianteRepository _IImagenVarianteRepository)
{
        this._IImagenVarianteRepository = _IImagenVarianteRepository;
}

public IImagenVarianteRepository get_IImagenVarianteRepository ()
{
        return this._IImagenVarianteRepository;
}

public int Nueva (string p_rutaArchivo, string p_textoAlternativo)
{
        ImagenVarianteEN imagenVarianteEN = null;
        int oid;

        //Initialized ImagenVarianteEN
        imagenVarianteEN = new ImagenVarianteEN ();
        imagenVarianteEN.RutaArchivo = p_rutaArchivo;

        imagenVarianteEN.TextoAlternativo = p_textoAlternativo;



        oid = _IImagenVarianteRepository.Nueva (imagenVarianteEN);
        return oid;
}

public void Modificar (int p_ImagenVariante_OID, string p_rutaArchivo, string p_textoAlternativo)
{
        ImagenVarianteEN imagenVarianteEN = null;

        //Initialized ImagenVarianteEN
        imagenVarianteEN = new ImagenVarianteEN ();
        imagenVarianteEN.ImagenVarianteId = p_ImagenVariante_OID;
        imagenVarianteEN.RutaArchivo = p_rutaArchivo;
        imagenVarianteEN.TextoAlternativo = p_textoAlternativo;
        //Call to ImagenVarianteRepository

        _IImagenVarianteRepository.Modificar (imagenVarianteEN);
}

public void Borrar (int imagenVarianteId
                    )
{
        _IImagenVarianteRepository.Borrar (imagenVarianteId);
}

public ImagenVarianteEN DamePorId (int imagenVarianteId
                                   )
{
        ImagenVarianteEN imagenVarianteEN = null;

        imagenVarianteEN = _IImagenVarianteRepository.DamePorId (imagenVarianteId);
        return imagenVarianteEN;
}

public System.Collections.Generic.IList<ImagenVarianteEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ImagenVarianteEN> list = null;

        list = _IImagenVarianteRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN> DameImagenesPorVariante ()
{
        return _IImagenVarianteRepository.DameImagenesPorVariante ();
}
public void AsociarAVariante (int p_ImagenVariante_OID, System.Collections.Generic.IList<int> p_variante_OIDs)
{
        //Call to ImagenVarianteRepository

        _IImagenVarianteRepository.AsociarAVariante (p_ImagenVariante_OID, p_variante_OIDs);
}
}
}
