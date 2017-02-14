using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EcmaScriptCompatability.Exporter.Models
{
    [Serializable]
    public class DeveloperXmlModel
    {
        public string Name { get; set; }

        [XmlArrayItem(ElementName = "feature")]
        public List<FeatureXmlModel> Features { get; set; }
    }
}
