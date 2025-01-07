
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
 * Clase ParteAbajo:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ParteAbajoRepository : BasicRepository, IParteAbajoRepository
{
public ParteAbajoRepository() : base ()
{
}


public ParteAbajoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ParteAbajoEN ReadOIDDefault (int tallaId
                                    )
{
        ParteAbajoEN parteAbajoEN = null;

        try
        {
                SessionInitializeTransaction ();
                parteAbajoEN = (ParteAbajoEN)session.Get (typeof(ParteAbajoNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return parteAbajoEN;
}

public System.Collections.Generic.IList<ParteAbajoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ParteAbajoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ParteAbajoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ParteAbajoEN>();
                        else
                                result = session.CreateCriteria (typeof(ParteAbajoNH)).List<ParteAbajoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ParteAbajoEN parteAbajo)
{
        try
        {
                SessionInitializeTransaction ();
                ParteAbajoNH parteAbajoNH = (ParteAbajoNH)session.Load (typeof(ParteAbajoNH), parteAbajo.TallaId);

                parteAbajoNH.Cintura = parteAbajo.Cintura;


                parteAbajoNH.Cadera = parteAbajo.Cadera;


                parteAbajoNH.Largo = parteAbajo.Largo;

                session.Update (parteAbajoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ParteAbajoEN parteAbajo)
{
        ParteAbajoNH parteAbajoNH = new ParteAbajoNH (parteAbajo);

        try
        {
                SessionInitializeTransaction ();

                session.Save (parteAbajoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return parteAbajoNH.TallaId;
}

public void Modificar (ParteAbajoEN parteAbajo)
{
        try
        {
                SessionInitializeTransaction ();
                ParteAbajoNH parteAbajoNH = (ParteAbajoNH)session.Load (typeof(ParteAbajoNH), parteAbajo.TallaId);

                parteAbajoNH.Talla = parteAbajo.Talla;


                parteAbajoNH.Cintura = parteAbajo.Cintura;


                parteAbajoNH.Cadera = parteAbajo.Cadera;


                parteAbajoNH.Largo = parteAbajo.Largo;

                session.Update (parteAbajoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int tallaId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ParteAbajoNH parteAbajoNH = (ParteAbajoNH)session.Load (typeof(ParteAbajoNH), tallaId);
                session.Delete (parteAbajoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ParteAbajoEN
public ParteAbajoEN DamePorId (int tallaId
                               )
{
        ParteAbajoEN parteAbajoEN = null;

        try
        {
                SessionInitializeTransaction ();
                parteAbajoEN = (ParteAbajoEN)session.Get (typeof(ParteAbajoNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return parteAbajoEN;
}

public System.Collections.Generic.IList<ParteAbajoEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ParteAbajoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ParteAbajoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ParteAbajoEN>();
                else
                        result = session.CreateCriteria (typeof(ParteAbajoNH)).List<ParteAbajoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteAbajoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
