
using System;
// Definición clase FacturaEN
namespace KlerenGen.ApplicationCore.EN.Kleren
{
public partial class FacturaEN
{
/**
 *	Atributo facturaId
 */
private int facturaId;



/**
 *	Atributo subtotal
 */
private float subtotal;



/**
 *	Atributo total
 */
private float total;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo pedido
 */
private KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido;



/**
 *	Atributo iva
 */
private float iva;



/**
 *	Atributo descuento
 */
private float descuento;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo apellidos
 */
private string apellidos;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo telefono
 */
private string telefono;






public virtual int FacturaId {
        get { return facturaId; } set { facturaId = value;  }
}



public virtual float Subtotal {
        get { return subtotal; } set { subtotal = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual KlerenGen.ApplicationCore.EN.Kleren.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual float Iva {
        get { return iva; } set { iva = value;  }
}



public virtual float Descuento {
        get { return descuento; } set { descuento = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellidos {
        get { return apellidos; } set { apellidos = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Telefono {
        get { return telefono; } set { telefono = value;  }
}





public FacturaEN()
{
}



public FacturaEN(int facturaId, float subtotal, float total, Nullable<DateTime> fecha, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido, float iva, float descuento, string nombre, string apellidos, string email, string telefono
                 )
{
        this.init (FacturaId, subtotal, total, fecha, pedido, iva, descuento, nombre, apellidos, email, telefono);
}


public FacturaEN(FacturaEN factura)
{
        this.init (factura.FacturaId, factura.Subtotal, factura.Total, factura.Fecha, factura.Pedido, factura.Iva, factura.Descuento, factura.Nombre, factura.Apellidos, factura.Email, factura.Telefono);
}

private void init (int facturaId
                   , float subtotal, float total, Nullable<DateTime> fecha, KlerenGen.ApplicationCore.EN.Kleren.PedidoEN pedido, float iva, float descuento, string nombre, string apellidos, string email, string telefono)
{
        this.FacturaId = facturaId;


        this.Subtotal = subtotal;

        this.Total = total;

        this.Fecha = fecha;

        this.Pedido = pedido;

        this.Iva = iva;

        this.Descuento = descuento;

        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Email = email;

        this.Telefono = telefono;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
        if (t == null)
                return false;
        if (FacturaId.Equals (t.FacturaId))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.FacturaId.GetHashCode ();
        return hash;
}
}
}
