
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
 * Clase ListaDeseos:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ListaDeseosRepository : BasicRepository, IListaDeseosRepository
{
public ListaDeseosRepository() : base ()
{
}


public ListaDeseosRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ListaDeseosEN ReadOIDDefault (int listaDeseosID
                                     )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosNH), listaDeseosID);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaDeseosNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaDeseosNH)).List<ListaDeseosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosNH listaDeseosNH = (ListaDeseosNH)session.Load (typeof(ListaDeseosNH), listaDeseos.ListaDeseosID);


                session.Update (listaDeseosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ListaDeseosEN listaDeseos)
{
        ListaDeseosNH listaDeseosNH = new ListaDeseosNH (listaDeseos);

        try
        {
                SessionInitializeTransaction ();
                if (listaDeseos.UsuarioRegistrado != null) {
                        // Argumento OID y no colección.
                        listaDeseosNH
                        .UsuarioRegistrado = (KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN), listaDeseos.UsuarioRegistrado.UsuarioRegistradoId);

                        listaDeseosNH.UsuarioRegistrado.ListaDeseos
                        .Add (listaDeseosNH);
                }
                if (listaDeseos.Articulo != null) {
                        // Argumento OID y no colección.
                        listaDeseosNH
                        .Articulo = (KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN), listaDeseos.Articulo.ArticuloId);

                        listaDeseosNH.Articulo.ListaDeseos
                        .Add (listaDeseosNH);
                }

                session.Save (listaDeseosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosNH.ListaDeseosID;
}

public void Modificar (ListaDeseosEN listaDeseos)
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosNH listaDeseosNH = (ListaDeseosNH)session.Load (typeof(ListaDeseosNH), listaDeseos.ListaDeseosID);
                session.Update (listaDeseosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int listaDeseosID
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ListaDeseosNH listaDeseosNH = (ListaDeseosNH)session.Load (typeof(ListaDeseosNH), listaDeseosID);
                session.Delete (listaDeseosNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ListaDeseosEN
public ListaDeseosEN DamePorId (int listaDeseosID
                                )
{
        ListaDeseosEN listaDeseosEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaDeseosEN = (ListaDeseosEN)session.Get (typeof(ListaDeseosNH), listaDeseosID);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaDeseosEN;
}

public System.Collections.Generic.IList<ListaDeseosEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ListaDeseosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaDeseosNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaDeseosEN>();
                else
                        result = session.CreateCriteria (typeof(ListaDeseosNH)).List<ListaDeseosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN DameListaDeDeseos (int p_usuario, int p_articulo)
{
        KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ListaDeseosNH self where select lista FROM ListaDeseosNH as lista where lista.UsuarioRegistrado.UsuarioRegistradoId = :p_usuario and lista.Articulo.ArticuloId = :p_articulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ListaDeseosNHdameListaDeDeseosHQL");
                query.SetParameter ("p_usuario", p_usuario);
                query.SetParameter ("p_articulo", p_articulo);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> DameListaDeseosPorUsuarioYArticulo (int p_usuario, int p_articulo)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ListaDeseosNH self where select listaDeseos FROM ListaDeseosNH as listaDeseos where listaDeseos.UsuarioRegistrado.UsuarioRegistradoId = :p_usuario and listaDeseos.Articulo.ArticuloId = :p_articulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ListaDeseosNHdameListaDeseosPorUsuarioYArticuloHQL");
                query.SetParameter ("p_usuario", p_usuario);
                query.SetParameter ("p_articulo", p_articulo);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ListaDeseosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaDeseosRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
