
using System;
// Definición clase ImagenResenaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ImagenResenaEN
{
/**
 *	Atributo imagenResenaId
 */
private int imagenResenaId;



/**
 *	Atributo resena
 */
private KlerenGen.ApplicationCore.EN.Kleren.ResenaEN resena;



/**
 *	Atributo rutaArchivo
 */
private string rutaArchivo;



/**
 *	Atributo textoAlternativo
 */
private string textoAlternativo;






public virtual int ImagenResenaId {
        get { return imagenResenaId; } set { imagenResenaId = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ResenaEN Resena {
        get { return resena; } set { resena = value;  }
}



public virtual string RutaArchivo {
        get { return rutaArchivo; } set { rutaArchivo = value;  }
}



public virtual string TextoAlternativo {
        get { return textoAlternativo; } set { textoAlternativo = value;  }
}





public ImagenResenaEN()
{
}



public ImagenResenaEN(int imagenResenaId, KlerenGen.ApplicationCore.EN.Kleren.ResenaEN resena, string rutaArchivo, string textoAlternativo
                      )
{
        this.init (ImagenResenaId, resena, rutaArchivo, textoAlternativo);
}


public ImagenResenaEN(ImagenResenaEN imagenResena)
{
        this.init (imagenResena.ImagenResenaId, imagenResena.Resena, imagenResena.RutaArchivo, imagenResena.TextoAlternativo);
}

private void init (int imagenResenaId
                   , KlerenGen.ApplicationCore.EN.Kleren.ResenaEN resena, string rutaArchivo, string textoAlternativo)
{
        this.ImagenResenaId = imagenResenaId;


        this.Resena = resena;

        this.RutaArchivo = rutaArchivo;

        this.TextoAlternativo = textoAlternativo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ImagenResenaEN t = obj as ImagenResenaEN;
        if (t == null)
                return false;
        if (ImagenResenaId.Equals (t.ImagenResenaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ImagenResenaId.GetHashCode ();
        return hash;
}
}
}
