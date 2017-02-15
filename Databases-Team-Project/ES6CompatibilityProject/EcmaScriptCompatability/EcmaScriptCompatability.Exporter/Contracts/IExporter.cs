using System.Collections.Generic;

namespace EcmaScriptCompatability.Exporter.Contracts
{
    public interface IExporter<T>
    {
        void ExportReport(IEnumerable<T> data);
    }
}
