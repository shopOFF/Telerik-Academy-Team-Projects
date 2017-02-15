using System.Collections.Generic;
using EcmaScriptCompatability.Exporter.Models;

namespace EcmaScriptCompatability.Service.Contracts
{
    public interface IReportService
    {
        IEnumerable<PlatformXmlModel> ExtractPlatformReport();
    }
}