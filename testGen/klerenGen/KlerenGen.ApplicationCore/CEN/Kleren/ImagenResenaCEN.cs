

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class ImagenResenaCEN
 *
 */
public partial class ImagenResenaCEN
{
private IImagenResenaRepository _IImagenResenaRepository;

public ImagenResenaCEN(IImagenResenaRepository _IImagenResenaRepository)
{
        this._IImagenResenaRepository = _IImagenResenaRepository;
}

public IImagenResenaRepository get_IImagenResenaRepository ()
{
        return this._IImagenResenaRepository;
}

public int Nueva (int p_resena, string p_rutaArchivo, string p_textoAlternativo)
{
        ImagenResenaEN imagenResenaEN = null;
        int oid;

        //Initialized ImagenResenaEN
        imagenResenaEN = new ImagenResenaEN ();

        if (p_resena != -1) {
                // El argumento p_resena -> Property resena es oid = false
                // Lista de oids imagenResenaId
                imagenResenaEN.Resena = new KlerenGen.ApplicationCore.EN.Kleren.ResenaEN ();
                imagenResenaEN.Resena.ResenaId = p_resena;
        }

        imagenResenaEN.RutaArchivo = p_rutaArchivo;

        imagenResenaEN.TextoAlternativo = p_textoAlternativo;



        oid = _IImagenResenaRepository.Nueva (imagenResenaEN);
        return oid;
}

public void Modificar (int p_ImagenResena_OID, string p_rutaArchivo, string p_textoAlternativo)
{
        ImagenResenaEN imagenResenaEN = null;

        //Initialized ImagenResenaEN
        imagenResenaEN = new ImagenResenaEN ();
        imagenResenaEN.ImagenResenaId = p_ImagenResena_OID;
        imagenResenaEN.RutaArchivo = p_rutaArchivo;
        imagenResenaEN.TextoAlternativo = p_textoAlternativo;
        //Call to ImagenResenaRepository

        _IImagenResenaRepository.Modificar (imagenResenaEN);
}

public void Borrar (int imagenResenaId
                    )
{
        _IImagenResenaRepository.Borrar (imagenResenaId);
}

public ImagenResenaEN DamePorId (int imagenResenaId
                                 )
{
        ImagenResenaEN imagenResenaEN = null;

        imagenResenaEN = _IImagenResenaRepository.DamePorId (imagenResenaId);
        return imagenResenaEN;
}

public System.Collections.Generic.IList<ImagenResenaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ImagenResenaEN> list = null;

        list = _IImagenResenaRepository.DameTodos (first, size);
        return list;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN> DameImagenesPorResena (int p_resena)
{
        return _IImagenResenaRepository.DameImagenesPorResena (p_resena);
}
}
}
