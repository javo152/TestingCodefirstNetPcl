using SQLite;
using System.Collections.Generic;

namespace TestingCodefirstNetPcl.Models;

public class Company : IEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }

    [Ignore]
    public List<Department> Departments { get; set; } = new();
}