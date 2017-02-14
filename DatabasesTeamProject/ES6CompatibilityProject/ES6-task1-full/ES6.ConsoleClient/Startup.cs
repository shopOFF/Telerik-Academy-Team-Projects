using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ES6.Data;
using ES6.Data.Contracts;
using ES6.Importers;
using ES6.Models.Features;
using ES6.Models.Platforms;
using ES6.ParseModels.Support;
using ES6.Readers;

namespace ES6.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var mongoReader = new MongoReader();
            var mongoImporter = new MongoImporter(mongoReader);

            mongoImporter.ImportData();

            var zipReader = new ZipFileReader();
            var excelImporter = new ExcelImporter(zipReader);
            excelImporter.ImportData();
        }
    }
}
