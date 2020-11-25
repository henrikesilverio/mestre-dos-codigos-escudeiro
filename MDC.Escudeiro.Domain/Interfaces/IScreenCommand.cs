namespace MDC.Escudeiro.Domain.Interfaces
{
    public interface IScreenCommand
    {
        string InputValue(string text);

        void PrintBigText(string text);

        void PrintOption(string text, string markCharacter);

        void PrintResult(string text);
    }
}