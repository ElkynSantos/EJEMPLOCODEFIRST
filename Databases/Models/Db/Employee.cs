using System;
using System.Collections.Generic;

namespace Databases.Models.Db;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int BranchOfficeId { get; set; }
}
