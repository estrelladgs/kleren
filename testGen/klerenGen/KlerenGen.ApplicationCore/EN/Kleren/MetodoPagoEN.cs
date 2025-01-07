
using System;
// Definición clase MetodoPagoEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class MetodoPagoEN
{
/**
 *	Atributo metodoId
 */
private int metodoId;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido;






public virtual int MetodoId {
        get { return metodoId; } set { metodoId = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public MetodoPagoEN()
{
        pedido = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>();
}



public MetodoPagoEN(int metodoId, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido
                    )
{
        this.init (MetodoId, pedido);
}


public MetodoPagoEN(MetodoPagoEN metodoPago)
{
        this.init (metodoPago.MetodoId, metodoPago.Pedido);
}

private void init (int metodoId
                   , System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido)
{
        this.MetodoId = metodoId;


        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetodoPagoEN t = obj as MetodoPagoEN;
        if (t == null)
                return false;
        if (MetodoId.Equals (t.MetodoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.MetodoId.GetHashCode ();
        return hash;
}
}
}
