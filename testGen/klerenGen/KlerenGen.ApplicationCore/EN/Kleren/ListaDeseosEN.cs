
using System;
// Definición clase ListaDeseosEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ListaDeseosEN
{
/**
 *	Atributo listaDeseosID
 */
private int listaDeseosID;



/**
 *	Atributo usuarioRegistrado
 */
private KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado;



/**
 *	Atributo articulo
 */
private KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo;






public virtual int ListaDeseosID {
        get { return listaDeseosID; } set { listaDeseosID = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN UsuarioRegistrado {
        get { return usuarioRegistrado; } set { usuarioRegistrado = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}





public ListaDeseosEN()
{
}



public ListaDeseosEN(int listaDeseosID, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo
                     )
{
        this.init (ListaDeseosID, usuarioRegistrado, articulo);
}


public ListaDeseosEN(ListaDeseosEN listaDeseos)
{
        this.init (listaDeseos.ListaDeseosID, listaDeseos.UsuarioRegistrado, listaDeseos.Articulo);
}

private void init (int listaDeseosID
                   , KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo)
{
        this.ListaDeseosID = listaDeseosID;


        this.UsuarioRegistrado = usuarioRegistrado;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaDeseosEN t = obj as ListaDeseosEN;
        if (t == null)
                return false;
        if (ListaDeseosID.Equals (t.ListaDeseosID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ListaDeseosID.GetHashCode ();
        return hash;
}
}
}
