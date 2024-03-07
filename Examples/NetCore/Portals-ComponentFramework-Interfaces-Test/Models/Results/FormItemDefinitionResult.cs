using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Results
{
    public class FormItemDefinitionResult
    {
        public string Id { get; set; }

        public IDictionary<string, string> Name { get; set; }

        public string ItemVisibility { get; set; }

        public bool? IsModified { get; set; }

        public bool? IsInherited { get; set; }

        public bool? IsOverridden { get; set; }

        public bool? IsAutoDiscovered { get; set; }

        public bool? IsRequired { get; set; }

        public int? SortOrder { get; set; }

        public string DataType { get; set; }

        public CurrentValueResult CurrentValue { get; set; }

        public ValueResult DefaultValue { get; set; }

        public List<AllowedValue> AllowedValues { get; set; }

        public bool? IsArrayType { get; set; }

        public bool? IsDynamicAllowedValues { get; set; }

        public bool? RequiresServerSideValidation { get; set; }
    }
}
