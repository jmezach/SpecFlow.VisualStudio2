﻿using Microsoft.VisualStudio.Text.Classification;

namespace SpecFlow.VisualStudio.Editor.Classification
{
    public class GherkinFileEditorClassifications
    {
        public readonly IClassificationType Keyword;
        public readonly IClassificationType KeywordGiven;
        public readonly IClassificationType KeywordWhen;
        public readonly IClassificationType KeywordThen;
        public readonly IClassificationType Comment;
        public readonly IClassificationType Tag;
        public readonly IClassificationType MultilineText;
        public readonly IClassificationType Placeholder;
        public readonly IClassificationType ScenarioTitle;
        public readonly IClassificationType FeatureTitle;
        public readonly IClassificationType TableCell;
        public readonly IClassificationType TableHeader;
        public readonly IClassificationType Description;
        public readonly IClassificationType StepText;
        public readonly IClassificationType UnboundStepText;
        public readonly IClassificationType StepArgument;

        public GherkinFileEditorClassifications(IClassificationTypeRegistryService registry)
        {
            Keyword = registry.GetClassificationType("gherkin.keyword");
            KeywordGiven = registry.GetClassificationType("gherkin.keywordgiven");
            KeywordWhen = registry.GetClassificationType("gherkin.keywordwhen");
            KeywordThen = registry.GetClassificationType("gherkin.keywordthen");
            Comment = registry.GetClassificationType("gherkin.comment");
            Tag = registry.GetClassificationType("gherkin.tag");
            MultilineText = registry.GetClassificationType("gherkin.multilinetext");
            Placeholder = registry.GetClassificationType("gherkin.placeholder");
            ScenarioTitle = registry.GetClassificationType("gherkin.scenariotitle");
            FeatureTitle = registry.GetClassificationType("gherkin.featuretitle");
            TableCell = registry.GetClassificationType("gherkin.tablecell");
            TableHeader = registry.GetClassificationType("gherkin.tableheader");
            Description = registry.GetClassificationType("gherkin.description");
            StepText = registry.GetClassificationType("gherkin.steptext");
            UnboundStepText = registry.GetClassificationType("gherkin.unboundsteptext");
            StepArgument = registry.GetClassificationType("gherkin.stepargument");
        }
    }
}