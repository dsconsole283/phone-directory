﻿using Microsoft.Extensions.Configuration;
using PhoneDirectory.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Library
{
    public class DirectoryData
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
            return _configuration.GetConnectionString("DefaultDataConnection");
        }
        public async Task AddRecordAsync(DirectoryRecordModel record)
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
        public async Task<DirectoryRecordModel> EditRecordAsync(DirectoryRecordModel record)
        {
            throw new NotImplementedException();
        }
        public async Task<List<DirectoryRecordModel>> GetAllRecordsAsync()
        {
            return await _db.LoadDataAsync<DirectoryRecordModel, dynamic>("dbo.spGetAllRecords", new { }, _connectionString, true);
        }
    }
}
