
using System;
// Definición clase PedidoEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class PedidoEN
{
/**
 *	Atributo pedidoId
 */
private int pedidoId;



/**
 *	Atributo estado
 */
private KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum estado;



/**
 *	Atributo dirEnvio
 */
private KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN dirEnvio;



/**
 *	Atributo linPed
 */
private System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed;



/**
 *	Atributo metodoPago
 */
private KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN metodoPago;



/**
 *	Atributo usuarioRegistrado
 */
private KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado;



/**
 *	Atributo fechaPagado
 */
private Nullable<DateTime> fechaPagado;



/**
 *	Atributo fechaProcesado
 */
private Nullable<DateTime> fechaProcesado;



/**
 *	Atributo fechaEnviado
 */
private Nullable<DateTime> fechaEnviado;



/**
 *	Atributo fechaEntregado
 */
private Nullable<DateTime> fechaEntregado;



/**
 *	Atributo factura
 */
private KlerenGen.ApplicationCore.EN.Kleren.FacturaEN factura;



/**
 *	Atributo devolucion
 */
private KlerenGen.ApplicationCore.EN.Kleren.DevolucionEN devolucion;



/**
 *	Atributo total
 */
private double total;



/**
 *	Atributo totalDescuento
 */
private double totalDescuento;






public virtual int PedidoId {
        get { return pedidoId; } set { pedidoId = value;  }
}



public virtual KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN DirEnvio {
        get { return dirEnvio; } set { dirEnvio = value;  }
}



public virtual System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> LinPed {
        get { return linPed; } set { linPed = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN UsuarioRegistrado {
        get { return usuarioRegistrado; } set { usuarioRegistrado = value;  }
}



public virtual Nullable<DateTime> FechaPagado {
        get { return fechaPagado; } set { fechaPagado = value;  }
}



public virtual Nullable<DateTime> FechaProcesado {
        get { return fechaProcesado; } set { fechaProcesado = value;  }
}



public virtual Nullable<DateTime> FechaEnviado {
        get { return fechaEnviado; } set { fechaEnviado = value;  }
}



public virtual Nullable<DateTime> FechaEntregado {
        get { return fechaEntregado; } set { fechaEntregado = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.DevolucionEN Devolucion {
        get { return devolucion; } set { devolucion = value;  }
}



public virtual double Total {
        get { return total; } set { total = value;  }
}



public virtual double TotalDescuento {
        get { return totalDescuento; } set { totalDescuento = value;  }
}





public PedidoEN()
{
        linPed = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN>();
}



public PedidoEN(int pedidoId, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum estado, KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN dirEnvio, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed, KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN metodoPago, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, Nullable<DateTime> fechaPagado, Nullable<DateTime> fechaProcesado, Nullable<DateTime> fechaEnviado, Nullable<DateTime> fechaEntregado, KlerenGen.ApplicationCore.EN.Kleren.FacturaEN factura, KlerenGen.ApplicationCore.EN.Kleren.DevolucionEN devolucion, double total, double totalDescuento
                )
{
        this.init (PedidoId, estado, dirEnvio, linPed, metodoPago, usuarioRegistrado, fechaPagado, fechaProcesado, fechaEnviado, fechaEntregado, factura, devolucion, total, totalDescuento);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.PedidoId, pedido.Estado, pedido.DirEnvio, pedido.LinPed, pedido.MetodoPago, pedido.UsuarioRegistrado, pedido.FechaPagado, pedido.FechaProcesado, pedido.FechaEnviado, pedido.FechaEntregado, pedido.Factura, pedido.Devolucion, pedido.Total, pedido.TotalDescuento);
}

private void init (int pedidoId
                   , KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum estado, KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN dirEnvio, System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN> linPed, KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN metodoPago, KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN usuarioRegistrado, Nullable<DateTime> fechaPagado, Nullable<DateTime> fechaProcesado, Nullable<DateTime> fechaEnviado, Nullable<DateTime> fechaEntregado, KlerenGen.ApplicationCore.EN.Kleren.FacturaEN factura, KlerenGen.ApplicationCore.EN.Kleren.DevolucionEN devolucion, double total, double totalDescuento)
{
        this.PedidoId = pedidoId;


        this.Estado = estado;

        this.DirEnvio = dirEnvio;

        this.LinPed = linPed;

        this.MetodoPago = metodoPago;

        this.UsuarioRegistrado = usuarioRegistrado;

        this.FechaPagado = fechaPagado;

        this.FechaProcesado = fechaProcesado;

        this.FechaEnviado = fechaEnviado;

        this.FechaEntregado = fechaEntregado;

        this.Factura = factura;

        this.Devolucion = devolucion;

        this.Total = total;

        this.TotalDescuento = totalDescuento;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (PedidoId.Equals (t.PedidoId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.PedidoId.GetHashCode ();
        return hash;
}
}
}
