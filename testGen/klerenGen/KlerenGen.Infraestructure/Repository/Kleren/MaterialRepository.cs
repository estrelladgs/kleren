
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
 * Clase Material:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class MaterialRepository : BasicRepository, IMaterialRepository
{
public MaterialRepository() : base ()
{
}


public MaterialRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MaterialEN ReadOIDDefault (int id
                                  )
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MaterialNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MaterialEN>();
                        else
                                result = session.CreateCriteria (typeof(MaterialNH)).List<MaterialEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                MaterialNH materialNH = (MaterialNH)session.Load (typeof(MaterialNH), material.Id);

                materialNH.Material = material.Material;


                session.Update (materialNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (MaterialEN material)
{
        MaterialNH materialNH = new MaterialNH (material);

        try
        {
                SessionInitializeTransaction ();

                session.Save (materialNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return materialNH.Id;
}

public void Modificar (MaterialEN material)
{
        try
        {
                SessionInitializeTransaction ();
                MaterialNH materialNH = (MaterialNH)session.Load (typeof(MaterialNH), material.Id);

                materialNH.Material = material.Material;

                session.Update (materialNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
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
                MaterialNH materialNH = (MaterialNH)session.Load (typeof(MaterialNH), id);
                session.Delete (materialNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: MaterialEN
public MaterialEN DamePorId (int id
                             )
{
        MaterialEN materialEN = null;

        try
        {
                SessionInitializeTransaction ();
                materialEN = (MaterialEN)session.Get (typeof(MaterialNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return materialEN;
}

public System.Collections.Generic.IList<MaterialEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<MaterialEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MaterialNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MaterialEN>();
                else
                        result = session.CreateCriteria (typeof(MaterialNH)).List<MaterialEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in MaterialRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
