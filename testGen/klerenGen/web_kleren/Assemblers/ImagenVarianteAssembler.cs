using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class ImagenVarianteAssembler
    {
        public ImagenVarianteViewModel ConvertirENToViewModel(ImagenVarianteEN en)
        {
            ImagenVarianteViewModel img = new ImagenVarianteViewModel();
            img.ImagenVarianteId = en.ImagenVarianteId;
            img.RutaArchivoString = en.RutaArchivo;
            img.TextoAlternativo = en.TextoAlternativo;

            return img;
        }

        public IList<ImagenVarianteViewModel> ConvertirListENToViewModel(IList<ImagenVarianteEN> ens)
        {
            IList<ImagenVarianteViewModel> imgs = new List<ImagenVarianteViewModel>();
            foreach (ImagenVarianteEN en in ens)
            {
                imgs.Add(ConvertirENToViewModel(en));
            }
            return imgs;
        }
    }
}
