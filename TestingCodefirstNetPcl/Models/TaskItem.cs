using SQLite;

namespace TestingCodefirstNetPcl.Models;

public class TaskItem : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public int ProjectId { get; set; }
    public int AssignedEmployeeId { get; set; }

    [Ignore]
    public Project Project { get; set; }

    [Ignore]
    public Employee AssignedEmployee { get; set; }
}