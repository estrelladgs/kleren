
using System;
using System.Text;
using KlerenGen.ApplicationCore.CEN.Kleren;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.Exceptions;
using KlerenGen.ApplicationCore.IRepository.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;
using KlerenGen.Infraestructure.EN.Kleren;


/*
 * Clase Paypal:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class PaypalRepository : BasicRepository, IPaypalRepository
{
public PaypalRepository() : base ()
{
}


public PaypalRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PaypalEN ReadOIDDefault (int metodoId
                                )
{
        PaypalEN paypalEN = null;

        try
        {
                SessionInitializeTransaction ();
                paypalEN = (PaypalEN)session.Get (typeof(PaypalNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return paypalEN;
}

public System.Collections.Generic.IList<PaypalEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PaypalEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaypalNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaypalEN>();
                        else
                                result = session.CreateCriteria (typeof(PaypalNH)).List<PaypalEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PaypalEN paypal)
{
        try
        {
                SessionInitializeTransaction ();
                PaypalNH paypalNH = (PaypalNH)session.Load (typeof(PaypalNH), paypal.MetodoId);

                paypalNH.IdPaypal = paypal.IdPaypal;

                session.Update (paypalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (PaypalEN paypal)
{
        PaypalNH paypalNH = new PaypalNH (paypal);

        try
        {
                SessionInitializeTransaction ();

                session.Save (paypalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paypalNH.MetodoId;
}

public void Modificar (PaypalEN paypal)
{
        try
        {
                SessionInitializeTransaction ();
                PaypalNH paypalNH = (PaypalNH)session.Load (typeof(PaypalNH), paypal.MetodoId);

                paypalNH.IdPaypal = paypal.IdPaypal;

                session.Update (paypalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int metodoId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PaypalNH paypalNH = (PaypalNH)session.Load (typeof(PaypalNH), metodoId);
                session.Delete (paypalNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: PaypalEN
public PaypalEN DamePorId (int metodoId
                           )
{
        PaypalEN paypalEN = null;

        try
        {
                SessionInitializeTransaction ();
                paypalEN = (PaypalEN)session.Get (typeof(PaypalNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return paypalEN;
}

public System.Collections.Generic.IList<PaypalEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PaypalEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PaypalNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PaypalEN>();
                else
                        result = session.CreateCriteria (typeof(PaypalNH)).List<PaypalEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaypalRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
