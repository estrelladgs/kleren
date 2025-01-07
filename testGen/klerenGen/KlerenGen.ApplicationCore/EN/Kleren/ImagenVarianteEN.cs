
using System;
// Definición clase ImagenVarianteEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ImagenVarianteEN
{
/**
 *	Atributo imagenVarianteId
 */
private int imagenVarianteId;



/**
 *	Atributo rutaArchivo
 */
private string rutaArchivo;



/**
 *	Atributo variante
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante;



/**
 *	Atributo textoAlternativo
 */
private string textoAlternativo;






public virtual int ImagenVarianteId {
        get { return imagenVarianteId; } set { imagenVarianteId = value;  }
}



public virtual string RutaArchivo {
        get { return rutaArchivo; } set { rutaArchivo = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> Variante {
        get { return variante; } set { variante = value;  }
}



public virtual string TextoAlternativo {
        get { return textoAlternativo; } set { textoAlternativo = value;  }
}





public ImagenVarianteEN()
{
        variante = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
}



public ImagenVarianteEN(int imagenVarianteId, string rutaArchivo, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, string textoAlternativo
                        )
{
        this.init (ImagenVarianteId, rutaArchivo, variante, textoAlternativo);
}


public ImagenVarianteEN(ImagenVarianteEN imagenVariante)
{
        this.init (imagenVariante.ImagenVarianteId, imagenVariante.RutaArchivo, imagenVariante.Variante, imagenVariante.TextoAlternativo);
}

private void init (int imagenVarianteId
                   , string rutaArchivo, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, string textoAlternativo)
{
        this.ImagenVarianteId = imagenVarianteId;


        this.RutaArchivo = rutaArchivo;

        this.Variante = variante;

        this.TextoAlternativo = textoAlternativo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ImagenVarianteEN t = obj as ImagenVarianteEN;
        if (t == null)
                return false;
        if (ImagenVarianteId.Equals (t.ImagenVarianteId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ImagenVarianteId.GetHashCode ();
        return hash;
}
}
}
