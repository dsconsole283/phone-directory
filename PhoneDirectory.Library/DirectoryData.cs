using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Library
{
    internal class DirectoryData
    {
        private readonly ISQLDataAccess _db;

        public DirectoryData(ISQLDataAccess db)
        {
            _db = db;
        }
    }
}
