
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
 * Clase Articulo:
 *
 */

namespace KlerenGen.Infraestructure.Repository.Kleren
{
public partial class ArticuloRepository : BasicRepository, IArticuloRepository
{
public ArticuloRepository() : base ()
{
}


public ArticuloRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ArticuloEN ReadOIDDefault (int articuloId
                                  )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), articuloId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ArticuloNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                        else
                                result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.ArticuloId);

                articuloNH.Precio = articulo.Precio;


                articuloNH.Categoria = articulo.Categoria;


                articuloNH.Sexo = articulo.Sexo;


                articuloNH.Promocion = articulo.Promocion;


                articuloNH.Precio_oferta = articulo.Precio_oferta;




                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Trazabilidad = articulo.Trazabilidad;




                articuloNH.Parte = articulo.Parte;


                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Nuevo (ArticuloEN articulo)
{
        ArticuloNH articuloNH = new ArticuloNH (articulo);

        try
        {
                SessionInitializeTransaction ();

                session.Save (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return articuloNH.ArticuloId;
}

public void Modificar (ArticuloEN articulo)
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articulo.ArticuloId);

                articuloNH.Precio = articulo.Precio;


                articuloNH.Categoria = articulo.Categoria;


                articuloNH.Sexo = articulo.Sexo;


                articuloNH.Promocion = articulo.Promocion;


                articuloNH.Precio_oferta = articulo.Precio_oferta;


                articuloNH.Nombre = articulo.Nombre;


                articuloNH.Trazabilidad = articulo.Trazabilidad;


                articuloNH.Parte = articulo.Parte;

                session.Update (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Borrar (int articuloId
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ArticuloNH articuloNH = (ArticuloNH)session.Load (typeof(ArticuloNH), articuloId);
                session.Delete (articuloNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: DamePorId
//Con e: ArticuloEN
public ArticuloEN DamePorId (int articuloId
                             )
{
        ArticuloEN articuloEN = null;

        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Get (typeof(ArticuloNH), articuloId);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return articuloEN;
}

public System.Collections.Generic.IList<ArticuloEN> DameTodos (int first, int size)
{
        System.Collections.Generic.IList<ArticuloEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ArticuloNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ArticuloEN>();
                else
                        result = session.CreateCriteria (typeof(ArticuloNH)).List<ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorSexoYTipoPrenda (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum? p_sexo, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum ? p_categoria)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select art FROM ArticuloNH as art where art.Sexo = :p_sexo and art.Categoria = :p_categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosPorSexoYTipoPrendaHQL");
                query.SetParameter ("p_sexo", p_sexo);
                query.SetParameter ("p_categoria", p_categoria);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorNombre (string p_input)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select art FROM ArticuloNH as art where art.Nombre like :p_input";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosPorNombreHQL");
                query.SetParameter ("p_input", p_input);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorColor (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select distinct art FROM ArticuloNH as art inner join VarianteNH as var on art.ArticuloId = var.Articulo inner join ColorNH as color on var.Color = color.ColorId where color.Nombre = :p_color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosPorColorHQL");
                query.SetParameter ("p_color", p_color);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorMaterial (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum ? p_material)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select distinct art FROM ArticuloNH as art inner join ComposicionNH as comp on art.Composicion = comp.ComposicionId inner join PorcentajeNH as por on por.Composicion = comp.ComposicionId inner join MaterialNH as mat on por.Material = mat.Id where mat.Material = :p_material";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosPorMaterialHQL");
                query.SetParameter ("p_material", p_material);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorRangoPrecio (int? p_precio_min, int ? p_precio_max)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select art from ArticuloNH as art where art.Precio >= :p_precio_min and art.Precio <= :p_precio_max";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosPorRangoPrecioHQL");
                query.SetParameter ("p_precio_min", p_precio_min);
                query.SetParameter ("p_precio_max", p_precio_max);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AsociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs)
{
        KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articuloEN = null;
        try
        {
                SessionInitializeTransaction ();
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);
                KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN cuidadosENAux = null;
                if (articuloEN.Cuidados == null) {
                        articuloEN.Cuidados = new System.Collections.Generic.List<KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN>();
                }

                foreach (int item in p_cuidados_OIDs) {
                        cuidadosENAux = new KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN ();
                        cuidadosENAux = (KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN)session.Load (typeof(KlerenGen.Infraestructure.EN.Kleren.CuidadoNH), item);
                        cuidadosENAux.Articulos.Add (articuloEN);

                        articuloEN.Cuidados.Add (cuidadosENAux);
                }


                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DesasociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN articuloEN = null;
                articuloEN = (ArticuloEN)session.Load (typeof(ArticuloNH), p_Articulo_OID);

                KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN cuidadosENAux = null;
                if (articuloEN.Cuidados != null) {
                        foreach (int item in p_cuidados_OIDs) {
                                cuidadosENAux = (KlerenGen.ApplicationCore.EN.Kleren.CuidadoEN)session.Load (typeof(KlerenGen.Infraestructure.EN.Kleren.CuidadoNH), item);
                                if (articuloEN.Cuidados.Contains (cuidadosENAux) == true) {
                                        articuloEN.Cuidados.Remove (cuidadosENAux);
                                        cuidadosENAux.Articulos.Remove (articuloEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_cuidados_OIDs you are trying to unrelationer, doesn't exist in ArticuloEN");
                        }
                }

                session.Update (articuloEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnPromocionPorSexo (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum ? p_sexo)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where select art FROM ArticuloNH as art where art.Sexo = :p_sexo and art.Promocion = true";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameArticulosEnPromocionPorSexoHQL");
                query.SetParameter ("p_sexo", p_sexo);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantes (int p_articulo)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where SELECT var FROM VarianteNH as var WHERE var.Articulo.ArticuloId = :p_articulo";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameVariantesHQL");
                query.SetParameter ("p_articulo", p_articulo);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantesPorColor (int p_articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color)
{
        System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ArticuloNH self where SELECT var FROM VarianteNH as var WHERE var.Articulo.ArticuloId = :p_articulo and var.Color.ColorId = :p_color";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ArticuloNHdameVariantesPorColorHQL");
                query.SetParameter ("p_articulo", p_articulo);
                query.SetParameter ("p_color", p_color);

                result = query.List<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is KlerenGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new KlerenGen.ApplicationCore.Exceptions.DataLayerException ("Error in ArticuloRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
