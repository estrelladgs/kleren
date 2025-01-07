
using System;
// Definición clase PorcentajeEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class PorcentajeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo composicion
 */
private KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion;



/**
 *	Atributo material
 */
private KlerenGen.ApplicationCore.EN.Kleren.MaterialEN material;



/**
 *	Atributo porcentaje
 */
private float porcentaje;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN Composicion {
        get { return composicion; } set { composicion = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.MaterialEN Material {
        get { return material; } set { material = value;  }
}



public virtual float Porcentaje {
        get { return porcentaje; } set { porcentaje = value;  }
}





public PorcentajeEN()
{
}



public PorcentajeEN(int id, KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion, KlerenGen.ApplicationCore.EN.Kleren.MaterialEN material, float porcentaje
                    )
{
        this.init (Id, composicion, material, porcentaje);
}


public PorcentajeEN(PorcentajeEN porcentaje)
{
        this.init (porcentaje.Id, porcentaje.Composicion, porcentaje.Material, porcentaje.Porcentaje);
}

private void init (int id
                   , KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicion, KlerenGen.ApplicationCore.EN.Kleren.MaterialEN material, float porcentaje)
{
        this.Id = id;


        this.Composicion = composicion;

        this.Material = material;

        this.Porcentaje = porcentaje;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PorcentajeEN t = obj as PorcentajeEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
