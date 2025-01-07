
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
 * Clase Color:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ColorRepository : BasicRepository, IColorRepository
{
public ColorRepository() : base ()
{
}


public ColorRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ColorEN ReadOIDDefault (int colorId
                               )
{
        ColorEN colorEN = null;

        try
        {
                SessionInitializeTransaction ();
                colorEN = (ColorEN)session.Get (typeof(ColorNH), colorId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return colorEN;
}

public System.Collections.Generic.IList<ColorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ColorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ColorNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ColorEN>();
                        else
                                result = session.CreateCriteria (typeof(ColorNH)).List<ColorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ColorEN color)
{
        try
        {
                SessionInitializeTransaction ();
                ColorNH colorNH = (ColorNH)session.Load (typeof(ColorNH), color.ColorId);


                colorNH.Nombre = color.Nombre;


                colorNH.Codigo = color.Codigo;

                session.Update (colorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ColorEN color)
{
        ColorNH colorNH = new ColorNH (color);

        try
        {
                SessionInitializeTransaction ();

                session.Save (colorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return colorNH.ColorId;
}

public void Modificar (ColorEN color)
{
        try
        {
                SessionInitializeTransaction ();
                ColorNH colorNH = (ColorNH)session.Load (typeof(ColorNH), color.ColorId);

                colorNH.Nombre = color.Nombre;


                colorNH.Codigo = color.Codigo;

                session.Update (colorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int colorId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ColorNH colorNH = (ColorNH)session.Load (typeof(ColorNH), colorId);
                session.Delete (colorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ColorEN
public ColorEN DamePorId (int colorId
                          )
{
        ColorEN colorEN = null;

        try
        {
                SessionInitializeTransaction ();
                colorEN = (ColorEN)session.Get (typeof(ColorNH), colorId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return colorEN;
}

public System.Collections.Generic.IList<ColorEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ColorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ColorNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ColorEN>();
                else
                        result = session.CreateCriteria (typeof(ColorNH)).List<ColorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ColorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
