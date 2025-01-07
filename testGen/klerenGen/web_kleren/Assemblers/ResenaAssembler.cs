using KlerenGen.ApplicationCore.EN.Kleren;
using web_kleren.Models;

namespace web_kleren.Assemblers
{
    public class ResenaAssembler
    {
        public ResenaVM ConvertirENToViewModel(ResenaEN resena, IList<ImagenResenaEN> imgsEN)
        {
            ResenaVM res = new ResenaVM();
            
            res.ResenaId = res.ResenaId;
            res.Valoracion = res.Valoracion;
        
            res.fecha = res.fecha;

            if (imgsEN != null && imgsEN.Count > 0) {
                res.rutaFoto = imgsEN[0].RutaArchivo;
            } 

            return res;
        }

    }
}
