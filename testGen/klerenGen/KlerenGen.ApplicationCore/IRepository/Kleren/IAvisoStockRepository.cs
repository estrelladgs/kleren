
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface IAvisoStockRepository
{
void setSessionCP (GenericSessionCP session);

AvisoStockEN ReadOIDDefault (int avisoId
                             );

void ModifyDefault (AvisoStockEN avisoStock);

System.Collections.Generic.IList<AvisoStockEN> ReadAllDefault (int first, int size);



int Nuevo (AvisoStockEN avisoStock);

void Modificar (AvisoStockEN avisoStock);


void Borrar (int avisoId
             );


AvisoStockEN DamePorId (int avisoId
                        );


System.Collections.Generic.IList<AvisoStockEN> DameTodos (int first, int size);



System.Collections.Generic.IList<KlerenGen.ApplicationCore.EN.Kleren.AvisoStockEN> DamePorVarianteYEstado (int p_variante, KlerenGen.ApplicationCore.Enumerated.Kleren.EstadoAvisoStockEnum ? p_estado);
}
}
