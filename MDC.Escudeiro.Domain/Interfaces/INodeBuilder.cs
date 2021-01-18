using MDC.Escudeiro.Domain.Models;

namespace MDC.Escudeiro.Domain.Interfaces
{
    public interface INodeBuilder
    {
        CommandNode Build();
    }
}