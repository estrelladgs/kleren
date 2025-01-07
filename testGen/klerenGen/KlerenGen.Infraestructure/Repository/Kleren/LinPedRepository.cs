
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
 * Clase LinPed:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class LinPedRepository : BasicRepository, ILinPedRepository
{
public LinPedRepository() : base ()
{
}


public LinPedRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LinPedEN ReadOIDDefault (int lineaId
                                )
{
        LinPedEN linPedEN = null;

        try
        {
                SessionInitializeTransaction ();
                linPedEN = (LinPedEN)session.Get (typeof(LinPedNH), lineaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return linPedEN;
}

public System.Collections.Generic.IList<LinPedEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LinPedEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LinPedNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LinPedEN>();
                        else
                                result = session.CreateCriteria (typeof(LinPedNH)).List<LinPedEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LinPedEN linPed)
{
        try
        {
                SessionInitializeTransaction ();
                LinPedNH linPedNH = (LinPedNH)session.Load (typeof(LinPedNH), linPed.LineaId);

                linPedNH.Cantidad = linPed.Cantidad;



                linPedNH.Precio = linPed.Precio;


                session.Update (linPedNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (LinPedEN linPed)
{
        LinPedNH linPedNH = new LinPedNH (linPed);

        try
        {
                SessionInitializeTransaction ();
                if (linPed.Pedido != null) {
                        // Argumento OID y no colección.
                        linPedNH
                        .Pedido = (KlerenGen.ApplicationCore.EN.Kleren.PedidoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.PedidoEN), linPed.Pedido.PedidoId);

                        linPedNH.Pedido.LinPed
                        .Add (linPedNH);
                }
                if (linPed.Variante != null) {
                        // Argumento OID y no colección.
                        linPedNH
                        .Variante = (KlerenGen.ApplicationCore.EN.Kleren.VarianteEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.VarianteEN), linPed.Variante.VarianteId);

                        linPedNH.Variante.LinPed
                        .Add (linPedNH);
                }

                session.Save (linPedNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return linPedNH.LineaId;
}

public void Modificar (LinPedEN linPed)
{
        try
        {
                SessionInitializeTransaction ();
                LinPedNH linPedNH = (LinPedNH)session.Load (typeof(LinPedNH), linPed.LineaId);

                linPedNH.Cantidad = linPed.Cantidad;

                session.Update (linPedNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int lineaId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                LinPedNH linPedNH = (LinPedNH)session.Load (typeof(LinPedNH), lineaId);
                session.Delete (linPedNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: LinPedEN
public LinPedEN DamePorId (int lineaId
                           )
{
        LinPedEN linPedEN = null;

        try
        {
                SessionInitializeTransaction ();
                linPedEN = (LinPedEN)session.Get (typeof(LinPedNH), lineaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return linPedEN;
}

public System.Collections.Generic.IList<LinPedEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<LinPedEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LinPedNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<LinPedEN>();
                else
                        result = session.CreateCriteria (typeof(LinPedNH)).List<LinPedEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.LinPedEN DamePorPedidoYVariante (int p_variante, int p_pedido)
{
        KlerenGen.ApplicationCore.EN.Kleren.LinPedEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM LinPedNH self where select lin FROM LinPedNH as lin where lin.Pedido.PedidoId = :p_pedido and lin.Variante.VarianteId = :p_variante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("LinPedNHdamePorPedidoYVarianteHQL");
                query.SetParameter ("p_variante", p_variante);
                query.SetParameter ("p_pedido", p_pedido);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.LinPedEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in LinPedRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
