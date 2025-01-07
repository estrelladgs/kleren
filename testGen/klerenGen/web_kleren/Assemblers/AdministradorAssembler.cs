using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class AdministradorAssembler
    {
        // Convierte un modelo de dominio a un modelo de vista
        public AdministradorViewModel ConvertirENToViewModel(AdministradorEN en)
        {
            if (en == null)
            {
                // Retornar un objeto vacío o con valores predeterminados
                return new AdministradorViewModel();
            }

            AdministradorViewModel admin = new AdministradorViewModel();
            admin.AdministradorId = en.AdminId;
            admin.Correo = en.Correo;
            admin.Pass = en.Pass;
            admin.Apellidos = en.Apellidos;
            admin.Telefono = en.Telefono;
            admin.Nombre = en.Nombre;
            admin.Dni = en.Dni;

            return admin;
        }

    }
}
