
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
 * Clase ParteArriba:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ParteArribaRepository : BasicRepository, IParteArribaRepository
{
public ParteArribaRepository() : base ()
{
}


public ParteArribaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ParteArribaEN ReadOIDDefault (int tallaId
                                     )
{
        ParteArribaEN parteArribaEN = null;

        try
        {
                SessionInitializeTransaction ();
                parteArribaEN = (ParteArribaEN)session.Get (typeof(ParteArribaNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return parteArribaEN;
}

public System.Collections.Generic.IList<ParteArribaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ParteArribaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ParteArribaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ParteArribaEN>();
                        else
                                result = session.CreateCriteria (typeof(ParteArribaNH)).List<ParteArribaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ParteArribaEN parteArriba)
{
        try
        {
                SessionInitializeTransaction ();
                ParteArribaNH parteArribaNH = (ParteArribaNH)session.Load (typeof(ParteArribaNH), parteArriba.TallaId);

                parteArribaNH.Pecho = parteArriba.Pecho;


                parteArribaNH.Largo = parteArriba.Largo;


                parteArribaNH.Hombros = parteArriba.Hombros;

                session.Update (parteArribaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ParteArribaEN parteArriba)
{
        ParteArribaNH parteArribaNH = new ParteArribaNH (parteArriba);

        try
        {
                SessionInitializeTransaction ();

                session.Save (parteArribaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return parteArribaNH.TallaId;
}

public void Modificar (ParteArribaEN parteArriba)
{
        try
        {
                SessionInitializeTransaction ();
                ParteArribaNH parteArribaNH = (ParteArribaNH)session.Load (typeof(ParteArribaNH), parteArriba.TallaId);

                parteArribaNH.Talla = parteArriba.Talla;


                parteArribaNH.Pecho = parteArriba.Pecho;


                parteArribaNH.Largo = parteArriba.Largo;


                parteArribaNH.Hombros = parteArriba.Hombros;

                session.Update (parteArribaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
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
                ParteArribaNH parteArribaNH = (ParteArribaNH)session.Load (typeof(ParteArribaNH), tallaId);
                session.Delete (parteArribaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ParteArribaEN
public ParteArribaEN DamePorId (int tallaId
                                )
{
        ParteArribaEN parteArribaEN = null;

        try
        {
                SessionInitializeTransaction ();
                parteArribaEN = (ParteArribaEN)session.Get (typeof(ParteArribaNH), tallaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return parteArribaEN;
}

public System.Collections.Generic.IList<ParteArribaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ParteArribaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ParteArribaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ParteArribaEN>();
                else
                        result = session.CreateCriteria (typeof(ParteArribaNH)).List<ParteArribaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ParteArribaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
