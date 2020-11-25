using System;

namespace MDC.Escudeiro.Domain.Models
{
    public class CommandNode
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public Action Action { get; set; }
        public CommandNode Parent { get; set; }
        public CommandNode[] Branches { get; set; }
    }
}