namespace DoQL.DatabaseProviders
{
    public abstract class DatabaseProvider
    {
        public abstract List<string> GetDataTypes();
        public abstract bool ValidateDataType(string dataType);
        public abstract bool ValidateAttributeName(string attributeName);
        public abstract bool ValidateTableName(string tableName);
    }
}
