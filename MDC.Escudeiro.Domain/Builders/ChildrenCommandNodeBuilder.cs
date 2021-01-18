using MDC.Escudeiro.Domain.Interfaces;
using MDC.Escudeiro.Domain.Models;
using System.Collections.Generic;

namespace MDC.Escudeiro.Domain.Builders
{
    public class ChildrenCommandNodeBuilder : INodeBuilder
    {
        private readonly CommandNode _parent;
        private readonly List<CommandNode> _children;

        public ChildrenCommandNodeBuilder(CommandNode parent)
        {
            _parent = parent;
            _children = new List<CommandNode>();
        }

        public CommandNode Build()
        {
            var order = 0;

            foreach (var child in _children)
            {
                child.Order = order++;
                child.Parent = _parent;
            }

            _parent.Branches = _children.ToArray();

            return _parent;
        }

        public ChildrenCommandNodeBuilder AddChild(INodeBuilder nodeBuilder)
        {
            _children.Add(nodeBuilder.Build());
            return this;
        }
    }
}