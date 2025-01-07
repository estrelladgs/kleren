
using System;
// Definición clase ResenaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ResenaEN
{
/**
 *	Atributo usuarioRegistrado
 */
private KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado;



/**
 *	Atributo resenaId
 */
private int resenaId;



/**
 *	Atributo articulo
 */
private KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo;



/**
 *	Atributo numeroEstrellas
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum numeroEstrellas;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo imagen
 */
private KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN imagen;






public virtual KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN UsuarioRegistrado {
        get { return usuarioRegistrado; } set { usuarioRegistrado = value;  }
}



public virtual int ResenaId {
        get { return resenaId; } set { resenaId = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum NumeroEstrellas {
        get { return numeroEstrellas; } set { numeroEstrellas = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN Imagen {
        get { return imagen; } set { imagen = value;  }
}





public ResenaEN()
{
}



public ResenaEN(int resenaId, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum numeroEstrellas, string comentario, Nullable<DateTime> fecha, KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN imagen
                )
{
        this.init (ResenaId, usuarioRegistrado, articulo, numeroEstrellas, comentario, fecha, imagen);
}


public ResenaEN(ResenaEN resena)
{
        this.init (resena.ResenaId, resena.UsuarioRegistrado, resena.Articulo, resena.NumeroEstrellas, resena.Comentario, resena.Fecha, resena.Imagen);
}

private void init (int resenaId
                   , KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.NumeroEstrellasEnum numeroEstrellas, string comentario, Nullable<DateTime> fecha, KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN imagen)
{
        this.ResenaId = resenaId;


        this.UsuarioRegistrado = usuarioRegistrado;

        this.Articulo = articulo;

        this.NumeroEstrellas = numeroEstrellas;

        this.Comentario = comentario;

        this.Fecha = fecha;

        this.Imagen = imagen;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ResenaEN t = obj as ResenaEN;
        if (t == null)
                return false;
        if (ResenaId.Equals (t.ResenaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ResenaId.GetHashCode ();
        return hash;
}
}
}
