using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Domain.Builders
{
    public class LeafCommandNodeBuilder : INodeBuilder
    {
        private readonly CommandNode _commandNode;

        public LeafCommandNodeBuilder()
        {
            _commandNode = new CommandNode();
        }

        public CommandNode Build()
        {
            return _commandNode;
        }

        public LeafCommandNodeBuilder SetAction(Action action)
        {
            _commandNode.Action = action;
            return this;
        }

        public LeafCommandNodeBuilder SetTitle(string title)
        {
            _commandNode.Title = title;
            return this;
        }
    }
}