using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Domain.Interfaces
{
    public interface IExercise
    {
        Action[] GetActions();

        CommandNode[] GetBranches(CommandNode parent);

        string[] GetOptions();
    }
}