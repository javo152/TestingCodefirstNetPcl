using TestingCodefirstNetPcl.Framework;
using TestingCodefirstNetPcl.Models;

namespace TestingCodefirstNetPcl.Data;

public class ProjectRepository : BaseRepository<Project>
{
    public ProjectRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<Project?> GetProjectWithTasksAsync(int projectId)
    {
        var project = await GetByIdAsync(projectId);
        if (project != null)
        {
            project.Tasks = await Connection.Table<TaskItem>()
                .Where(t => t.ProjectId == project.Id)
                .ToListAsync();
        }

        return project;
    }
}