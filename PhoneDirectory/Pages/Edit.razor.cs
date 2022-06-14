using Microsoft.AspNetCore.Components;

namespace PhoneDirectory.Pages
{
    public partial class Edit
    {
        [Parameter]
        public int Id { get; set; }

        private PersonnelModel person;
        private List<DepartmentModel> departments;
        private List<TitleModel> titles;
        private string firstName;
        private string lastName;
        private string department;
        private string title;
        private string emailAddress;
        private string phoneMain;
        private string phoneMobile;
        private string extension;
        private string notes;
        private string saveButtonText = "Submit";
        private string deleteButtonText = "Delete Record";
        private bool changesMade = false;
        private bool isNewRecord = false;
        private bool isDeleted = false;
        private bool confirmDelete = false;
        protected override async Task OnInitializedAsync()
        {
            if (Id == -1)
            {
                isNewRecord = true;
                person = new();
                person.Department = new DepartmentModel();
                person.Title = new TitleModel();
            }
            else
            {
                person = await data.GetPersonByIdAsync(Id);
            }

            departments = await data.GetAllDepartmentsAsync();
            titles = await data.GetAllTitlesAsync();
        }

        private async Task SaveEdit()
        {
            if (person.Department.Name is null)
            {
              person.Department.Name = "Accounting";
              person.Title.Name = "VP";
            }
            department = person.Department.Name;
            title = person.Title.Name;
            firstName = person.FirstName;
            lastName = person.LastName;
            emailAddress = person.EmailAddress;
            phoneMain = person.PhoneMain;
            phoneMobile = person.PhoneMobile;
            extension = person.Extension;
            notes = person.Notes;

            if (isNewRecord)
            {
                await data.AddRecordAsync(person, person.Department.Name, person.Title.Name);
            }
            else
            {
                await data.EditRecordAsync(person, firstName, lastName, department, title, emailAddress, phoneMain, phoneMobile, extension, notes);
            }

            changesMade = true;
            saveButtonText = "Changes Saved!";
        }

        private void ResetEditState()
        {
            changesMade = false;
            saveButtonText = "Submit";
            confirmDelete = false;
            deleteButtonText = "Delete Record";
            StateHasChanged();
        }

        private void ReturnToAdmin()
        {
            navManager.NavigateTo("/Admin");
        }

        private void DeleteRecord()
        {
            deleteButtonText = "Click to Confirm";
            confirmDelete = true;
        }

        private async Task ConfirmedDeleteRecord(PersonnelModel person)
        {
            await data.DeleteRecord(person);
            isDeleted = true;
            confirmDelete = false;
        }
    }
}