namespace web_kleren.Models
{
    public class ColorViewModel
    {
        public int ColorId { get; set; }

        public KlerenGen.ApplicationCore.Enumerated.Kleren.ColorEnum Nombre { get; set; }

        public string Codigo { get; set; }
    }
}
