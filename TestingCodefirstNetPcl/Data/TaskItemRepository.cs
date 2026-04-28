using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class TaskItemRepository : BaseRepository<TaskItem>
{
    public TaskItemRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<TaskItem?> GetTaskWithDetailsAsync(int taskId)
    {
        var task = await GetByIdAsync(taskId);
        if (task != null)
        {
            task.Project = await Connection.FindAsync<Project>(task.ProjectId);
            task.AssignedEmployee = await Connection.FindAsync<Employee>(task.AssignedEmployeeId);
        }

        return task;
    }
}