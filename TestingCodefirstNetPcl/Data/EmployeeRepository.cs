using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Employee?> GetEmployeeWithTasksAsync(int employeeId)
    {
        var employee = await GetByIdAsync(employeeId);
        if (employee != null)
        {
            employee.AssignedTasks = await Connection.Table<TaskItem>()
                .Where(t => t.AssignedEmployeeId == employee.Id)
                .ToListAsync();
        }

        return employee;
    }
}