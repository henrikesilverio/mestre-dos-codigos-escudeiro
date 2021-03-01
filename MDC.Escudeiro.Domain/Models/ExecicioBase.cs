using MDC.Escudeiro.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MDC.Escudeiro.Domain.Models
{
    public class ExecicioBase
    {
        private readonly IScreenCommand _screenCommand;

        public ExecicioBase(IScreenCommand screenCommand)
        {
            _screenCommand = screenCommand;
        }

        protected NumberFormatInfo GetNumberFormatInfo(string value)
        {
            var separator = value.Contains(".") ? "." : ",";
            return new NumberFormatInfo() { NumberDecimalSeparator = separator };
        }

        protected void ValidateList<T>(IList<T> list, string messagem, Action callback)
        {
            if (list == null || !list.Any())
            {
                _screenCommand.PrintError(messagem);
                return;
            }

            callback();
        }
    }
}