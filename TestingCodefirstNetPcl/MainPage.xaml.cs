using TestingCodefirstNetPcl.Data;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly CompanyRepository _companyRepo;
        private readonly DepartmentRepository _departmentRepo;

        public MainPage(CompanyRepository companyRepository, DepartmentRepository departmentRepository)
        {
            InitializeComponent();
            _companyRepo = companyRepository;
            _departmentRepo = departmentRepository;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // 1. Create Parent
            var newCompany = new Company { Name = "Penske Logistics" };
            await _companyRepo.SaveAsync(newCompany);

            // 2. Create Child using Parent's generated AutoIncrement Id
            var newDepartment = new Department 
            { 
                Name = "Research & Development",
                CompanyId = newCompany.Id 
            };
            await _departmentRepo.SaveAsync(newDepartment);

            // 3. Retrieve item with nested references resolved
            var deptWithData = await _departmentRepo.GetDepartmentWithNestedDataAsync(newDepartment.Id);

            var company2 = await _companyRepo.GetCompanyWithDepartmentsAsync(newCompany.Id);

            await DisplayAlertAsync("Db initialized", $"Loaded: {deptWithData?.Name} with Id {deptWithData?.Id} belonging to {deptWithData?.Company?.Name}", "Accept");
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}
