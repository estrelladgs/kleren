
using System;
using KlerenGen.ApplicationCore.EN.Kleren;
using KlerenGen.ApplicationCore.CP.Kleren;

namespace KlerenGen.ApplicationCore.IRepository.Kleren
{
public partial interface ITallaRepository
{
void setSessionCP (GenericSessionCP session);

TallaEN ReadOIDDefault (int tallaId
                        );

void ModifyDefault (TallaEN talla);

System.Collections.Generic.IList<TallaEN> ReadAllDefault (int first, int size);



int NuevaTalla (TallaEN talla);

void ModficarTalla (TallaEN talla);


void BorrarTalla (int tallaId
                  );


TallaEN DamePorId (int tallaId
                   );


System.Collections.Generic.IList<TallaEN> DameTodos (int first, int size);
}
}
