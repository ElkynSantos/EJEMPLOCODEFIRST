using Databases.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace EJEMPLOCODEFIRST.Services
{
    public class Employees: IEmployee


    {
        
        private readonly AbcdataBaseContext _context;


        public Employees(AbcdataBaseContext context)
        {
            _context = context;

        }

        public async Task<Employee> createEmploye(Employee value)
            
        {
           
            
                _context.Employees.Add(value);
                await _context.SaveChangesAsync();
                return value;
         
        }

        public async Task<Guid> DeleteEmployee(Guid employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
            {
                throw new Exception("Empleado no encontrado"); // O devuelve una respuesta 404 Not Found si prefieres
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employeeId;

        }

        public async Task<List<Employee>> GetallEmployeeAsync()
        {

            List<Employee> employees = await _context.Employees.ToListAsync();
         
            return employees;
        }

        public async Task<Employee> ModifyEmployee(Employee value)
        {
            var employee = await _context.Employees.FindAsync(value.EmployeeId);
            if (employee == null)
            {
                return null; // O devuelve una respuesta 404 Not Found si prefieres
            }

            employee.Username = value.Username;
            employee.FirstName = value.FirstName;
            employee.LastName = value.LastName;
            employee.BranchOfficeId = value.BranchOfficeId;

            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
