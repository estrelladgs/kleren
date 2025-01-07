
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
 * Clase MetodoPago:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class MetodoPagoRepository : BasicRepository, IMetodoPagoRepository
{
public MetodoPagoRepository() : base ()
{
}


public MetodoPagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MetodoPagoEN ReadOIDDefault (int metodoId
                                    )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.MetodoId);

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MetodoPagoEN metodoPago)
{
        MetodoPagoNH metodoPagoNH = new MetodoPagoNH (metodoPago);

        try
        {
                SessionInitializeTransaction ();

                session.Save (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoNH.MetodoId;
}

public void Modificar (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.MetodoId);
                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
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
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoId);
                session.Delete (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: MetodoPagoEN
public MetodoPagoEN DamePorId (int metodoId
                               )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                else
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
