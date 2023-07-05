

using Databases.Models.Db;

namespace EJEMPLOCODEFIRST.Services
{
    public interface IEmployee
    {
        Task<List<Employee>> GetallEmployeeAsync();
        Task<Employee> createEmploye(Employee value);
        Task <Guid> DeleteEmployee(Guid employeeId);
        Task<Employee> ModifyEmployee(Employee value);

        Task<Employee> GetEmployeeById(Guid employeeId);

    }
}
