
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
 * Clase Porcentaje:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class PorcentajeRepository : BasicRepository, IPorcentajeRepository
{
public PorcentajeRepository() : base ()
{
}


public PorcentajeRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PorcentajeEN ReadOIDDefault (int id
                                    )
{
        PorcentajeEN porcentajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                porcentajeEN = (PorcentajeEN)session.Get (typeof(PorcentajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return porcentajeEN;
}

public System.Collections.Generic.IList<PorcentajeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PorcentajeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PorcentajeNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PorcentajeEN>();
                        else
                                result = session.CreateCriteria (typeof(PorcentajeNH)).List<PorcentajeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PorcentajeEN porcentaje)
{
        try
        {
                SessionInitializeTransaction ();
                PorcentajeNH porcentajeNH = (PorcentajeNH)session.Load (typeof(PorcentajeNH), porcentaje.Id);



                porcentajeNH.Porcentaje = porcentaje.Porcentaje;

                session.Update (porcentajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (PorcentajeEN porcentaje)
{
        PorcentajeNH porcentajeNH = new PorcentajeNH (porcentaje);

        try
        {
                SessionInitializeTransaction ();
                if (porcentaje.Composicion != null) {
                        // Argumento OID y no colección.
                        porcentajeNH
                        .Composicion = (KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ComposicionEN), porcentaje.Composicion.ComposicionId);

                        porcentajeNH.Composicion.Porcentaje
                        .Add (porcentajeNH);
                }
                if (porcentaje.Material != null) {
                        // Argumento OID y no colección.
                        porcentajeNH
                        .Material = (KlerenGen.ApplicationCore.EN.Kleren.MaterialEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.MaterialEN), porcentaje.Material.Id);

                        porcentajeNH.Material.Porcentaje
                        .Add (porcentajeNH);
                }

                session.Save (porcentajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return porcentajeNH.Id;
}

public void Modificar (PorcentajeEN porcentaje)
{
        try
        {
                SessionInitializeTransaction ();
                PorcentajeNH porcentajeNH = (PorcentajeNH)session.Load (typeof(PorcentajeNH), porcentaje.Id);

                porcentajeNH.Porcentaje = porcentaje.Porcentaje;

                session.Update (porcentajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int id
                    )
{
        try
        {
                SessionInitializeTransaction ();
                PorcentajeNH porcentajeNH = (PorcentajeNH)session.Load (typeof(PorcentajeNH), id);
                session.Delete (porcentajeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: PorcentajeEN
public PorcentajeEN DamePorId (int id
                               )
{
        PorcentajeEN porcentajeEN = null;

        try
        {
                SessionInitializeTransaction ();
                porcentajeEN = (PorcentajeEN)session.Get (typeof(PorcentajeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return porcentajeEN;
}

public System.Collections.Generic.IList<PorcentajeEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<PorcentajeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PorcentajeNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PorcentajeEN>();
                else
                        result = session.CreateCriteria (typeof(PorcentajeNH)).List<PorcentajeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in PorcentajeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
