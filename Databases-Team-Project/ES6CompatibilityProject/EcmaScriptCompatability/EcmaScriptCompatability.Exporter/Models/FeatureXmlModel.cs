using System;
using System.Xml.Serialization;

namespace EcmaScriptCompatability.Exporter.Models
{
    [Serializable]
    public class FeatureXmlModel
    {
        [XmlElement]
        public string Name { get; set; }
    }
}
