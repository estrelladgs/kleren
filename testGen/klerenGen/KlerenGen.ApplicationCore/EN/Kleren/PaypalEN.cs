
using System;
// Definición clase PaypalEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class PaypalEN                                                                       : KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN


{
/**
 *	Atributo idPaypal
 */
private string idPaypal;






public virtual string IdPaypal {
        get { return idPaypal; } set { idPaypal = value;  }
}





public PaypalEN() : base ()
{
}



public PaypalEN(int metodoId, string idPaypal
                , System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido
                )
{
        this.init (MetodoId, idPaypal, pedido);
}


public PaypalEN(PaypalEN paypal)
{
        this.init (paypal.MetodoId, paypal.IdPaypal, paypal.Pedido);
}

private void init (int metodoId
                   , string idPaypal, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido)
{
        this.MetodoId = metodoId;


        this.IdPaypal = idPaypal;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaypalEN t = obj as PaypalEN;
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
