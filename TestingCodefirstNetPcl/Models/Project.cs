using SQLite;

namespace TestingCodefirstNetPcl.Models;

public class Project : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Title { get; set; }

    public int DepartmentId { get; set; }

    [Ignore]
    public Department? Department { get; set; }

    [Ignore]
    public List<TaskItem> Tasks { get; set; } = new();
}