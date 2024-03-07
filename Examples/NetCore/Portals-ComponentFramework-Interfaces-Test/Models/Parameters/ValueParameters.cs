using System.Collections.Generic;

namespace Portals.ComponentFramework.Interfaces.Test.Models.Parameters
{
    public class ValueParameters
    {
        public string Id { get; set; }

        public string DataType { get; set; }

        public string StringValue { get; set; }

        public List<string> StringArrayValue { get; set; }
    }

}