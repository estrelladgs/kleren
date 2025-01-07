
using System;
// Definición clase MaterialEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class MaterialEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo material
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum material;



/**
 *	Atributo porcentaje
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum Material {
        get { return material; } set { material = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> Porcentaje {
        get { return porcentaje; } set { porcentaje = value;  }
}





public MaterialEN()
{
        porcentaje = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN>();
}



public MaterialEN(int id, KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum material, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje
                  )
{
        this.init (Id, material, porcentaje);
}


public MaterialEN(MaterialEN material)
{
        this.init (material.Id, material.Material, material.Porcentaje);
}

private void init (int id
                   , KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum material, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PorcentajeEN> porcentaje)
{
        this.Id = id;


        this.Material = material;

        this.Porcentaje = porcentaje;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MaterialEN t = obj as MaterialEN;
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
