using DoQL.Models;

namespace DoQL
{
    class DatabaseBuilder
    {
        private string _name;
        private DatabaseType _type;
        private string _password = null;

        public void SetName(string name)
        {
            _name = name;
        }

        public void SetType(DatabaseType type)
        {
            _type = type;
        }

        public void SetPassword(string password)
        {
            _password = password;
        }

        public Database Build()
        {
            string id = Guid.NewGuid().ToString();
            DateTime now = DateTime.Now;

            return new Database
            {
                Id = id,
                Name = _name,
                Type = _type,
                Created = now,
                LastModified = now,
                Password = _password
            };
        }
    }
}
