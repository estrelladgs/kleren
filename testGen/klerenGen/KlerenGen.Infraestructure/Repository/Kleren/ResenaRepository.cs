
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
 * Clase Resena:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ResenaRepository : BasicRepository, IResenaRepository
{
public ResenaRepository() : base ()
{
}


public ResenaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ResenaEN ReadOIDDefault (int resenaId
                                )
{
        ResenaEN resenaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenaEN = (ResenaEN)session.Get (typeof(ResenaNH), resenaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenaEN;
}

public System.Collections.Generic.IList<ResenaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ResenaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ResenaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ResenaEN>();
                        else
                                result = session.CreateCriteria (typeof(ResenaNH)).List<ResenaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ResenaEN resena)
{
        try
        {
                SessionInitializeTransaction ();
                ResenaNH resenaNH = (ResenaNH)session.Load (typeof(ResenaNH), resena.ResenaId);



                resenaNH.NumeroEstrellas = resena.NumeroEstrellas;


                resenaNH.Comentario = resena.Comentario;


                resenaNH.Fecha = resena.Fecha;


                session.Update (resenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (ResenaEN resena)
{
        ResenaNH resenaNH = new ResenaNH (resena);

        try
        {
                SessionInitializeTransaction ();
                if (resena.UsuarioRegistrado != null) {
                        // Argumento OID y no colección.
                        resenaNH
                        .UsuarioRegistrado = (KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN), resena.UsuarioRegistrado.UsuarioRegistradoId);

                        resenaNH.UsuarioRegistrado.Resenas
                        .Add (resenaNH);
                }
                if (resena.Articulo != null) {
                        // Argumento OID y no colección.
                        resenaNH
                        .Articulo = (KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN), resena.Articulo.ArticuloId);

                        resenaNH.Articulo.Resenas
                        .Add (resenaNH);
                }

                session.Save (resenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return resenaNH.ResenaId;
}

public void Modificar (ResenaEN resena)
{
        try
        {
                SessionInitializeTransaction ();
                ResenaNH resenaNH = (ResenaNH)session.Load (typeof(ResenaNH), resena.ResenaId);

                resenaNH.NumeroEstrellas = resena.NumeroEstrellas;


                resenaNH.Comentario = resena.Comentario;


                resenaNH.Fecha = resena.Fecha;

                session.Update (resenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int resenaId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ResenaNH resenaNH = (ResenaNH)session.Load (typeof(ResenaNH), resenaId);
                session.Delete (resenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ResenaEN
public ResenaEN DamePorId (int resenaId
                           )
{
        ResenaEN resenaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenaEN = (ResenaEN)session.Get (typeof(ResenaNH), resenaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenaEN;
}

public System.Collections.Generic.IList<ResenaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ResenaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ResenaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ResenaEN>();
                else
                        result = session.CreateCriteria (typeof(ResenaNH)).List<ResenaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> DameResenasPorArticulo (int p_articulo)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ResenaNH self where select resena FROM ResenaNH as resena where resena.Articulo.ArticuloId = :p_articulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ResenaNHdameResenasPorArticuloHQL");
                query.SetParameter ("p_articulo", p_articulo);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ResenaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
