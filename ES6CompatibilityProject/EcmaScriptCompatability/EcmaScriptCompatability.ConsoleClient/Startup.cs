using EcmaScriptCompatability.Exporter;
using EcmaScriptCompatability.Exporter.Models;
using EcmaScriptCompatability.Service.Contracts;
using Ninject;
using System.Reflection;

namespace EcmaScriptCompatability.ConsoleClient
{
    class Startup
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new EsModule());

            IReportService service = kernel.Get<IReportService>();

            var result = service.ExtractPlatformReport();

            var export = new XmlExporter<PlatformXmlModel>();
            export.ExportReport(result);

        }
    }
}
