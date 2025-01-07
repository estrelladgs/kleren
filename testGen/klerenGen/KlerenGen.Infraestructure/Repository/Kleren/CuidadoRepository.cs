
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
 * Clase Cuidado:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class CuidadoRepository : BasicRepository, ICuidadoRepository
{
public CuidadoRepository() : base ()
{
}


public CuidadoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public CuidadoEN ReadOIDDefault (int cuiadoId
                                 )
{
        CuidadoEN cuidadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cuidadoEN = (CuidadoEN)session.Get (typeof(CuidadoNH), cuiadoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return cuidadoEN;
}

public System.Collections.Generic.IList<CuidadoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CuidadoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CuidadoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<CuidadoEN>();
                        else
                                result = session.CreateCriteria (typeof(CuidadoNH)).List<CuidadoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CuidadoEN cuidado)
{
        try
        {
                SessionInitializeTransaction ();
                CuidadoNH cuidadoNH = (CuidadoNH)session.Load (typeof(CuidadoNH), cuidado.CuiadoId);

                cuidadoNH.Nombre = cuidado.Nombre;


                session.Update (cuidadoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (CuidadoEN cuidado)
{
        CuidadoNH cuidadoNH = new CuidadoNH (cuidado);

        try
        {
                SessionInitializeTransaction ();

                session.Save (cuidadoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return cuidadoNH.CuiadoId;
}

public void Modificar (CuidadoEN cuidado)
{
        try
        {
                SessionInitializeTransaction ();
                CuidadoNH cuidadoNH = (CuidadoNH)session.Load (typeof(CuidadoNH), cuidado.CuiadoId);

                cuidadoNH.Nombre = cuidado.Nombre;

                session.Update (cuidadoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int cuiadoId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                CuidadoNH cuidadoNH = (CuidadoNH)session.Load (typeof(CuidadoNH), cuiadoId);
                session.Delete (cuidadoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: CuidadoEN
public CuidadoEN DamePorId (int cuiadoId
                            )
{
        CuidadoEN cuidadoEN = null;

        try
        {
                SessionInitializeTransaction ();
                cuidadoEN = (CuidadoEN)session.Get (typeof(CuidadoNH), cuiadoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return cuidadoEN;
}

public System.Collections.Generic.IList<CuidadoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<CuidadoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CuidadoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<CuidadoEN>();
                else
                        result = session.CreateCriteria (typeof(CuidadoNH)).List<CuidadoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in CuidadoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
