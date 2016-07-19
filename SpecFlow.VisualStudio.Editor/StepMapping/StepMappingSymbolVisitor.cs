using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.VisualStudio.Editor.StepMapping
{
    internal class StepMappingSymbolVisitor : SymbolVisitor<IEnumerable<StepDefinition>>
    {
        public override IEnumerable<StepDefinition> VisitAssembly(IAssemblySymbol symbol)
        {
            var result = new List<StepDefinition>();
            foreach (var ns in symbol.GlobalNamespace.GetNamespaceMembers())
            {
                result.AddRange(ns.Accept(this) ?? Enumerable.Empty<StepDefinition>());
            }

            return result;
        }

        public override IEnumerable<StepDefinition> VisitNamespace(INamespaceSymbol symbol)
        {
            var result = new List<StepDefinition>();
            foreach (var childSymbol in symbol.GetMembers())
            {
                result.AddRange(childSymbol.Accept(this) ?? Enumerable.Empty<StepDefinition>());
            }

            return result;
        }

        public override IEnumerable<StepDefinition> VisitNamedType(INamedTypeSymbol symbol)
        {
            if (!symbol.GetAttributes().Any(attribute => attribute.AttributeClass.ToDisplayString().Equals("TechTalk.SpecFlow.BindingAttribute", StringComparison.OrdinalIgnoreCase)))
            {
                return base.VisitNamedType(symbol);
            }

            var result = new List<StepDefinition>();
            foreach (var member in symbol.GetMembers())
            {
                result.AddRange(member.Accept(this) ?? Enumerable.Empty<StepDefinition>());
            }

            return result;
        }

        public override IEnumerable<StepDefinition> VisitMethod(IMethodSymbol symbol)
        {
            foreach (var attribute in symbol.GetAttributes())
            {
                if (attribute.AttributeClass.ToDisplayString().Equals("TechTalk.SpecFlow.GivenAttribute", StringComparison.OrdinalIgnoreCase))
                {
                    yield return new StepDefinition(StepDefinitionType.Given, attribute.ConstructorArguments.FirstOrDefault().Value.ToString());
                }
                else if (attribute.AttributeClass.ToDisplayString().Equals("TechTalk.SpecFlow.WhenAttribute", StringComparison.OrdinalIgnoreCase))
                {
                    yield return new StepDefinition(StepDefinitionType.When, attribute.ConstructorArguments.FirstOrDefault().Value.ToString());
                }
                else if (attribute.AttributeClass.ToDisplayString().Equals("TechTalk.SpecFlow.ThenAttribute", StringComparison.OrdinalIgnoreCase))
                {
                    yield return new StepDefinition(StepDefinitionType.Then, attribute.ConstructorArguments.FirstOrDefault().Value.ToString());
                }
            }
        }
    }
}
