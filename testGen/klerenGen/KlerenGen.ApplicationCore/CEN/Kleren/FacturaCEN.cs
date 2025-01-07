

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class FacturaCEN
 *
 */
public partial class FacturaCEN
{
private IFacturaRepository _IFacturaRepository;

public FacturaCEN(IFacturaRepository _IFacturaRepository)
{
        this._IFacturaRepository = _IFacturaRepository;
}

public IFacturaRepository get_IFacturaRepository ()
{
        return this._IFacturaRepository;
}

public int Nueva (float p_subtotal, float p_total, Nullable<DateTime> p_fecha, int p_pedido, float p_iva, float p_descuento, string p_nombre, string p_apellidos, string p_email, string p_telefono)
{
        FacturaEN facturaEN = null;
        int oid;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.Subtotal = p_subtotal;

        facturaEN.Total = p_total;

        facturaEN.Fecha = p_fecha;


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids facturaId
                facturaEN.Pedido = new KlerenGen.ApplicationCore.EN.Kleren.PedidoEN ();
                facturaEN.Pedido.PedidoId = p_pedido;
        }

        facturaEN.Iva = p_iva;

        facturaEN.Descuento = p_descuento;

        facturaEN.Nombre = p_nombre;

        facturaEN.Apellidos = p_apellidos;

        facturaEN.Email = p_email;

        facturaEN.Telefono = p_telefono;



        oid = _IFacturaRepository.Nueva (facturaEN);
        return oid;
}

public void Modificar (int p_Factura_OID, float p_subtotal, float p_total, Nullable<DateTime> p_fecha, float p_iva, float p_descuento, string p_nombre, string p_apellidos, string p_email, string p_telefono)
{
        FacturaEN facturaEN = null;

        //Initialized FacturaEN
        facturaEN = new FacturaEN ();
        facturaEN.FacturaId = p_Factura_OID;
        facturaEN.Subtotal = p_subtotal;
        facturaEN.Total = p_total;
        facturaEN.Fecha = p_fecha;
        facturaEN.Iva = p_iva;
        facturaEN.Descuento = p_descuento;
        facturaEN.Nombre = p_nombre;
        facturaEN.Apellidos = p_apellidos;
        facturaEN.Email = p_email;
        facturaEN.Telefono = p_telefono;
        //Call to FacturaRepository

        _IFacturaRepository.Modificar (facturaEN);
}

public void Borrar (int facturaId
                    )
{
        _IFacturaRepository.Borrar (facturaId);
}

public FacturaEN DamePorId (int facturaId
                            )
{
        FacturaEN facturaEN = null;

        facturaEN = _IFacturaRepository.DamePorId (facturaId);
        return facturaEN;
}

public System.Collections.Generic.IList<FacturaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<FacturaEN> list = null;

        list = _IFacturaRepository.DameTodos (first, size);
        return list;
}
}
}
