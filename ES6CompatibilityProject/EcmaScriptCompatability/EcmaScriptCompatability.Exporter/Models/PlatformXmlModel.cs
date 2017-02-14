using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EcmaScriptCompatability.Exporter.Models
{
    [Serializable]
    public class PlatformXmlModel
    {
        public string Name { get; set; }

        [XmlArrayItem(ElementName = "developer")]
        public List<DeveloperXmlModel> Developers { get; set; }
    }
}
