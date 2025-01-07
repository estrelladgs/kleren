
using System;
// Definición clase DevolucionEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class DevolucionEN
{
/**
 *	Atributo devolucionId
 */
private int devolucionId;



/**
 *	Atributo estado
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum estado;



/**
 *	Atributo motivoRechazo
 */
private string motivoRechazo;



/**
 *	Atributo pedido
 */
private KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido;






public virtual int DevolucionId {
        get { return devolucionId; } set { devolucionId = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual string MotivoRechazo {
        get { return motivoRechazo; } set { motivoRechazo = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public DevolucionEN()
{
}



public DevolucionEN(int devolucionId, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum estado, string motivoRechazo, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido
                    )
{
        this.init (DevolucionId, estado, motivoRechazo, pedido);
}


public DevolucionEN(DevolucionEN devolucion)
{
        this.init (devolucion.DevolucionId, devolucion.Estado, devolucion.MotivoRechazo, devolucion.Pedido);
}

private void init (int devolucionId
                   , KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoDevolucionEnum estado, string motivoRechazo, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido)
{
        this.DevolucionId = devolucionId;


        this.Estado = estado;

        this.MotivoRechazo = motivoRechazo;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DevolucionEN t = obj as DevolucionEN;
        if (t == null)
                return false;
        if (DevolucionId.Equals (t.DevolucionId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.DevolucionId.GetHashCode ();
        return hash;
}
}
}
