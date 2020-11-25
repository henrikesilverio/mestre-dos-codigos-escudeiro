using MDC.Escudeiro.Domain.Models;
using System.Globalization;

namespace MDC.Escudeiro.Domain.Abstract
{
    public abstract class AbstractExercise
    {
        public abstract CommandNode[] GetBranches(CommandNode parent);

        protected NumberFormatInfo GetNumberFormatInfo(string value)
        {
            var separator = value.Contains(".") ? "." : ",";
            return new NumberFormatInfo() { NumberDecimalSeparator = separator };
        }
    }
}