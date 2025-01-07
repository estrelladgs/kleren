using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class CreateImagenVarianteAssembler
    {
        public CreateImagenVarianteViewModel ConvertirToViewModel(ImagenVarianteViewModel imagenVariante, IEnumerable<ColorViewModel> colores)
        {

            CreateImagenVarianteViewModel createImage = new CreateImagenVarianteViewModel();
            
            createImage.ImagenVariante = imagenVariante;
            createImage.Colores = colores;

            return createImage;
        }
    }
}

