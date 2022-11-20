namespace DoQL.DatabaseProviders
{
    public abstract class DatabaseProvider
    {
        public abstract List<string> GetDataTypes();
        public abstract bool ValideteDataType(string dataType);
        public abstract bool ValideteAttributeName(string attributeName);
        public abstract bool ValidateTableName(string tableName);
    }
}
