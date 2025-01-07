

using System;
using System.Text;
using System.Collections.Generic;

using KlerenGen.ApplicationCore.Exceptions;

using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.IRepository.Kleren;


namespace KlerenGen.ApplicationCore.CEN.Kleren
{
/*
 *      Definition of the class PaypalCEN
 *
 */
public partial class PaypalCEN
{
private IPaypalRepository _IPaypalRepository;

public PaypalCEN(IPaypalRepository _IPaypalRepository)
{
        this._IPaypalRepository = _IPaypalRepository;
}

public IPaypalRepository get_IPaypalRepository ()
{
        return this._IPaypalRepository;
}

public int Nuevo (string p_IdPaypal)
{
        PaypalEN paypalEN = null;
        int oid;

        //Initialized PaypalEN
        paypalEN = new PaypalEN ();
        paypalEN.IdPaypal = p_IdPaypal;



        oid = _IPaypalRepository.Nuevo (paypalEN);
        return oid;
}

public void Modificar (int p_Paypal_OID, string p_IdPaypal)
{
        PaypalEN paypalEN = null;

        //Initialized PaypalEN
        paypalEN = new PaypalEN ();
        paypalEN.MetodoId = p_Paypal_OID;
        paypalEN.IdPaypal = p_IdPaypal;
        //Call to PaypalRepository

        _IPaypalRepository.Modificar (paypalEN);
}

public void Borrar (int metodoId
                    )
{
        _IPaypalRepository.Borrar (metodoId);
}

public PaypalEN DamePorId (int metodoId
                           )
{
        PaypalEN paypalEN = null;

        paypalEN = _IPaypalRepository.DamePorId (metodoId);
        return paypalEN;
}

public System.Collections.Generic.IList<PaypalEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PaypalEN> list = null;

        list = _IPaypalRepository.DameTodos (first, size);
        return list;
}
}
}
