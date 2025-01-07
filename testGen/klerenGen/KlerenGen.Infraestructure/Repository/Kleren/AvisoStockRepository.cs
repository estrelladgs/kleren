
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
 * Clase AvisoStock:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class AvisoStockRepository : BasicRepository, IAvisoStockRepository
{
public AvisoStockRepository() : base ()
{
}


public AvisoStockRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AvisoStockEN ReadOIDDefault (int avisoId
                                    )
{
        AvisoStockEN avisoStockEN = null;

        try
        {
                SessionInitializeTransaction ();
                avisoStockEN = (AvisoStockEN)session.Get (typeof(AvisoStockNH), avisoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return avisoStockEN;
}

public System.Collections.Generic.IList<AvisoStockEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AvisoStockEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AvisoStockNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AvisoStockEN>();
                        else
                                result = session.CreateCriteria (typeof(AvisoStockNH)).List<AvisoStockEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AvisoStockEN avisoStock)
{
        try
        {
                SessionInitializeTransaction ();
                AvisoStockNH avisoStockNH = (AvisoStockNH)session.Load (typeof(AvisoStockNH), avisoStock.AvisoId);


                avisoStockNH.Email = avisoStock.Email;


                avisoStockNH.Estado = avisoStock.Estado;

                session.Update (avisoStockNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (AvisoStockEN avisoStock)
{
        AvisoStockNH avisoStockNH = new AvisoStockNH (avisoStock);

        try
        {
                SessionInitializeTransaction ();
                if (avisoStock.Variante != null) {
                        // Argumento OID y no colección.
                        avisoStockNH
                        .Variante = (KlerenGen.ApplicationCore.EN.Kleren.VarianteEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.VarianteEN), avisoStock.Variante.VarianteId);

                        avisoStockNH.Variante.AvisoStock
                        .Add (avisoStockNH);
                }

                session.Save (avisoStockNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return avisoStockNH.AvisoId;
}

public void Modificar (AvisoStockEN avisoStock)
{
        try
        {
                SessionInitializeTransaction ();
                AvisoStockNH avisoStockNH = (AvisoStockNH)session.Load (typeof(AvisoStockNH), avisoStock.AvisoId);

                avisoStockNH.Email = avisoStock.Email;


                avisoStockNH.Estado = avisoStock.Estado;

                session.Update (avisoStockNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int avisoId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                AvisoStockNH avisoStockNH = (AvisoStockNH)session.Load (typeof(AvisoStockNH), avisoId);
                session.Delete (avisoStockNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: AvisoStockEN
public AvisoStockEN DamePorId (int avisoId
                               )
{
        AvisoStockEN avisoStockEN = null;

        try
        {
                SessionInitializeTransaction ();
                avisoStockEN = (AvisoStockEN)session.Get (typeof(AvisoStockNH), avisoId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return avisoStockEN;
}

public System.Collections.Generic.IList<AvisoStockEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<AvisoStockEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AvisoStockNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AvisoStockEN>();
                else
                        result = session.CreateCriteria (typeof(AvisoStockNH)).List<AvisoStockEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> DamePorVarianteYEstado (int p_variante, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum ? p_estado)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM AvisoStockNH self where select aviso FROM AvisoStockNH as aviso inner join VarianteNH as var on var.VarianteId = aviso.Variante and aviso.Variante = :p_variante and aviso.Estado = :p_estado";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("AvisoStockNHdamePorVarianteYEstadoHQL");
                query.SetParameter ("p_variante", p_variante);
                query.SetParameter ("p_estado", p_estado);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in AvisoStockRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
