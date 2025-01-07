
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
 * Clase MedidasUsuario:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class MedidasUsuarioRepository : BasicRepository, IMedidasUsuarioRepository
{
public MedidasUsuarioRepository() : base ()
{
}


public MedidasUsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MedidasUsuarioEN ReadOIDDefault (int medidasUsuarioId
                                        )
{
        MedidasUsuarioEN medidasUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                medidasUsuarioEN = (MedidasUsuarioEN)session.Get (typeof(MedidasUsuarioNH), medidasUsuarioId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return medidasUsuarioEN;
}

public System.Collections.Generic.IList<MedidasUsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MedidasUsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MedidasUsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MedidasUsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(MedidasUsuarioNH)).List<MedidasUsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MedidasUsuarioEN medidasUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                MedidasUsuarioNH medidasUsuarioNH = (MedidasUsuarioNH)session.Load (typeof(MedidasUsuarioNH), medidasUsuario.MedidasUsuarioId);

                medidasUsuarioNH.Cintura = medidasUsuario.Cintura;


                medidasUsuarioNH.Pecho = medidasUsuario.Pecho;


                medidasUsuarioNH.AnchoEspalda = medidasUsuario.AnchoEspalda;


                medidasUsuarioNH.Caderas = medidasUsuario.Caderas;


                medidasUsuarioNH.LargoBrazo = medidasUsuario.LargoBrazo;


                medidasUsuarioNH.LargoPierna = medidasUsuario.LargoPierna;



                medidasUsuarioNH.TallaIdealSuperior = medidasUsuario.TallaIdealSuperior;


                medidasUsuarioNH.TallaIdealInferior = medidasUsuario.TallaIdealInferior;

                session.Update (medidasUsuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MedidasUsuarioEN medidasUsuario)
{
        MedidasUsuarioNH medidasUsuarioNH = new MedidasUsuarioNH (medidasUsuario);

        try
        {
                SessionInitializeTransaction ();
                if (medidasUsuario.UsuarioRegistrado != null) {
                        // Argumento OID y no colección.
                        medidasUsuarioNH
                        .UsuarioRegistrado = (KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.UsuarioRegistradoEN), medidasUsuario.UsuarioRegistrado.UsuarioRegistradoId);

                        medidasUsuarioNH.UsuarioRegistrado.MedidasUsuario
                                = medidasUsuarioNH;
                }

                session.Save (medidasUsuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return medidasUsuarioNH.MedidasUsuarioId;
}

public void Modificar (MedidasUsuarioEN medidasUsuario)
{
        try
        {
                SessionInitializeTransaction ();
                MedidasUsuarioNH medidasUsuarioNH = (MedidasUsuarioNH)session.Load (typeof(MedidasUsuarioNH), medidasUsuario.MedidasUsuarioId);

                medidasUsuarioNH.Cintura = medidasUsuario.Cintura;


                medidasUsuarioNH.Pecho = medidasUsuario.Pecho;


                medidasUsuarioNH.AnchoEspalda = medidasUsuario.AnchoEspalda;


                medidasUsuarioNH.Caderas = medidasUsuario.Caderas;


                medidasUsuarioNH.LargoBrazo = medidasUsuario.LargoBrazo;


                medidasUsuarioNH.LargoPierna = medidasUsuario.LargoPierna;

                session.Update (medidasUsuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int medidasUsuarioId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                MedidasUsuarioNH medidasUsuarioNH = (MedidasUsuarioNH)session.Load (typeof(MedidasUsuarioNH), medidasUsuarioId);
                session.Delete (medidasUsuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: MedidasUsuarioEN
public MedidasUsuarioEN DamePorId (int medidasUsuarioId
                                   )
{
        MedidasUsuarioEN medidasUsuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                medidasUsuarioEN = (MedidasUsuarioEN)session.Get (typeof(MedidasUsuarioNH), medidasUsuarioId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return medidasUsuarioEN;
}

public System.Collections.Generic.IList<MedidasUsuarioEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MedidasUsuarioEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MedidasUsuarioNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MedidasUsuarioEN>();
                else
                        result = session.CreateCriteria (typeof(MedidasUsuarioNH)).List<MedidasUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN DameMedidasUsuario (int p_usuario)
{
        KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM MedidasUsuarioNH self where select med FROM MedidasUsuarioNH as med where med.UsuarioRegistrado.UsuarioRegistradoId = :p_usuario";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("MedidasUsuarioNHdameMedidasUsuarioHQL");
                query.SetParameter ("p_usuario", p_usuario);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.MedidasUsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MedidasUsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
