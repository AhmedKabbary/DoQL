﻿using DoQL.Models;

namespace DoQL.Interfaces
{
    // Directory for each project (Named by the GUID)
    // Contains the following files:
    //      index.json  -> General info
    //      tables.json -> Tables info
    //      erd.json    -> ER Diagram related info
    interface IDatabasesManager
    {
        List<Database> LoadDatabases();
        Database LoadDatabase(string id, string password);
        void SaveDatabase(Database db);
        void DeleteDatabase(string id);

        // Compress the database JSON files into a ZIP file
        void ExportDatabase(string id, string destination);

        // Import a ZIP file from a specific path
        void ImportDatabase(string path);
    }
}
