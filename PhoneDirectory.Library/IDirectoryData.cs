namespace PhoneDirectory.Library
{
    public interface IDirectoryData
    {
        Task AddDepartment(DepartmentModel department);
        Task AddRecordAsync(PersonnelModel record, string department, string title);
        Task AddTitle(TitleModel title);
        Task DeleteRecord(PersonnelModel record);
        Task EditRecordAsync(PersonnelModel record, string firstName, string lastName, string department, string title, string emailAddress, string phoneMain, string phoneMobile, string extension, string notes);
        Task<List<DepartmentModel>> GetAllDepartmentsAsync();
        Task<List<PersonnelModel>> GetAllRecordsAsync();
        Task<List<TitleModel>> GetAllTitlesAsync();
        string GetConnectionString();
        Task<string> GetDepartmentById(int id);
        Task<int> GetDepIdByNameAsync(string name);
        Task<PersonnelModel> GetPersonByIdAsync(int id);
        Task<List<PersonnelModel>> GetPersonnelByDepIdAsync(int id);
        Task<int> GetTitleIdByTitleAsync(string title);
    }
}