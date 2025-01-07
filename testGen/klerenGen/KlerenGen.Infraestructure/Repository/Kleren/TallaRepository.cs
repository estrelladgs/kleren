
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
 * Clase Talla:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class TallaRepository : BasicRepository, ITallaRepository
{
public TallaRepository() : base ()
{
}


public TallaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public TallaEN ReadOIDDefault (int tallaId
                               )
{
        TallaEN tallaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaEN = (TallaEN)session.Get (typeof(TallaNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return tallaEN;
}

public System.Collections.Generic.IList<TallaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TallaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TallaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<TallaEN>();
                        else
                                result = session.CreateCriteria (typeof(TallaNH)).List<TallaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TallaEN talla)
{
        try
        {
                SessionInitializeTransaction ();
                TallaNH tallaNH = (TallaNH)session.Load (typeof(TallaNH), talla.TallaId);

                tallaNH.Talla = talla.Talla;


                session.Update (tallaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NuevaTalla (TallaEN talla)
{
        TallaNH tallaNH = new TallaNH (talla);

        try
        {
                SessionInitializeTransaction ();

                session.Save (tallaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tallaNH.TallaId;
}

public void ModficarTalla (TallaEN talla)
{
        try
        {
                SessionInitializeTransaction ();
                TallaNH tallaNH = (TallaNH)session.Load (typeof(TallaNH), talla.TallaId);

                tallaNH.Talla = talla.Talla;

                session.Update (tallaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarTalla (int tallaId
                         )
{
        try
        {
                SessionInitializeTransaction ();
                TallaNH tallaNH = (TallaNH)session.Load (typeof(TallaNH), tallaId);
                session.Delete (tallaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: TallaEN
public TallaEN DamePorId (int tallaId
                          )
{
        TallaEN tallaEN = null;

        try
        {
                SessionInitializeTransaction ();
                tallaEN = (TallaEN)session.Get (typeof(TallaNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return tallaEN;
}

public System.Collections.Generic.IList<TallaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<TallaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TallaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<TallaEN>();
                else
                        result = session.CreateCriteria (typeof(TallaNH)).List<TallaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in TallaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
