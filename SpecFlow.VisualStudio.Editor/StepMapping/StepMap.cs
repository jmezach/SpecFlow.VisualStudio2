using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.LanguageServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.VisualStudio.Editor.StepMapping
{
    [Export(typeof(StepMap))]
    internal class StepMap
    {
        private readonly VisualStudioWorkspace _workspace;

        [ImportingConstructor]
        internal StepMap(VisualStudioWorkspace workspace)
        {
            if (workspace == null)
            {
                throw new ArgumentNullException(nameof(workspace));
            }

            _workspace = workspace;
            _workspace.WorkspaceChanged += OnWorkspaceChanged;
        }

        private async void OnWorkspaceChanged(object sender, WorkspaceChangeEventArgs args)
        {
            await BuildStepMap();   
        }

        private async Task BuildStepMap()
        {
            foreach (var project in _workspace.CurrentSolution.Projects)
            {
                if (!project.MetadataReferences.Any(reference => reference.Display.Contains("TechTalk.SpecFlow")))
                {
                    continue;
                }

                var compilation = await project.GetCompilationAsync();
                var stepDefinitions = compilation.Assembly.Accept(new StepMappingSymbolVisitor());
            }
        }
    }
}
