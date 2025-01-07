
using System;
// Definición clase LinPedEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class LinPedEN
{
/**
 *	Atributo lineaId
 */
private int lineaId;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo pedido
 */
private KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo variante
 */
private KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante;






public virtual int LineaId {
        get { return lineaId; } set { lineaId = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.VarianteEN Variante {
        get { return variante; } set { variante = value;  }
}





public LinPedEN()
{
}



public LinPedEN(int lineaId, int cantidad, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido, float precio, KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante
                )
{
        this.init (LineaId, cantidad, pedido, precio, variante);
}


public LinPedEN(LinPedEN linPed)
{
        this.init (linPed.LineaId, linPed.Cantidad, linPed.Pedido, linPed.Precio, linPed.Variante);
}

private void init (int lineaId
                   , int cantidad, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido, float precio, KlerenGen.ApplicationCore.EN.Kleren.VarianteEN variante)
{
        this.LineaId = lineaId;


        this.Cantidad = cantidad;

        this.Pedido = pedido;

        this.Precio = precio;

        this.Variante = variante;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LinPedEN t = obj as LinPedEN;
        if (t == null)
                return false;
        if (LineaId.Equals (t.LineaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.LineaId.GetHashCode ();
        return hash;
}
}
}
