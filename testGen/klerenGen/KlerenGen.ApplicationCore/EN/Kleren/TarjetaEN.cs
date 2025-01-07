
using System;
// Definición clase TarjetaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class TarjetaEN                                                                      : KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN


{
/**
 *	Atributo tarjetaId
 */
private string tarjetaId;






public virtual string TarjetaId {
        get { return tarjetaId; } set { tarjetaId = value;  }
}





public TarjetaEN() : base ()
{
}



public TarjetaEN(int metodoId, string tarjetaId
                 , System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido
                 )
{
        this.init (MetodoId, tarjetaId, pedido);
}


public TarjetaEN(TarjetaEN tarjeta)
{
        this.init (tarjeta.MetodoId, tarjeta.TarjetaId, tarjeta.Pedido);
}

private void init (int metodoId
                   , string tarjetaId, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> pedido)
{
        this.MetodoId = metodoId;


        this.TarjetaId = tarjetaId;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TarjetaEN t = obj as TarjetaEN;
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
