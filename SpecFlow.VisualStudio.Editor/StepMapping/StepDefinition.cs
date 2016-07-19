using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.VisualStudio.Editor.StepMapping
{
    internal class StepDefinition
    {
        internal StepDefinition(StepDefinitionType type, string regex)
        {
            this.Type = type;
            this.Regex = regex;
        }

        internal StepDefinitionType Type
        {
            get;
            private set;
        }

        internal string Regex
        {
            get;
            private set;
        }
    }
}
