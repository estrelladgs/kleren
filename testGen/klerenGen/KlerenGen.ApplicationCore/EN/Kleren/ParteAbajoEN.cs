
using System;
// Definición clase ParteAbajoEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class ParteAbajoEN                                                                   : KlerenGen.ApplicationCore.EN.Kleren.TallaEN


{
/**
 *	Atributo cintura
 */
private int cintura;



/**
 *	Atributo cadera
 */
private int cadera;



/**
 *	Atributo largo
 */
private int largo;






public virtual int Cintura {
        get { return cintura; } set { cintura = value;  }
}



public virtual int Cadera {
        get { return cadera; } set { cadera = value;  }
}



public virtual int Largo {
        get { return largo; } set { largo = value;  }
}





public ParteAbajoEN() : base ()
{
}



public ParteAbajoEN(int tallaId, int cintura, int cadera, int largo
                    , KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes
                    )
{
        this.init (TallaId, cintura, cadera, largo, talla, variantes);
}


public ParteAbajoEN(ParteAbajoEN parteAbajo)
{
        this.init (parteAbajo.TallaId, parteAbajo.Cintura, parteAbajo.Cadera, parteAbajo.Largo, parteAbajo.Talla, parteAbajo.Variantes);
}

private void init (int tallaId
                   , int cintura, int cadera, int largo, KlerenGen.ApplicationCore.Enumerated.Kleren.TallasEnum talla, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> variantes)
{
        this.TallaId = tallaId;


        this.Cintura = cintura;

        this.Cadera = cadera;

        this.Largo = largo;

        this.Talla = talla;

        this.Variantes = variantes;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ParteAbajoEN t = obj as ParteAbajoEN;
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
