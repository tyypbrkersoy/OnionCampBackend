using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninoCamp.Infrastructure.Operations
{
    public static class NameOperation
    {
        public static string ChracterRegulatory(string name)
            => name.Replace("\"", "")
                .Replace("!", "")
                .Replace("'", "")
                .Replace("^", "")
                .Replace("+", "")
                .Replace("%", "")
                .Replace("&", "")
                .Replace("/", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("=", "")
                .Replace("?", "")
                .Replace("-", "")
                .Replace("@", "")
                .Replace("€", "")
                .Replace("~", "")
                .Replace("¨", "")
                .Replace("~", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace(",", "")
                .Replace("<", "")
                .Replace(">", "")
                .Replace("|", "")
                .Replace("£", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("½", "")
                .Replace("{", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("}", "")
                .Replace("´", "")
                .Replace("`", "")
                .Replace("é", "")
                .Replace(".", "_")
                .Replace("Ö", "O")
                .Replace("ö", "o")
                .Replace("Ü", "U")
                .Replace("ü", "u")
                .Replace("İ", "I")
                .Replace("ı", "i")
                .Replace("Ğ", "G")
                .Replace("ğ", "g")
                .Replace("ü", "u")
                .Replace("Ş", "S")
                .Replace("ş", "s")
                .Replace("Ç", "C")
                .Replace("ç", "c")
                .Replace(" ","_");
    }
}
