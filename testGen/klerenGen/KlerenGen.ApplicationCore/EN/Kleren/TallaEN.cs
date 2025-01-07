
using System;
// Definición clase TallaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class TallaEN
{
/**
 *	Atributo tallaId
 */
private int tallaId;



/**
 *	Atributo talla
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla;



/**
 *	Atributo variantes
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes;






public virtual int TallaId {
        get { return tallaId; } set { tallaId = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum Talla {
        get { return talla; } set { talla = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> Variantes {
        get { return variantes; } set { variantes = value;  }
}





public TallaEN()
{
        variantes = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
}



public TallaEN(int tallaId, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes
               )
{
        this.init (TallaId, talla, variantes);
}


public TallaEN(TallaEN talla)
{
        this.init (talla.TallaId, talla.Talla, talla.Variantes);
}

private void init (int tallaId
                   , KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes)
{
        this.TallaId = tallaId;


        this.Talla = talla;

        this.Variantes = variantes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TallaEN t = obj as TallaEN;
        if (t == null)
                return false;
        if (TallaId.Equals (t.TallaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.TallaId.GetHashCode ();
        return hash;
}
}
}
