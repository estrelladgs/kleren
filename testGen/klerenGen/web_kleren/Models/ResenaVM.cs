namespace web_kleren.Models
{
    public class ResenaVM
    {
        public int ResenaId { get; set; }

        public int Estrellas { get; set; }


        public string Valoracion { get; set; }


        public DateTime fecha { get; set; }


        public string rutaFoto { get; set; }

        public string altFoto { get; set; }
    }
}
