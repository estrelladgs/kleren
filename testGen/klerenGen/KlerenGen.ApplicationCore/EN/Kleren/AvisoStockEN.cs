
using System;
// Definición clase AvisoStockEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class AvisoStockEN
{
/**
 *	Atributo variante
 */
private KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante;



/**
 *	Atributo avisoId
 */
private int avisoId;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo estado
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum estado;






public virtual KlerenGen.ApplicationCore.EN.Kleren.VarianteEN Variante {
        get { return variante; } set { variante = value;  }
}



public virtual int AvisoId {
        get { return avisoId; } set { avisoId = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum Estado {
        get { return estado; } set { estado = value;  }
}





public AvisoStockEN()
{
}



public AvisoStockEN(int avisoId, KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante, string email, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum estado
                    )
{
        this.init (AvisoId, variante, email, estado);
}


public AvisoStockEN(AvisoStockEN avisoStock)
{
        this.init (avisoStock.AvisoId, avisoStock.Variante, avisoStock.Email, avisoStock.Estado);
}

private void init (int avisoId
                   , KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante, string email, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum estado)
{
        this.AvisoId = avisoId;


        this.Variante = variante;

        this.Email = email;

        this.Estado = estado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AvisoStockEN t = obj as AvisoStockEN;
        if (t == null)
                return false;
        if (AvisoId.Equals (t.AvisoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.AvisoId.GetHashCode ();
        return hash;
}
}
}
