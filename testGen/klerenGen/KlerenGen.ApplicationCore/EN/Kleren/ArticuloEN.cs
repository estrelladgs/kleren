
using System;
// Definición clase ArticuloEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ArticuloEN
{
/**
 *	Atributo articuloId
 */
private int articuloId;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo categoria
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum categoria;



/**
 *	Atributo sexo
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum sexo;



/**
 *	Atributo promocion
 */
private bool promocion;



/**
 *	Atributo precio_oferta
 */
private float precio_oferta;



/**
 *	Atributo variante
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante;



/**
 *	Atributo resenas
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo trazabilidad
 */
private string trazabilidad;



/**
 *	Atributo cuidados
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> cuidados;



/**
 *	Atributo composicion
 */
private KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion;



/**
 *	Atributo parte
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum parte;



/**
 *	Atributo listaDeseos
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos;






public virtual int ArticuloId {
        get { return articuloId; } set { articuloId = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum Sexo {
        get { return sexo; } set { sexo = value;  }
}



public virtual bool Promocion {
        get { return promocion; } set { promocion = value;  }
}



public virtual float Precio_oferta {
        get { return precio_oferta; } set { precio_oferta = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> Variante {
        get { return variante; } set { variante = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> Resenas {
        get { return resenas; } set { resenas = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Trazabilidad {
        get { return trazabilidad; } set { trazabilidad = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> Cuidados {
        get { return cuidados; } set { cuidados = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN Composicion {
        get { return composicion; } set { composicion = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum Parte {
        get { return parte; } set { parte = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> ListaDeseos {
        get { return listaDeseos; } set { listaDeseos = value;  }
}





public ArticuloEN()
{
        variante = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
        resenas = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN>();
        cuidados = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN>();
        listaDeseos = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN>();
}



public ArticuloEN(int articuloId, float precio, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum categoria, KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum sexo, bool promocion, float precio_oferta, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas, string nombre, string trazabilidad, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> cuidados, KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion, KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum parte, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos
                  )
{
        this.init (ArticuloId, precio, categoria, sexo, promocion, precio_oferta, variante, resenas, nombre, trazabilidad, cuidados, composicion, parte, listaDeseos);
}


public ArticuloEN(ArticuloEN articulo)
{
        this.init (articulo.ArticuloId, articulo.Precio, articulo.Categoria, articulo.Sexo, articulo.Promocion, articulo.Precio_oferta, articulo.Variante, articulo.Resenas, articulo.Nombre, articulo.Trazabilidad, articulo.Cuidados, articulo.Composicion, articulo.Parte, articulo.ListaDeseos);
}

private void init (int articuloId
                   , float precio, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum categoria, KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum sexo, bool promocion, float precio_oferta, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variante, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> resenas, string nombre, string trazabilidad, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN> cuidados, KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion, KlerenGen.ApplicationCore.Enumerated.Kleren.PartesEnum parte, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> listaDeseos)
{
        this.ArticuloId = articuloId;


        this.Precio = precio;

        this.Categoria = categoria;

        this.Sexo = sexo;

        this.Promocion = promocion;

        this.Precio_oferta = precio_oferta;

        this.Variante = variante;

        this.Resenas = resenas;

        this.Nombre = nombre;

        this.Trazabilidad = trazabilidad;

        this.Cuidados = cuidados;

        this.Composicion = composicion;

        this.Parte = parte;

        this.ListaDeseos = listaDeseos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ArticuloEN t = obj as ArticuloEN;
        if (t == null)
                return false;
        if (ArticuloId.Equals (t.ArticuloId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ArticuloId.GetHashCode ();
        return hash;
}
}
}
