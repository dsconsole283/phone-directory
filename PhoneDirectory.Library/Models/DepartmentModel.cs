namespace PhoneDirectory.Library.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DirectoryRecordModel> Personnel;
    }
}
