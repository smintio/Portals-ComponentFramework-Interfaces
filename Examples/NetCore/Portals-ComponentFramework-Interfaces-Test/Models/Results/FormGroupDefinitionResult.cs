using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class FormGroupDefinitionResult
    {
        public string Id { get; set; }

        public IDictionary<string, string> Name { get; set; }

        public bool? IsDefaultGroup { get; set; }

        public bool? IsModified { get; set; }

        public List<FormItemDefinitionResult> FormItemDefinitions { get; set; }
    }
}
