
using System;
// Definición clase VarianteEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class VarianteEN
{
/**
 *	Atributo varianteId
 */
private int varianteId;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo articulo
 */
private KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo;



/**
 *	Atributo talla
 */
private KlerenGen.ApplicationCore.EN.Kleren.TallaEN talla;



/**
 *	Atributo color
 */
private KlerenGen.ApplicationCore.EN.Kleren.ColorEN color;



/**
 *	Atributo linPed
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed;



/**
 *	Atributo avisoStock
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> avisoStock;



/**
 *	Atributo imagenVariante
 */
private KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN imagenVariante;






public virtual int VarianteId {
        get { return varianteId; } set { varianteId = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN Articulo {
        get { return articulo; } set { articulo = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.TallaEN Talla {
        get { return talla; } set { talla = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ColorEN Color {
        get { return color; } set { color = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> LinPed {
        get { return linPed; } set { linPed = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> AvisoStock {
        get { return avisoStock; } set { avisoStock = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN ImagenVariante {
        get { return imagenVariante; } set { imagenVariante = value;  }
}





public VarianteEN()
{
        linPed = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN>();
        avisoStock = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN>();
}



public VarianteEN(int varianteId, int stock, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo, KlerenGen.ApplicationCore.EN.Kleren.TallaEN talla, KlerenGen.ApplicationCore.EN.Kleren.ColorEN color, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> avisoStock, KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN imagenVariante
                  )
{
        this.init (VarianteId, stock, articulo, talla, color, linPed, avisoStock, imagenVariante);
}


public VarianteEN(VarianteEN variante)
{
        this.init (variante.VarianteId, variante.Stock, variante.Articulo, variante.Talla, variante.Color, variante.LinPed, variante.AvisoStock, variante.ImagenVariante);
}

private void init (int varianteId
                   , int stock, KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articulo, KlerenGen.ApplicationCore.EN.Kleren.TallaEN talla, KlerenGen.ApplicationCore.EN.Kleren.ColorEN color, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> avisoStock, KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN imagenVariante)
{
        this.VarianteId = varianteId;


        this.Stock = stock;

        this.Articulo = articulo;

        this.Talla = talla;

        this.Color = color;

        this.LinPed = linPed;

        this.AvisoStock = avisoStock;

        this.ImagenVariante = imagenVariante;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VarianteEN t = obj as VarianteEN;
        if (t == null)
                return false;
        if (VarianteId.Equals (t.VarianteId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.VarianteId.GetHashCode ();
        return hash;
}
}
}
