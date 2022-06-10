namespace PhoneDirectory.Pages
{
    public partial class Index
    {
        private List<DepartmentModel> departments;
        private List<PersonnelModel> personnel;
        private string selectedDepartment = "All";
        private string searchText = "";
        protected async override Task OnInitializedAsync()
        {
            departments = await data.GetAllDepartmentsAsync();
            personnel = await data.GetAllRecordsAsync();
        }

        private async Task OnClick(DepartmentModel d)
        {
            searchText = "";
            selectedDepartment = d.Name;
            await Filter();
        }

        private async Task Filter()
        {
            var output = await data.GetAllRecordsAsync();
            if (selectedDepartment != "All")
            {
                output = output.Where(x => x.Department.Name == selectedDepartment).ToList();
                output.OrderBy(x => x.IsExec == true).ThenByDescending(x => x.TitleId).ThenByDescending(x => x.LastName).ToList();
            }

            if (string.IsNullOrWhiteSpace(searchText) == false)
            {
                output = output.Where(x => x.FirstName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) || x.LastName.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) || x.Extension.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) || x.PhoneMain.Contains(searchText, StringComparison.InvariantCultureIgnoreCase) || x.PhoneMobile.Contains(searchText, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }
            else
            {
                personnel = await data.GetAllRecordsAsync();
            }

            personnel = output;
        }

        private async Task OnSearchInput(string searchInput)
        {
            searchText = searchInput;
            await Filter();
        }

        private async Task OnAllClick()
        {
            selectedDepartment = "All";
            await Filter();
        }

        private void OnAdminClick()
        {
            navManager.NavigateTo("/Admin");
        }
    }
}