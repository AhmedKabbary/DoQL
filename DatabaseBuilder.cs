using DoQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoQL
{
    class DatabaseBuilder
    {
        private string _name;
        private DatabaseType _type;

        public void SetName(string name)
        {
            this._name = name;
        }

        public void SetType(DatabaseType type)
        {
            this._type = type;
        }

        public void SetPassword(string password)
        {
            // TODO
            throw new NotImplementedException();
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
                Tables = new List<Table>(),
            };
        }
    }
}
