
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
 * Clase UsuarioRegistrado:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class UsuarioRegistradoRepository : BasicRepository, IUsuarioRegistradoRepository
{
public UsuarioRegistradoRepository() : base ()
{
}


public UsuarioRegistradoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioRegistradoEN ReadOIDDefault (int usuarioRegistradoId
                                           )
{
        UsuarioRegistradoEN usuarioRegistradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioRegistradoEN = (UsuarioRegistradoEN)session.Get (typeof(UsuarioRegistradoNH), usuarioRegistradoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioRegistradoEN;
}

public System.Collections.Generic.IList<UsuarioRegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioRegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioRegistradoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioRegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioRegistradoNH)).List<UsuarioRegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioRegistradoEN usuarioRegistrado)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioRegistradoNH usuarioRegistradoNH = (UsuarioRegistradoNH)session.Load (typeof(UsuarioRegistradoNH), usuarioRegistrado.UsuarioRegistradoId);

                usuarioRegistradoNH.Nombre = usuarioRegistrado.Nombre;


                usuarioRegistradoNH.Apellidos = usuarioRegistrado.Apellidos;


                usuarioRegistradoNH.Correo = usuarioRegistrado.Correo;


                usuarioRegistradoNH.Telefono = usuarioRegistrado.Telefono;


                usuarioRegistradoNH.Fecha_nac = usuarioRegistrado.Fecha_nac;






                usuarioRegistradoNH.Pass = usuarioRegistrado.Pass;



                usuarioRegistradoNH.Puntos = usuarioRegistrado.Puntos;


                usuarioRegistradoNH.TokenCompartido = usuarioRegistrado.TokenCompartido;

                session.Update (usuarioRegistradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (UsuarioRegistradoEN usuarioRegistrado)
{
        UsuarioRegistradoNH usuarioRegistradoNH = new UsuarioRegistradoNH (usuarioRegistrado);

        try
        {
                SessionInitializeTransaction ();

                session.Save (usuarioRegistradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioRegistradoNH.UsuarioRegistradoId;
}

public void Modificar (UsuarioRegistradoEN usuarioRegistrado)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioRegistradoNH usuarioRegistradoNH = (UsuarioRegistradoNH)session.Load (typeof(UsuarioRegistradoNH), usuarioRegistrado.UsuarioRegistradoId);

                usuarioRegistradoNH.Nombre = usuarioRegistrado.Nombre;


                usuarioRegistradoNH.Apellidos = usuarioRegistrado.Apellidos;


                usuarioRegistradoNH.Correo = usuarioRegistrado.Correo;


                usuarioRegistradoNH.Telefono = usuarioRegistrado.Telefono;


                usuarioRegistradoNH.Fecha_nac = usuarioRegistrado.Fecha_nac;

                session.Update (usuarioRegistradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int usuarioRegistradoId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioRegistradoNH usuarioRegistradoNH = (UsuarioRegistradoNH)session.Load (typeof(UsuarioRegistradoNH), usuarioRegistradoId);
                session.Delete (usuarioRegistradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: UsuarioRegistradoEN
public UsuarioRegistradoEN DamePorId (int usuarioRegistradoId
                                      )
{
        UsuarioRegistradoEN usuarioRegistradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioRegistradoEN = (UsuarioRegistradoEN)session.Get (typeof(UsuarioRegistradoNH), usuarioRegistradoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioRegistradoEN;
}

public System.Collections.Generic.IList<UsuarioRegistradoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<UsuarioRegistradoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UsuarioRegistradoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<UsuarioRegistradoEN>();
                else
                        result = session.CreateCriteria (typeof(UsuarioRegistradoNH)).List<UsuarioRegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN DamePorCorreo (string p_correo)
{
        KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioRegistradoNH self where FROM UsuarioRegistradoNH as usu where usu.Correo = :p_correo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioRegistradoNHdamePorCorreoHQL");
                query.SetParameter ("p_correo", p_correo);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void ModificarContra (UsuarioRegistradoEN usuarioRegistrado)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioRegistradoNH usuarioRegistradoNH = (UsuarioRegistradoNH)session.Load (typeof(UsuarioRegistradoNH), usuarioRegistrado.UsuarioRegistradoId);

                usuarioRegistradoNH.Pass = usuarioRegistrado.Pass;

                session.Update (usuarioRegistradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnListaDeseos (int p_usuario)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioRegistradoNH self where select art FROM ArticuloNH as art INNER JOIN ListaDeseosNH as lista on art.ArticuloId = lista.Articulo INNER JOIN UsuarioRegistradoNH as u on u.UsuarioRegistradoId = lista.UsuarioRegistrado where u.UsuarioRegistradoId=:p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioRegistradoNHdameArticulosEnListaDeseosHQL");
                query.SetParameter ("p_usuario", p_usuario);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public string DameTokenPorUsuario (int p_usuario)
{
        string result;

        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioRegistradoNH self where SELECT TokenCompartido FROM UsuarioRegistradoNH WHERE usuarioRegistradoId = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioRegistradoNHdameTokenPorUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);


                result = query.UniqueResult<string>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
