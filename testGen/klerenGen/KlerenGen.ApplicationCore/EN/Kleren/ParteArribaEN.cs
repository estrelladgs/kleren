
using System;
// Definición clase ParteArribaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ParteArribaEN                                                                  : KlerenGen.ApplicationCore.EN.Kleren.TallaEN


{
/**
 *	Atributo pecho
 */
private int pecho;



/**
 *	Atributo largo
 */
private int largo;



/**
 *	Atributo hombros
 */
private int hombros;






public virtual int Pecho {
        get { return pecho; } set { pecho = value;  }
}



public virtual int Largo {
        get { return largo; } set { largo = value;  }
}



public virtual int Hombros {
        get { return hombros; } set { hombros = value;  }
}





public ParteArribaEN() : base ()
{
}



public ParteArribaEN(int tallaId, int pecho, int largo, int hombros
                     , KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes
                     )
{
        this.init (TallaId, pecho, largo, hombros, talla, variantes);
}


public ParteArribaEN(ParteArribaEN parteArriba)
{
        this.init (parteArriba.TallaId, parteArriba.Pecho, parteArriba.Largo, parteArriba.Hombros, parteArriba.Talla, parteArriba.Variantes);
}

private void init (int tallaId
                   , int pecho, int largo, int hombros, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes)
{
        this.TallaId = tallaId;


        this.Pecho = pecho;

        this.Largo = largo;

        this.Hombros = hombros;

        this.Talla = talla;

        this.Variantes = variantes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ParteArribaEN t = obj as ParteArribaEN;
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
