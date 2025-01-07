
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
 * Clase Administrador:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class AdministradorRepository : BasicRepository, IAdministradorRepository
{
public AdministradorRepository() : base ()
{
}


public AdministradorRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AdministradorEN ReadOIDDefault (int adminId
                                       )
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorNH), adminId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdministradorNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                        else
                                result = session.CreateCriteria (typeof(AdministradorNH)).List<AdministradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), administrador.AdminId);

                administradorNH.Nombre = administrador.Nombre;


                administradorNH.Apellidos = administrador.Apellidos;


                administradorNH.Correo = administrador.Correo;


                administradorNH.Telefono = administrador.Telefono;


                administradorNH.Fecha_nac = administrador.Fecha_nac;


                administradorNH.Dni = administrador.Dni;


                administradorNH.Pass = administrador.Pass;

                session.Update (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (AdministradorEN administrador)
{
        AdministradorNH administradorNH = new AdministradorNH (administrador);

        try
        {
                SessionInitializeTransaction ();

                session.Save (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administradorNH.AdminId;
}

public void Modificar (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), administrador.AdminId);

                administradorNH.Nombre = administrador.Nombre;


                administradorNH.Apellidos = administrador.Apellidos;


                administradorNH.Correo = administrador.Correo;


                administradorNH.Telefono = administrador.Telefono;


                administradorNH.Fecha_nac = administrador.Fecha_nac;


                administradorNH.Dni = administrador.Dni;


                administradorNH.Pass = administrador.Pass;

                session.Update (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int adminId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), adminId);
                session.Delete (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: AdministradorEN
public AdministradorEN DamePorId (int adminId
                                  )
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorNH), adminId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdministradorNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                else
                        result = session.CreateCriteria (typeof(AdministradorNH)).List<AdministradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.AdministradorEN DamePorCorreo (string p_correo)
{
        KlerenGen.ApplicationCore.EN.Kleren.AdministradorEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AdministradorNH self where FROM AdministradorNH as admin where admin.Correo = :p_correo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AdministradorNHdamePorCorreoHQL");
                query.SetParameter ("p_correo", p_correo);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.AdministradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
