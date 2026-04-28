using SQLite;
using System.Collections.Generic;

namespace TestingCodefirstNetPcl.Models;

public class Department : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }

    public int CompanyId { get; set; }

    [Ignore]
    public Company? Company { get; set; }

    [Ignore]
    public List<Employee> Employees { get; set; } = new();

    [Ignore]
    public List<Project> Projects { get; set; } = new();
}