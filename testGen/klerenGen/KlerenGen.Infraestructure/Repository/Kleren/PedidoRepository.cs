
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
 * Clase Pedido:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class PedidoRepository : BasicRepository, IPedidoRepository
{
public PedidoRepository() : base ()
{
}


public PedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PedidoEN ReadOIDDefault (int pedidoId
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), pedidoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.PedidoId);

                pedidoNH.Estado = pedido.Estado;






                pedidoNH.FechaPagado = pedido.FechaPagado;


                pedidoNH.FechaProcesado = pedido.FechaProcesado;


                pedidoNH.FechaEnviado = pedido.FechaEnviado;


                pedidoNH.FechaEntregado = pedido.FechaEntregado;




                pedidoNH.Total = pedido.Total;


                pedidoNH.TotalDescuento = pedido.TotalDescuento;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.DirEnvio != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .DirEnvio = (KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.DirEnvioEN), pedido.DirEnvio.DirEnvioId);

                        pedidoNH.DirEnvio.Pedidos
                        .Add (pedidoNH);
                }
                if (pedido.MetodoPago != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .MetodoPago = (KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.MetodoPagoEN), pedido.MetodoPago.MetodoId);

                        pedidoNH.MetodoPago.Pedido
                        .Add (pedidoNH);
                }
                if (pedido.UsuarioRegistrado != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .UsuarioRegistrado = (KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN), pedido.UsuarioRegistrado.UsuarioRegistradoId);

                        pedidoNH.UsuarioRegistrado.Pedido
                        .Add (pedidoNH);
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.PedidoId;
}

public void Modificar (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.PedidoId);

                pedidoNH.Estado = pedido.Estado;

                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void BorrarPedido (int pedidoId
                          )
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedidoId);
                session.Delete (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: PedidoEN
public PedidoEN DamePorId (int pedidoId
                           )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), pedidoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PedidoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                else
                        result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePedidosPorUsuario (int ? p_IdUsuario)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoNH self where FROM PedidoNH as ped where ped.UsuarioRegistrado = :p_IdUsuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoNHdamePedidosPorUsuarioHQL");
                query.SetParameter ("p_IdUsuario", p_IdUsuario);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> DamePorEstado (KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoPedidoEnum ? p_Estado)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoNH self where FROM PedidoNH as ped where ped.Estado = :p_Estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoNHdamePorEstadoHQL");
                query.SetParameter ("p_Estado", p_Estado);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
