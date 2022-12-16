using DoQL.Interfaces;
using DoQL.Models;
using System.Text.Json;
using System.IO.Compression;
using DoQL.Utilities;
using DoQL.Models.ERD;

namespace DoQL
{
    class DatabasesManager : IDatabasesManager
    {

        private string _dataBasesFolderPath =
         Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DoQL");
        private static DatabasesManager _instance = null;
        private DatabasesManager()
        { }
        public static DatabasesManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DatabasesManager();
            }
            return _instance;
        }
        public List<Database> LoadDatabases()
        {
            List<Database> loadedDatabases = new List<Database>();

            string[] allFolders = Directory.GetDirectories(_dataBasesFolderPath);

            foreach (var folder in allFolders)
            {
                string id = Path.GetFileName(folder);
                Database db = LoadDatabase(id);
                db.Erd = null;
                loadedDatabases.Add(db);
            }
            return loadedDatabases;
        }
        public Database LoadDatabase(string id, string Password = null)
        {
            LoadedDatabaseIndex loadedDatabaseIndex =
             new LoadedDatabaseIndex();
            EntityRelationshipDiagram loadedDataBaseErd =
            new EntityRelationshipDiagram();
            string folderToLoadPath = Path.Combine(_dataBasesFolderPath, id);
            if (Directory.Exists(folderToLoadPath))
            {
                string indexFilePath = Path.Combine(folderToLoadPath, "Index.json");
                string readIndexInfo = File.ReadAllText(indexFilePath);
                loadedDatabaseIndex = JsonSerializer.Deserialize<LoadedDatabaseIndex>(readIndexInfo);

                string erdFilePath = Path.Combine(folderToLoadPath, "Erd.json");

                if (!loadedDatabaseIndex.IsPasswordProtected)

                {
                    string readErdInfo = File.ReadAllText(erdFilePath);
                    loadedDataBaseErd = JsonSerializer.Deserialize<EntityRelationshipDiagram>(readErdInfo)!;

                }

                else if (loadedDatabaseIndex.IsPasswordProtected)
                {
                    if (Password == null)
                        loadedDataBaseErd = null;

                    else if (Password != null)
                    {
                        FileInfo erdInfoFile = new FileInfo(erdFilePath);
                        try
                        {
                            string readEncryptedErdInfo = EncryptionUtils.Decrypt(erdInfoFile, Password);
                            loadedDataBaseErd = JsonSerializer.Deserialize<EntityRelationshipDiagram>(readEncryptedErdInfo)!;

                        }
                        catch (Exception e)
                        {
                            //password is wrong 
                        }

                    }
                }

            }

            Database loadedDataBase = new Database()
            {
                Id = loadedDatabaseIndex.Id,
                Name = loadedDatabaseIndex.Name,
                Type = loadedDatabaseIndex.Type,
                Created = loadedDatabaseIndex.Created,
                LastModified = loadedDatabaseIndex.LastModified,
                Erd = loadedDataBaseErd,
            };
            return loadedDataBase;
        }
        public void SaveDatabase(Database db)
        {
            Dictionary<string, object> indexFile = new Dictionary<string, object>();
            indexFile.Add("Name", db.Name);
            indexFile.Add("Id", db.Id);
            indexFile.Add("Type", db.Type);
            indexFile.Add("Created", db.Created);
            indexFile.Add("LastModified", db.LastModified);
            if (db.Password == null)
                indexFile.Add("IsPasswordProtected", false);
            else

                indexFile.Add("IsPasswordProtected", true);


            string folderpath = Path.Combine(_dataBasesFolderPath, db.Id);
            string infoFilePath = Path.Combine(folderpath, "Index.json");
            string erdFilePath = Path.Combine(folderpath, "Erd.json");

            Directory.CreateDirectory(folderpath);
            using var index = new FileStream(infoFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(index, indexFile);
            using var erd = new FileStream(erdFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            JsonSerializer.Serialize(erd, db.Erd);
            erd.Dispose();

            if (db.Password != null)
            {
                FileInfo erdFileInfo = new FileInfo(erdFilePath);

                String erdContent = File.ReadAllText(erdFilePath);
                File.WriteAllText(erdFilePath, string.Empty);
                EncryptionUtils.Encrypt(erdFileInfo, erdContent, db.Password);
            }
        }



        public void DeleteDatabase(string id)
        {
            string folderToDeletePath = Path.Combine(_dataBasesFolderPath, id);

            if (Directory.Exists(folderToDeletePath))
            {
                Directory.Delete(folderToDeletePath, true);
            }
        }

        public void ExportDatabase(string id, string destination)
        {
            string folderToExportPath = Path.Combine(_dataBasesFolderPath, id);
            string zipFileDestination = Path.Combine(destination, $"{id}.zip");
            if (Directory.Exists(folderToExportPath))

                ZipFile.CreateFromDirectory(folderToExportPath, zipFileDestination);
        }
        public void ImportDatabase(string path)
        {
            string importedFileName = Path.GetFileNameWithoutExtension(path);
            string importedFolderPath = Path.Combine(_dataBasesFolderPath, importedFileName);
            if (!Directory.Exists(importedFolderPath))
                ZipFile.ExtractToDirectory(path, importedFolderPath);
        }
    }

    public class LoadedDatabaseIndex
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool IsPasswordProtected { get; set; }
        public DatabaseType Type { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}

