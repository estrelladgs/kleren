
using System;
// Definición clase CuidadoEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class CuidadoEN
{
/**
 *	Atributo cuiadoId
 */
private int cuiadoId;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo articulos
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulos;






public virtual int CuiadoId {
        get { return cuiadoId; } set { cuiadoId = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> Articulos {
        get { return articulos; } set { articulos = value;  }
}





public CuidadoEN()
{
        articulos = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
}



public CuidadoEN(int cuiadoId, string nombre, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulos
                 )
{
        this.init (CuiadoId, nombre, articulos);
}


public CuidadoEN(CuidadoEN cuidado)
{
        this.init (cuidado.CuiadoId, cuidado.Nombre, cuidado.Articulos);
}

private void init (int cuiadoId
                   , string nombre, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> articulos)
{
        this.CuiadoId = cuiadoId;


        this.Nombre = nombre;

        this.Articulos = articulos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CuidadoEN t = obj as CuidadoEN;
        if (t == null)
                return false;
        if (CuiadoId.Equals (t.CuiadoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.CuiadoId.GetHashCode ();
        return hash;
}
}
}
