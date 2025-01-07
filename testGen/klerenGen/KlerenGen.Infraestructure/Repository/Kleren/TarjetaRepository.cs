
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
 * Clase Tarjeta:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class TarjetaRepository : BasicRepository, ITarjetaRepository
{
public TarjetaRepository() : base ()
{
}


public TarjetaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public TarjetaEN ReadOIDDefault (int metodoId
                                 )
{
        TarjetaEN tarjetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tarjetaEN = (TarjetaEN)session.Get (typeof(TarjetaNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TarjetaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<TarjetaEN>();
                        else
                                result = session.CreateCriteria (typeof(TarjetaNH)).List<TarjetaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TarjetaEN tarjeta)
{
        try
        {
                SessionInitializeTransaction ();
                TarjetaNH tarjetaNH = (TarjetaNH)session.Load (typeof(TarjetaNH), tarjeta.MetodoId);

                tarjetaNH.TarjetaId = tarjeta.TarjetaId;

                session.Update (tarjetaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (TarjetaEN tarjeta)
{
        TarjetaNH tarjetaNH = new TarjetaNH (tarjeta);

        try
        {
                SessionInitializeTransaction ();

                session.Save (tarjetaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tarjetaNH.MetodoId;
}

public void Modificar (TarjetaEN tarjeta)
{
        try
        {
                SessionInitializeTransaction ();
                TarjetaNH tarjetaNH = (TarjetaNH)session.Load (typeof(TarjetaNH), tarjeta.MetodoId);

                tarjetaNH.TarjetaId = tarjeta.TarjetaId;

                session.Update (tarjetaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
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
                TarjetaNH tarjetaNH = (TarjetaNH)session.Load (typeof(TarjetaNH), metodoId);
                session.Delete (tarjetaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: TarjetaEN
public TarjetaEN DamePorId (int metodoId
                            )
{
        TarjetaEN tarjetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tarjetaEN = (TarjetaEN)session.Get (typeof(TarjetaNH), metodoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return tarjetaEN;
}

public System.Collections.Generic.IList<TarjetaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<TarjetaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TarjetaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<TarjetaEN>();
                else
                        result = session.CreateCriteria (typeof(TarjetaNH)).List<TarjetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TarjetaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
