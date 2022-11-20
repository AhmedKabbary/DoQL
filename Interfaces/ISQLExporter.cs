using DoQL.Models;

namespace DoQL.Interfaces
{
    interface ISQLExporter
    {
        string Export(Database db);
    }
}
