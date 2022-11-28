using DoQL.Interfaces;
using DoQL.Models;
using System.Text.Json;
namespace DatabaseManager
{


   
    

        class DatabasesManager : IDatabasesManager
        {

            private string dataBasesFolderpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoQL");
            private static DatabasesManager instance = null;
            private DatabasesManager()
            { }
            public static DatabasesManager getInstance()
            {
                if (instance == null)
                {
                    instance = new DatabasesManager();
                }
                return instance;
            }
            public void DeleteDatabase(string id)
            {
                string folderToDeletePath = Path.Combine(dataBasesFolderpath, id);

                if (Directory.Exists(folderToDeletePath))
                {
                    Directory.Delete(folderToDeletePath, true);
                }

            }

            public void ExportDatabase(string id)
            {
                throw new NotImplementedException();
            }

            public Database ImportDatabase(string path)
            {
                throw new NotImplementedException();
            }

            public Database LoadDatabase(string id)
            {
                LoadedDataBaseInFormation loadedDatabaseInformation =
                 new LoadedDataBaseInFormation();
                List<DoQL.Models.Table> loadedDataBaseTables = new List<DoQL.Models.Table> { };
                string folderToLoadPath = Path.Combine(dataBasesFolderpath, id);
                if (Directory.Exists(folderToLoadPath))
                {
                    string indexFile = Path.Combine(folderToLoadPath, "Index.json");
                    if (File.Exists(indexFile))
                    {
                        string readIndexInfo = File.ReadAllText(indexFile);

                        loadedDatabaseInformation = JsonSerializer.Deserialize<LoadedDataBaseInFormation>(readIndexInfo)!;


                    }

                    string tablesFile = Path.Combine(folderToLoadPath, "Tables.json");
                    if (File.Exists(tablesFile))
                    {
                        string readTableInfo = File.ReadAllText(tablesFile);

                        loadedDataBaseTables = JsonSerializer.Deserialize<List<DoQL.Models.Table>>(readTableInfo)!;

                    }


                }



                Database loadedDataBase = new Database()
                {
                    Id = loadedDatabaseInformation.Id,
                    Name = loadedDatabaseInformation.Name,
                    Type = loadedDatabaseInformation.Type,
                    Created = loadedDatabaseInformation.created,
                    LastModified = loadedDatabaseInformation.lastmodified,
                    Tables = loadedDataBaseTables,


                };
                return loadedDataBase;

            }

            public List<Database> LoadDatabases()
            {
                List<Database> loadedDatabases = new List<Database>();
                string[] allFolders = Directory.GetDirectories(dataBasesFolderpath);


                foreach (var folder in allFolders)
                {

                    string id = Path.GetFileName(folder);


                    loadedDatabases.Add(LoadDatabase(id));


                }


                return loadedDatabases;
            }

            public void SaveDatabase(Database db)
            {

                Dictionary<string, object> infoFile = new Dictionary<string, object>();

                infoFile.Add("Name", db.Name);
                infoFile.Add("Id", db.Id);
                infoFile.Add("Type", db.Type);
                infoFile.Add("Created", db.Created);
                infoFile.Add("LastModified", db.LastModified);
                string folderpath = Path.Combine(dataBasesFolderpath, db.Id);
                string infoFilePath = Path.Combine(folderpath, "Index.json");
                string tablesFilePath = Path.Combine(folderpath, "Tables.json");

                Directory.CreateDirectory(folderpath);

                using var info = new FileStream(infoFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                JsonSerializer.Serialize(info, infoFile);


                using var tables = new FileStream(tablesFilePath, FileMode.OpenOrCreate, FileAccess.Write);
                JsonSerializer.Serialize(tables, db.Tables);






            }
        }
    }

