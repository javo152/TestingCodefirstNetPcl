using SQLite;
using System.Collections.Generic;

namespace TestingCodefirstNetPcl.Models;

public class Employee : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Role { get; set; }

    public int DepartmentId { get; set; }

    [Ignore]
    public Department? Department { get; set; }

    [Ignore]
    public List<TaskItem> AssignedTasks { get; set; } = new();
}