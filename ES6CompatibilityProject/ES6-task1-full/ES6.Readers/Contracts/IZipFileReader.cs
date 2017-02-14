using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES6.Readers.Contracts
{
    public interface IZipFileReader
    {
        DirectoryInfo[] ExtractToFolder();
    }
}
