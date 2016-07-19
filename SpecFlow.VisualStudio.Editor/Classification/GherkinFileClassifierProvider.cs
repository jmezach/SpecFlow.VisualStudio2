﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using SpecFlow.VisualStudio.Editor.Parser;
using Microsoft.VisualStudio.LanguageServices;
using SpecFlow.VisualStudio.Editor.StepMapping;

namespace SpecFlow.VisualStudio.Editor.Classification
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("gherkin")]
    internal class GherkinFileClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IBufferTagAggregatorFactoryService AggregatorFactory = null;

        [Import]
        internal IClassificationTypeRegistryService ClassificationTypeRegistry = null;

        [Import]
        internal StepMap StepMap = null;

        public IClassifier GetClassifier(ITextBuffer buffer)
        {
            var gherkinTagAggregator = AggregatorFactory.CreateTagAggregator<GherkinTokenTag>(buffer);

            return new GherkinFileClassifier(buffer, gherkinTagAggregator, ClassificationTypeRegistry);
        }
    }
}
