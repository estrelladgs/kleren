
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
 * Clase Devolucion:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class DevolucionRepository : BasicRepository, IDevolucionRepository
{
public DevolucionRepository() : base ()
{
}


public DevolucionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DevolucionEN ReadOIDDefault (int devolucionId
                                    )
{
        DevolucionEN devolucionEN = null;

        try
        {
                SessionInitializeTransaction ();
                devolucionEN = (DevolucionEN)session.Get (typeof(DevolucionNH), devolucionId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return devolucionEN;
}

public System.Collections.Generic.IList<DevolucionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DevolucionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DevolucionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DevolucionEN>();
                        else
                                result = session.CreateCriteria (typeof(DevolucionNH)).List<DevolucionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DevolucionEN devolucion)
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), devolucion.DevolucionId);

                devolucionNH.Estado = devolucion.Estado;


                devolucionNH.MotivoRechazo = devolucion.MotivoRechazo;


                session.Update (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (DevolucionEN devolucion)
{
        DevolucionNH devolucionNH = new DevolucionNH (devolucion);

        try
        {
                SessionInitializeTransaction ();
                if (devolucion.Pedido != null) {
                        // Argumento OID y no colección.
                        devolucionNH
                        .Pedido = (KlerenGen.ApplicationCore.EN.Kleren.PedidoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.PedidoEN), devolucion.Pedido.PedidoId);

                        devolucionNH.Pedido.Devolucion
                                = devolucionNH;
                }

                session.Save (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return devolucionNH.DevolucionId;
}

public void Modificar (DevolucionEN devolucion)
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), devolucion.DevolucionId);

                devolucionNH.Estado = devolucion.Estado;


                devolucionNH.MotivoRechazo = devolucion.MotivoRechazo;

                session.Update (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int devolucionId
                      )
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), devolucionId);
                session.Delete (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: DevolucionEN
public DevolucionEN DamePorId (int devolucionId
                               )
{
        DevolucionEN devolucionEN = null;

        try
        {
                SessionInitializeTransaction ();
                devolucionEN = (DevolucionEN)session.Get (typeof(DevolucionNH), devolucionId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return devolucionEN;
}

public System.Collections.Generic.IList<DevolucionEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<DevolucionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DevolucionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DevolucionEN>();
                else
                        result = session.CreateCriteria (typeof(DevolucionNH)).List<DevolucionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
