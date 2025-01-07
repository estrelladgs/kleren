
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
 * Clase Variante:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class VarianteRepository : BasicRepository, IVarianteRepository
{
public VarianteRepository() : base ()
{
}


public VarianteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public VarianteEN ReadOIDDefault (int varianteId
                                  )
{
        VarianteEN varianteEN = null;

        try
        {
                SessionInitializeTransaction ();
                varianteEN = (VarianteEN)session.Get (typeof(VarianteNH), varianteId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return varianteEN;
}

public System.Collections.Generic.IList<VarianteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VarianteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VarianteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<VarianteEN>();
                        else
                                result = session.CreateCriteria (typeof(VarianteNH)).List<VarianteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VarianteEN variante)
{
        try
        {
                SessionInitializeTransaction ();
                VarianteNH varianteNH = (VarianteNH)session.Load (typeof(VarianteNH), variante.VarianteId);

                varianteNH.Stock = variante.Stock;







                session.Update (varianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (VarianteEN variante)
{
        VarianteNH varianteNH = new VarianteNH (variante);

        try
        {
                SessionInitializeTransaction ();
                if (variante.Articulo != null) {
                        // Argumento OID y no colección.
                        varianteNH
                        .Articulo = (KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN), variante.Articulo.ArticuloId);

                        varianteNH.Articulo.Variante
                        .Add (varianteNH);
                }
                if (variante.Talla != null) {
                        // Argumento OID y no colección.
                        varianteNH
                        .Talla = (KlerenGen.ApplicationCore.EN.Kleren.TallaEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.TallaEN), variante.Talla.TallaId);

                        varianteNH.Talla.Variantes
                        .Add (varianteNH);
                }
                if (variante.Color != null) {
                        // Argumento OID y no colección.
                        varianteNH
                        .Color = (KlerenGen.ApplicationCore.EN.Kleren.ColorEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ColorEN), variante.Color.ColorId);

                        varianteNH.Color.Variante
                        .Add (varianteNH);
                }

                session.Save (varianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return varianteNH.VarianteId;
}

public void Modificar (VarianteEN variante)
{
        try
        {
                SessionInitializeTransaction ();
                VarianteNH varianteNH = (VarianteNH)session.Load (typeof(VarianteNH), variante.VarianteId);

                varianteNH.Stock = variante.Stock;

                session.Update (varianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int varianteId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                VarianteNH varianteNH = (VarianteNH)session.Load (typeof(VarianteNH), varianteId);
                session.Delete (varianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: VarianteEN
public VarianteEN DamePorId (int varianteId
                             )
{
        VarianteEN varianteEN = null;

        try
        {
                SessionInitializeTransaction ();
                varianteEN = (VarianteEN)session.Get (typeof(VarianteNH), varianteId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return varianteEN;
}

public System.Collections.Generic.IList<VarianteEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<VarianteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VarianteNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<VarianteEN>();
                else
                        result = session.CreateCriteria (typeof(VarianteNH)).List<VarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public KlerenGen.ApplicationCore.EN.Kleren.VarianteEN DamePorTallaYColorYArticulo (int p_talla, int p_color, int p_articulo)
{
        KlerenGen.ApplicationCore.EN.Kleren.VarianteEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VarianteNH self where Select var FROM VarianteNH as var where var.Talla.TallaId = :p_talla and var.Color.ColorId = :p_color and var.Articulo.ArticuloId = :p_articulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VarianteNHdamePorTallaYColorYArticuloHQL");
                query.SetParameter ("p_talla", p_talla);
                query.SetParameter ("p_color", p_color);
                query.SetParameter ("p_articulo", p_articulo);


                result = query.UniqueResult<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in VarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
