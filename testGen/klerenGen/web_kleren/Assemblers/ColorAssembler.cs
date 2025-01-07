using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class ColorAssembler
    {
        public ColorViewModel ConvertirENToViewModel(ColorEN en)
        {
            ColorViewModel color = new ColorViewModel();
            color.ColorId = en.ColorId;
            color.Nombre = en.Nombre;
            color.Codigo = en.Codigo;

            return color;
        }

        public IList<ColorViewModel> ConvertirListENToViewModel(IList<ColorEN> ens)
        {
            IList<ColorViewModel> colors = new List<ColorViewModel>();
            foreach (ColorEN en in ens)
            {
                colors.Add(ConvertirENToViewModel(en));
            }
            return colors;
        }
    }
}
