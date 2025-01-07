
using System;
// Definición clase ColorEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ColorEN
{
/**
 *	Atributo variante
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante;



/**
 *	Atributo colorId
 */
private int colorId;



/**
 *	Atributo nombre
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum nombre;



/**
 *	Atributo codigo
 */
private string codigo;






public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> Variante {
        get { return variante; } set { variante = value;  }
}



public virtual int ColorId {
        get { return colorId; } set { colorId = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Codigo {
        get { return codigo; } set { codigo = value;  }
}





public ColorEN()
{
        variante = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
}



public ColorEN(int colorId, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum nombre, string codigo
               )
{
        this.init (ColorId, variante, nombre, codigo);
}


public ColorEN(ColorEN color)
{
        this.init (color.ColorId, color.Variante, color.Nombre, color.Codigo);
}

private void init (int colorId
                   , System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum nombre, string codigo)
{
        this.ColorId = colorId;


        this.Variante = variante;

        this.Nombre = nombre;

        this.Codigo = codigo;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ColorEN t = obj as ColorEN;
        if (t == null)
                return false;
        if (ColorId.Equals (t.ColorId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ColorId.GetHashCode ();
        return hash;
}
}
}
