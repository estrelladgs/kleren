
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
 * Clase ImagenResena:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ImagenResenaRepository : BasicRepository, IImagenResenaRepository
{
public ImagenResenaRepository() : base ()
{
}


public ImagenResenaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ImagenResenaEN ReadOIDDefault (int imagenResenaId
                                      )
{
        ImagenResenaEN imagenResenaEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenResenaEN = (ImagenResenaEN)session.Get (typeof(ImagenResenaNH), imagenResenaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenResenaEN;
}

public System.Collections.Generic.IList<ImagenResenaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ImagenResenaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ImagenResenaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ImagenResenaEN>();
                        else
                                result = session.CreateCriteria (typeof(ImagenResenaNH)).List<ImagenResenaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ImagenResenaEN imagenResena)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenResenaNH imagenResenaNH = (ImagenResenaNH)session.Load (typeof(ImagenResenaNH), imagenResena.ImagenResenaId);


                imagenResenaNH.RutaArchivo = imagenResena.RutaArchivo;


                imagenResenaNH.TextoAlternativo = imagenResena.TextoAlternativo;

                session.Update (imagenResenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nueva (ImagenResenaEN imagenResena)
{
        ImagenResenaNH imagenResenaNH = new ImagenResenaNH (imagenResena);

        try
        {
                SessionInitializeTransaction ();
                if (imagenResena.Resena != null) {
                        // Argumento OID y no colección.
                        imagenResenaNH
                        .Resena = (KlerenGen.ApplicationCore.EN.Kleren.ResenaEN)session.Load (typeof(KlerenGen.ApplicationCore.EN.Kleren.ResenaEN), imagenResena.Resena.ResenaId);

                        imagenResenaNH.Resena.Imagen
                                = imagenResenaNH;
                }

                session.Save (imagenResenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return imagenResenaNH.ImagenResenaId;
}

public void Modificar (ImagenResenaEN imagenResena)
{
        try
        {
                SessionInitializeTransaction ();
                ImagenResenaNH imagenResenaNH = (ImagenResenaNH)session.Load (typeof(ImagenResenaNH), imagenResena.ImagenResenaId);

                imagenResenaNH.RutaArchivo = imagenResena.RutaArchivo;


                imagenResenaNH.TextoAlternativo = imagenResena.TextoAlternativo;

                session.Update (imagenResenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int imagenResenaId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ImagenResenaNH imagenResenaNH = (ImagenResenaNH)session.Load (typeof(ImagenResenaNH), imagenResenaId);
                session.Delete (imagenResenaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ImagenResenaEN
public ImagenResenaEN DamePorId (int imagenResenaId
                                 )
{
        ImagenResenaEN imagenResenaEN = null;

        try
        {
                SessionInitializeTransaction ();
                imagenResenaEN = (ImagenResenaEN)session.Get (typeof(ImagenResenaNH), imagenResenaId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return imagenResenaEN;
}

public System.Collections.Generic.IList<ImagenResenaEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ImagenResenaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ImagenResenaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ImagenResenaEN>();
                else
                        result = session.CreateCriteria (typeof(ImagenResenaNH)).List<ImagenResenaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN> DameImagenesPorResena (int p_resena)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ImagenResenaNH self where select imgs FROM ImagenResenaNH as imgs where imgs.Resena.ResenaId = :p_resena";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ImagenResenaNHdameImagenesPorResenaHQL");
                query.SetParameter ("p_resena", p_resena);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ImagenResenaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ImagenResenaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
