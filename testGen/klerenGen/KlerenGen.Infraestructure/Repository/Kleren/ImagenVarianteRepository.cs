
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
 * Clase ImagenVariante:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ImagenVarianteRepository : BasicRepository, IImagenVarianteRepository
{
public ImagenVarianteRepository() : base ()
{
}


public ImagenVarianteRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ImagenVarianteEN ReadOIDDefault (int imagenVarianteId
                                        )
{
        ImagenVarianteEN imagenVarianteEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenVarianteEN = (ImagenVarianteEN)session.Get (typeof(ImagenVarianteNH), imagenVarianteId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenVarianteEN;
}

public System.Collections.Generic.IList<ImagenVarianteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ImagenVarianteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ImagenVarianteNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ImagenVarianteEN>();
                        else
                                result = session.CreateCriteria (typeof(ImagenVarianteNH)).List<ImagenVarianteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ImagenVarianteEN imagenVariante)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenVarianteNH imagenVarianteNH = (ImagenVarianteNH)session.Load (typeof(ImagenVarianteNH), imagenVariante.ImagenVarianteId);

                imagenVarianteNH.RutaArchivo = imagenVariante.RutaArchivo;



                imagenVarianteNH.TextoAlternativo = imagenVariante.TextoAlternativo;

                session.Update (imagenVarianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (ImagenVarianteEN imagenVariante)
{
        ImagenVarianteNH imagenVarianteNH = new ImagenVarianteNH (imagenVariante);

        try
        {
                SessionInitializeTransaction ();

                session.Save (imagenVarianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return imagenVarianteNH.ImagenVarianteId;
}

public void Modificar (ImagenVarianteEN imagenVariante)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenVarianteNH imagenVarianteNH = (ImagenVarianteNH)session.Load (typeof(ImagenVarianteNH), imagenVariante.ImagenVarianteId);

                imagenVarianteNH.RutaArchivo = imagenVariante.RutaArchivo;


                imagenVarianteNH.TextoAlternativo = imagenVariante.TextoAlternativo;

                session.Update (imagenVarianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int imagenVarianteId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ImagenVarianteNH imagenVarianteNH = (ImagenVarianteNH)session.Load (typeof(ImagenVarianteNH), imagenVarianteId);
                session.Delete (imagenVarianteNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ImagenVarianteEN
public ImagenVarianteEN DamePorId (int imagenVarianteId
                                   )
{
        ImagenVarianteEN imagenVarianteEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenVarianteEN = (ImagenVarianteEN)session.Get (typeof(ImagenVarianteNH), imagenVarianteId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenVarianteEN;
}

public System.Collections.Generic.IList<ImagenVarianteEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ImagenVarianteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ImagenVarianteNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ImagenVarianteEN>();
                else
                        result = session.CreateCriteria (typeof(ImagenVarianteNH)).List<ImagenVarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN> DameImagenesPorVariante ()
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ImagenVarianteNH self where SELECT img FROM VarianteNH var JOIN var.ImagenVariante img WHERE var.VarianteId = :p_variante";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ImagenVarianteNHdameImagenesPorVarianteHQL");

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AsociarAVariante (int p_ImagenVariante_OID, System.Collections.Generic.IList<int> p_variante_OIDs)
{
        KlerenGen.ApplicationCore.EN.Kleren.ImagenVarianteEN imagenVarianteEN = null;
        try
        {
                SessionInitializeTransaction ();
                imagenVarianteEN = (ImagenVarianteEN)session.Load (typeof(ImagenVarianteNH), p_ImagenVariante_OID);
                KlerenGen.ApplicationCore.EN.Kleren.VarianteEN varianteENAux = null;
                if (imagenVarianteEN.Variante == null) {
                        imagenVarianteEN.Variante = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
                }

                foreach (int item in p_variante_OIDs) {
                        varianteENAux = new KlerenGen.ApplicationCore.EN.Kleren.VarianteEN ();
                        varianteENAux = (KlerenGen.ApplicationCore.EN.Kleren.VarianteEN)session.Load (typeof(KlerenGen.Infraestructure.EN.Kleren.VarianteNH), item);
                        varianteENAux.ImagenVariante = imagenVarianteEN;

                        imagenVarianteEN.Variante.Add (varianteENAux);
                }


                session.Update (imagenVarianteEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenVarianteRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
