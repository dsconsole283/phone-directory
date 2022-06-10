namespace PhoneDirectory.Library
{
    public class DirectoryData : IDirectoryData
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
            return _configuration.GetConnectionString("DefaultRemoteDataConnection");
        }
        public async Task AddRecordAsync(PersonnelModel record, string department, string title)
        {
            var departmentId = await GetDepIdByNameAsync(department);
            var titleId = await GetTitleIdByTitleAsync(title);
            var isExecStatus = DetermineExecStatus(title);

            await _db.SaveDataAsync("dbo.spAddRecord",
                                    new
                                    {
                                        record.FirstName,
                                        record.LastName,
                                        departmentId,
                                        titleId,
                                        record.EmailAddress,
                                        record.PhoneMain,
                                        record.PhoneMobile,
                                        record.Extension,
                                        record.Notes,
                                        @IsExec = isExecStatus
                                    },
                                    _connectionString,
                                    true);
        }
        public async Task EditRecordAsync(
            PersonnelModel record,
            string firstName,
            string lastName,
            string department,
            string title,
            string emailAddress,
            string phoneMain,
            string phoneMobile,
            string extension,
            string notes)
        {
            record.FirstName = firstName;
            record.LastName = lastName;
            record.Department.Name = department;
            record.DepartmentId = await GetDepIdByNameAsync(department);
            record.Title.Name = title;
            record.TitleId = await GetTitleIdByTitleAsync(title);
            record.EmailAddress = emailAddress;
            record.PhoneMain = phoneMain;
            record.PhoneMobile = phoneMobile;
            record.Extension = extension;
            record.Notes = notes;
            record.IsExec = DetermineExecStatus(record.Title.Name);

            await _db.SaveDataAsync("spUpdateRecord",
                new
                {
                    @Id = record.Id,
                    record.FirstName,
                    record.LastName,
                    record.DepartmentId,
                    record.TitleId,
                    record.EmailAddress,
                    record.PhoneMain,
                    record.PhoneMobile,
                    record.Extension,
                    record.Notes,
                    record.IsExec
                },
                _connectionString,
                true);
        }
        public static bool DetermineExecStatus(string title)
        {
            string[] titles = { "VP", "Director", "Assistant Director", "Manager", "Assistant Manager", "Supervisor", "Untitled" };
            return titles.Contains(title);
        }
        public async Task<int> GetDepIdByNameAsync(string name)
        {
            return await _db.LoadDataSingleAsync<int, dynamic>(
                "spGetDepIdByName",
                new { Name = name },
                _connectionString,
                true);
        }
        public async Task<int> GetTitleIdByTitleAsync(string title)
        {
            return await _db.LoadDataSingleAsync<int, dynamic>(
                "spGetTitleIdByTitle",
                new { @Title = title },
                _connectionString,
                true);
        }
        public async Task<List<TitleModel>> GetAllTitlesAsync()
        {
            return await _db.LoadDataAsync<TitleModel, dynamic>(
                "spGetAllTitles",
                new { },
                _connectionString,
                true);
        }
        public async Task<List<PersonnelModel>> GetAllRecordsAsync()
        {
            List<PersonnelModel> completeRecords = new();

            List<DepartmentModel> departments = await GetAllDepartmentsAsync();

            List<TitleModel> titles = await GetAllTitlesAsync();

            List<PersonnelModel> records = await _db.LoadDataAsync<PersonnelModel, dynamic>(
                "dbo.spGetAllRecords",
                new { },
                _connectionString,
                true);

            foreach (var record in records)
            {
                if (record.Notes is null)
                {
                    record.Notes = "None on File";
                }

                record.Department = departments.Where(d => d.Id == record.DepartmentId).First();
                record.Title = titles.Where(t => t.Id == record.TitleId).First();
            }

            return records.OrderByDescending(x => x.IsExec == true)
                .ThenBy(x => x.TitleId)
                .ThenBy(x => x.Department.Name)
                .ThenBy(x => x.LastName).ToList();
        }
        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {
            var output = await _db.LoadDataAsync<DepartmentModel, dynamic>(
                "dbo.spGetAllDepartments",
                new { },
                _connectionString,
                true);

            return output.OrderBy(d => d.Name).ToList();
        }
        public async Task<List<PersonnelModel>> GetPersonnelByDepIdAsync(int id)
        {
            List<PersonnelModel> records = await _db.LoadDataAsync<PersonnelModel, dynamic>(
                "spGetPersonnelByDepartmentId",
                new { Id = id },
                _connectionString,
                true);

            List<TitleModel> titles = await GetAllTitlesAsync();

            foreach (var record in records)
            {
                record.Title = titles.Where(t => t.Id == record.TitleId).First();
            }

            return records.OrderByDescending(x => x.IsExec)
                .ThenBy(x => x.TitleId)
                .ThenBy(x => x.LastName).ToList();
        }
        public async Task<string> GetDepartmentById(int id)
        {
            return await _db.LoadDataSingleAsync<string, dynamic>(
                "spGetDepartmentById",
                new { Id = id },
                _connectionString,
                true);
        }
        public async Task AddDepartment(DepartmentModel department)
        {
            await _db.SaveDataAsync("spCreateDepartment", new { @Department = department.Name }, _connectionString, true);
        }
        public async Task AddTitle(TitleModel title)
        {
            await _db.SaveDataAsync("spCreateTitle", new { @Title = title.Name }, _connectionString, true);
        }
        public async Task<PersonnelModel> GetPersonByIdAsync(int id)
        {
            var record = await _db.LoadDataSingleAsync<PersonnelModel, dynamic>(
                "spGetPersonById",
                new { @Id = id },
                _connectionString,
                true);

            List<DepartmentModel> departments = await GetAllDepartmentsAsync();

            List<TitleModel> titles = await GetAllTitlesAsync();

            if (record.Notes is null)
            {
                record.Notes = "None on File";
            }

            record.Department = departments.Where(d => d.Id == record.DepartmentId).First();
            record.Title = titles.Where(t => t.Id == record.TitleId).First();

            return record;
        }
        public async Task DeleteRecord(PersonnelModel record)
        {
            await _db.SaveDataAsync("spDeleteRecord", new { @Id = record.Id }, _connectionString, true);
        }
    }
}
