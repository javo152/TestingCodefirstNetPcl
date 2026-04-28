using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class DepartmentRepository : BaseRepository<Department>
{
    public DepartmentRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Department?> GetDepartmentWithNestedDataAsync(int departmentId)
    {
        var department = await GetByIdAsync(departmentId);
        if (department != null)
        {
            department.Company = await Connection.FindAsync<Company>(department.CompanyId);

            department.Employees = await Connection.Table<Employee>()
                .Where(e => e.DepartmentId == department.Id)
                .ToListAsync();

            department.Projects = await Connection.Table<Project>()
                .Where(p => p.DepartmentId == department.Id)
                .ToListAsync();
        }

        return department;
    }
}