
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IArticuloRepository
{
void setSessionCP (GenericSessionCP session);

ArticuloEN ReadOIDDefault (int articuloId
                           );

void ModifyDefault (ArticuloEN articulo);

System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size);



int Nuevo (ArticuloEN articulo);

void Modificar (ArticuloEN articulo);


void Borrar (int articuloId
             );


ArticuloEN DamePorId (int articuloId
                      );


System.Collections.Generic.IList<ArticuloEN> DameTodos (int first, int size);



System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorSexoYTipoPrenda (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum? p_sexo, KlerenGen.ApplicationCore.Enumerated.Kleren.TipoPrendaEnum ? p_categoria);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorNombre (string p_input);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorColor (KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorMaterial (KlerenGen.ApplicationCore.Enumerated.Kleren.MaterialEnum ? p_material);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosPorRangoPrecio (int? p_precio_min, int ? p_precio_max);


void AsociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs);

void DesasociarCuidado (int p_Articulo_OID, System.Collections.Generic.IList<int> p_cuidados_OIDs);

System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.ArticuloEN> DameArticulosEnPromocionPorSexo (KlerenGen.ApplicationCore.Enumerated.Kleren.SexoEnum ? p_sexo);





System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantes (int p_articulo);


System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.VarianteEN> DameVariantesPorColor (int p_articulo, KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum ? p_color);
}
}
