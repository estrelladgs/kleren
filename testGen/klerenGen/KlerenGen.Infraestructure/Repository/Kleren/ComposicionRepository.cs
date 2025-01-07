
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
 * Clase Composicion:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ComposicionRepository : BasicRepository, IComposicionRepository
{
public ComposicionRepository() : base ()
{
}


public ComposicionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ComposicionEN ReadOIDDefault (int composicionId
                                     )
{
        ComposicionEN composicionEN = null;

        try
        {
                SessionInitializeTransaction ();
                composicionEN = (ComposicionEN)session.Get (typeof(ComposicionNH), composicionId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return composicionEN;
}

public System.Collections.Generic.IList<ComposicionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComposicionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComposicionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComposicionEN>();
                        else
                                result = session.CreateCriteria (typeof(ComposicionNH)).List<ComposicionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComposicionEN composicion)
{
        try
        {
                SessionInitializeTransaction ();
                ComposicionNH composicionNH = (ComposicionNH)session.Load (typeof(ComposicionNH), composicion.ComposicionId);


                session.Update (composicionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (ComposicionEN composicion)
{
        ComposicionNH composicionNH = new ComposicionNH (composicion);

        try
        {
                SessionInitializeTransaction ();

                session.Save (composicionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return composicionNH.ComposicionId;
}

public void Modificar (ComposicionEN composicion)
{
        try
        {
                SessionInitializeTransaction ();
                ComposicionNH composicionNH = (ComposicionNH)session.Load (typeof(ComposicionNH), composicion.ComposicionId);
                session.Update (composicionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int composicionId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ComposicionNH composicionNH = (ComposicionNH)session.Load (typeof(ComposicionNH), composicionId);
                session.Delete (composicionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ComposicionEN
public ComposicionEN DamePorId (int composicionId
                                )
{
        ComposicionEN composicionEN = null;

        try
        {
                SessionInitializeTransaction ();
                composicionEN = (ComposicionEN)session.Get (typeof(ComposicionNH), composicionId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return composicionEN;
}

public System.Collections.Generic.IList<ComposicionEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ComposicionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComposicionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComposicionEN>();
                else
                        result = session.CreateCriteria (typeof(ComposicionNH)).List<ComposicionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AsociarArticulo (int p_Composicion_OID, int p_articulo_OID)
{
        KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN composicionEN = null;
        try
        {
                SessionInitializeTransaction ();
                composicionEN = (ComposicionEN)session.Load (typeof(ComposicionNH), p_Composicion_OID);
                composicionEN.Articulo = (KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN)session.Load (typeof(KlerenGen.Infraestructure.EN.Kleren.ArticuloNH), p_articulo_OID);

                composicionEN.Articulo.Composicion = composicionEN;




                session.Update (composicionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ComposicionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
