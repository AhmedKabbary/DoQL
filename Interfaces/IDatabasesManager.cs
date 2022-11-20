using DoQL.Models;

namespace DoQL.Interfaces
{
    // Directory for each project (Named by the GUID)
    // Contains the following files:
    //      index.json  -> General info
    //      tables.json -> Tables info
    //      erd.json    -> ER Digram related info
    interface IDatabasesManager
    {
        List<Database> LoadDatabases();
        Database LoadDatabase(string id);
        void SaveDatabase(Database db);
        void DeleteDatabase(string id);

        // Compess the database JSON files into a ZIP file
        void ExportDatabase(string id);
        
        // Import a ZIP file from a specific path
        Database ImportDatabase(string path);
    }
}
