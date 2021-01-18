using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System;

namespace MDC.Escudeiro.Domain.Builders
{
    public class RootCommandNodeBuilder : INodeBuilder
    {
        private readonly CommandNode _commandNode;
        private readonly ChildrenCommandNodeBuilder _childrenCommandNodeBuilder;

        public RootCommandNodeBuilder()
        {
            _commandNode = new CommandNode();
            _childrenCommandNodeBuilder = new ChildrenCommandNodeBuilder(_commandNode);
        }

        public CommandNode Build()
        {
            _childrenCommandNodeBuilder.Build();
            return _commandNode;
        }

        public RootCommandNodeBuilder SetTitle(string title)
        {
            _commandNode.Title = title;
            return this;
        }

        public RootCommandNodeBuilder AddChild(INodeBuilder nodeBuilder)
        {
            _childrenCommandNodeBuilder.AddChild(nodeBuilder);
            return this;
        }

        public RootCommandNodeBuilder AddChild(Action action, string title)
        {
            _childrenCommandNodeBuilder.AddChild(new LeafCommandNodeBuilder().SetAction(action).SetTitle(title));
            return this;
        }
    }
}