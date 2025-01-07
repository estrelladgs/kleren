
using System;
// Definición clase ComposicionEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ComposicionEN
{
/**
 *	Atributo composicionId
 */
private int composicionId;



/**
 *	Atributo porcentaje
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje;



/**
 *	Atributo articulo
 */
private KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo;






public virtual int ComposicionId {
        get { return composicionId; } set { composicionId = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> Porcentaje {
        get { return porcentaje; } set { porcentaje = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}





public ComposicionEN()
{
        porcentaje = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN>();
}



public ComposicionEN(int composicionId, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo
                     )
{
        this.init (ComposicionId, porcentaje, articulo);
}


public ComposicionEN(ComposicionEN composicion)
{
        this.init (composicion.ComposicionId, composicion.Porcentaje, composicion.Articulo);
}

private void init (int composicionId
                   , System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo)
{
        this.ComposicionId = composicionId;


        this.Porcentaje = porcentaje;

        this.Articulo = articulo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComposicionEN t = obj as ComposicionEN;
        if (t == null)
                return false;
        if (ComposicionId.Equals (t.ComposicionId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ComposicionId.GetHashCode ();
        return hash;
}
}
}
