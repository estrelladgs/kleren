using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertirENToViewModel (UsuarioRegistradoEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel ();
            usu.UsuarioRegistradoId = en.UsuarioRegistradoId; ;
            usu.Correo = en.Correo;
            usu.Apellidos = en.Apellidos;
            usu.Telefono = en.Telefono;
            usu.Nombre = en.Nombre;
            usu.Pass = en.Pass;

            return usu;

           

        }

   

        public MedidasViewModel ConvertirENToViewModel(MedidasUsuarioEN en)
        {
           MedidasViewModel medidas = new MedidasViewModel ();
            medidas.Caderas = en.Caderas;
            medidas.LargoPierna = en.LargoPierna;
            medidas.LargoBrazo = en.LargoBrazo;
            medidas.Cintura = en.Cintura;
            medidas.AnchoEspalda = en.AnchoEspalda;
            medidas.Pecho = en.Pecho;

            return medidas;

        }

        public DatosViewModel ConvertirENToViewModel2(UsuarioRegistradoEN en)
        {
            DatosViewModel datosVM = new DatosViewModel
            {
                UsuarioRegistradoId = en.UsuarioRegistradoId,
                Nombre = en.Nombre,
                Apellidos = en.Apellidos,
                Correo = en.Correo,
                Telefono = en.Telefono

            };

            return datosVM;
        }

        public ContraViewModel ConvertirENToViewModel3(UsuarioRegistradoEN en)
        {
            ContraViewModel contraVM = new ContraViewModel
            {
                Pass = en.Pass // El campo de contraseña actual
            };

            return contraVM;
        }



    }


}
