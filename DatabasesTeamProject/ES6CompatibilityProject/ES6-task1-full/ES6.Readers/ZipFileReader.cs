using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Readers.Contracts;

namespace ES6.Readers
{
    public class ZipFileReader : IZipFileReader
    {
        private const string zipPath = @"../../../es6-support-data.zip";
        private const string extractFolder = @"../../../es6-support-data";

        public ZipFileReader()
        {
        }

        public DirectoryInfo[] ExtractToFolder()
        {
            if (!Directory.Exists(extractFolder))
            {
                ZipFile.ExtractToDirectory(zipPath, extractFolder);
            }

            DirectoryInfo root = new DirectoryInfo(extractFolder);
            var folders = root.GetDirectories();

            return folders;
        }
    }
}
