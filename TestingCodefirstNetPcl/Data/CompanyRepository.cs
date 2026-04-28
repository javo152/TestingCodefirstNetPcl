using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class CompanyRepository : BaseRepository<Company>
{
    public CompanyRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Company?> GetCompanyWithDepartmentsAsync(int companyId)
    {
        var company = await GetByIdAsync(companyId);
        if (company != null)
        {
            company.Departments = await Connection.Table<Department>()
                .Where(d => d.CompanyId == company.Id)
                .ToListAsync();
        }

        return company;
    }
}