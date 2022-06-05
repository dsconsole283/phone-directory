using Microsoft.Extensions.Configuration;
using PhoneDirectory.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Library
{
    internal class DirectoryData
    {
        private readonly ISQLDataAccess _db = new SQLDataAccess();
        private readonly IConfiguration _configuration;
        private string _connectionString;

        public DirectoryData(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = GetConnectionString();
        }
        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task AddRecord(DirectoryRecordModel record)
        {
            await _db.SaveDataAsync("dbo.spAddRecord",
                                    new { record.FirstName, 
                                        record.LastName, 
                                        record.Department.Name, 
                                        record.Title, 
                                        record.EmailAddress, 
                                        record.PhoneMain, 
                                        record.PhoneMobile, 
                                        record.Extension, 
                                        record.Notes, 
                                        record.IsExec },
                                    _connectionString,
                                    true);
        }
    }
}
