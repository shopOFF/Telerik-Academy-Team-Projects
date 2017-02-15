using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ES6.Data;
using ES6.Importers.Contracts;
using ES6.ParseModels.Support;
using ES6.Readers.Contracts;

namespace ES6.Importers
{
    public class ExcelImporter : IExcelImporter
    {
        private IZipFileReader zipReader;
        private ICollection<Support> support;

        public ExcelImporter(IZipFileReader zipReader)
        {
            this.zipReader = zipReader;
            this.support = new HashSet<Support>();
        }

        public void ImportData()
        {
            var folders = zipReader.ExtractToFolder();
            ReadFromExcelFile(folders);
            PopulateDatabase();
        }

        private void ReadFromExcelFile(DirectoryInfo[] folders)
        {
            foreach (var folder in folders)
            {
                var platformId = int.Parse(folder.FullName.Split('\\').Last());
                var excelFile = folder.GetFiles()[0];

                var connection = new OleDbConnection($"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = {excelFile.FullName};Extended Properties = \"Excel 12.0 Xml;HDR=YES\";");
                connection.Open();

                using (connection)
                {
                    DataTable tables = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    var tableName = tables.Rows[0]["TABLE_NAME"];

                    var getSupportCommand = new OleDbCommand($"SELECT * FROM [{tableName}]", connection);
                    var reader = getSupportCommand.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            var featureIndex = (double)reader["feature-id"];
                            var isSupported = (string)reader["is-supported"];

                            this.support.Add(new Support()
                            {
                                FeatureId = (int)featureIndex,
                                PlatformId = platformId,
                                IsSupported = isSupported
                            });
                        }
                    }
                }
                connection.Close();
            }
        }

        private void PopulateDatabase()
        {
            using (var db = new Es6DbContext())
            {
                var counter = 0;
                foreach (var s in support)
                {
                    db.Support.Add(s);

                    counter++;
                    if (counter % 10 == 0)
                    {
                        db.SaveChanges();
                    }
                }

                db.SaveChanges();
            }
        }
    }
}
