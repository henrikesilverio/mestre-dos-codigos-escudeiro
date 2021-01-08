namespace MDC.Escudeiro.Domain.Models
{
    public class Televisao : ControleDireto
    {
        public string MostrarDados()
        {
            return $"Informações da televisão, Volume: {Volume} | Canal: {Canal}";
        }
    }
}