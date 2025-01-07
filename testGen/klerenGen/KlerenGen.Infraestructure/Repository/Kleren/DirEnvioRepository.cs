
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
 * Clase DirEnvio:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class DirEnvioRepository : BasicRepository, IDirEnvioRepository
{
public DirEnvioRepository() : base ()
{
}


public DirEnvioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DirEnvioEN ReadOIDDefault (int dirEnvioId
                                  )
{
        DirEnvioEN dirEnvioEN = null;

        try
        {
                SessionInitializeTransaction ();
                dirEnvioEN = (DirEnvioEN)session.Get (typeof(DirEnvioNH), dirEnvioId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return dirEnvioEN;
}

public System.Collections.Generic.IList<DirEnvioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DirEnvioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DirEnvioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DirEnvioEN>();
                        else
                                result = session.CreateCriteria (typeof(DirEnvioNH)).List<DirEnvioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DirEnvioEN dirEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DirEnvioNH dirEnvioNH = (DirEnvioNH)session.Load (typeof(DirEnvioNH), dirEnvio.DirEnvioId);

                dirEnvioNH.Calle = dirEnvio.Calle;


                dirEnvioNH.Numero = dirEnvio.Numero;


                dirEnvioNH.Escalera = dirEnvio.Escalera;


                dirEnvioNH.Piso = dirEnvio.Piso;


                dirEnvioNH.Puerta = dirEnvio.Puerta;


                dirEnvioNH.CodPost = dirEnvio.CodPost;


                dirEnvioNH.Ciudad = dirEnvio.Ciudad;


                dirEnvioNH.Provincia = dirEnvio.Provincia;



                session.Update (dirEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (DirEnvioEN dirEnvio)
{
        DirEnvioNH dirEnvioNH = new DirEnvioNH (dirEnvio);

        try
        {
                SessionInitializeTransaction ();
                if (dirEnvio.UsuarioRegistrado != null) {
                        // Argumento OID y no colección.
                        dirEnvioNH
                        .UsuarioRegistrado = (KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN), dirEnvio.UsuarioRegistrado.UsuarioRegistradoId);

                        dirEnvioNH.UsuarioRegistrado.DirEnvio
                        .Add (dirEnvioNH);
                }

                session.Save (dirEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return dirEnvioNH.DirEnvioId;
}

public void Modificar (DirEnvioEN dirEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DirEnvioNH dirEnvioNH = (DirEnvioNH)session.Load (typeof(DirEnvioNH), dirEnvio.DirEnvioId);

                dirEnvioNH.Calle = dirEnvio.Calle;


                dirEnvioNH.Numero = dirEnvio.Numero;


                dirEnvioNH.Escalera = dirEnvio.Escalera;


                dirEnvioNH.Piso = dirEnvio.Piso;


                dirEnvioNH.Puerta = dirEnvio.Puerta;


                dirEnvioNH.CodPost = dirEnvio.CodPost;


                dirEnvioNH.Ciudad = dirEnvio.Ciudad;


                dirEnvioNH.Provincia = dirEnvio.Provincia;

                session.Update (dirEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int dirEnvioId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                DirEnvioNH dirEnvioNH = (DirEnvioNH)session.Load (typeof(DirEnvioNH), dirEnvioId);
                session.Delete (dirEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: DirEnvioEN
public DirEnvioEN DamePorId (int dirEnvioId
                             )
{
        DirEnvioEN dirEnvioEN = null;

        try
        {
                SessionInitializeTransaction ();
                dirEnvioEN = (DirEnvioEN)session.Get (typeof(DirEnvioNH), dirEnvioId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return dirEnvioEN;
}

public System.Collections.Generic.IList<DirEnvioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<DirEnvioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DirEnvioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DirEnvioEN>();
                else
                        result = session.CreateCriteria (typeof(DirEnvioNH)).List<DirEnvioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in DirEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
