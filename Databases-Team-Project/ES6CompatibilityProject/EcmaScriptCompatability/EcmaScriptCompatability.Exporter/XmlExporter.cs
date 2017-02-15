using System;
using System.Collections.Generic;
using EcmaScriptCompatability.Exporter.Contracts;
using EcmaScriptCompatability.Exporter.Models;
using System.Xml.Serialization;
using System.IO;

namespace EcmaScriptCompatability.Exporter
{
    public class XmlExporter<T> : IExporter<T>
        where T : PlatformXmlModel
    {
        public void ExportReport(IEnumerable<T> data)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<PlatformXmlModel>), new XmlRootAttribute("Platforms"));
            using (var fs = new FileStream("PlatformDevelopers.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, data);
            }
        }
    }
}
