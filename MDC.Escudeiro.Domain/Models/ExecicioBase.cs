using System.Globalization;

namespace MDC.Escudeiro.Domain.Models
{
    public class ExecicioBase
    {
        protected NumberFormatInfo GetNumberFormatInfo(string value)
        {
            var separator = value.Contains(".") ? "." : ",";
            return new NumberFormatInfo() { NumberDecimalSeparator = separator };
        }
    }
}