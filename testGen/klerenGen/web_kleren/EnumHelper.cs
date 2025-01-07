using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace KlerenGen.ApplicationCore.Helpers
{

    public static class EnumHelper
    {

        public static List<SelectListItem> GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            // Para pasar la primera letra del nombre a mayusculas
            var cultureInfo = new CultureInfo("es-ES");
            var textInfo = cultureInfo.TextInfo;

            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>() 
                       .Select(e => new SelectListItem
                       {
                           Text = textInfo.ToTitleCase(e.ToString().ToLower()),
                           Value = ((int)(object)e).ToString() 
                       })
                       .ToList();
        }
    } 
}
