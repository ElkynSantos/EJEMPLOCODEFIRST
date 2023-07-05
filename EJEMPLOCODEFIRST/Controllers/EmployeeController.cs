using Databases.Models.Db;
using EJEMPLOCODEFIRST.Dtos;
using EJEMPLOCODEFIRST.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EJEMPLOCODEFIRST.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployee _employee;


        public EmployeeController(IEmployee employee)
        {
           _employee = employee;
        }

        [HttpGet("/getallEmployee")]
        public async Task<ActionResult<List<Employee>>> getAllEmployee()
        {

           return  await _employee.GetallEmployeeAsync();
         
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> createEmployee([FromBody] EmployeeCreate value)
        {
            if(value == null) {

                return BadRequest("No se ingresaron Valores");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devolver los errores de validación en el modelo
            }

            try
            {

                Employee newEmplooye = new Employee
                {
                    EmployeeId = Guid.NewGuid(),
                    Username = value.Username,
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    BranchOfficeId = value.BranchOfficeId,

                };

                
                if (string.IsNullOrEmpty(value.Username))
                {
                    ModelState.AddModelError("Username", "El username es obligatorio");
                    return BadRequest(ModelState);
                }
               
                var createdEmployee = await _employee.createEmploye(newEmplooye);

                return createdEmployee;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante el proceso de creación
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
            }
        }
        [HttpDelete("Eliminar")]
        public async Task<ActionResult<Guid>> DeleteUserById([FromBody]Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    await _employee.DeleteEmployee(id);
                    return id;
                }
                catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
                }
            }
        }

        [HttpPatch("/Modificar")]
        public async Task<ActionResult<Employee>> ModifyById([FromBody]Employee employee)
        {
            if(!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }
            else
            {
                try {
                    var employeeModify = await _employee.ModifyEmployee(employee);

                    if(employeeModify == null)
                    {
                        return StatusCode(StatusCodes.Status404NotFound, "No se encontro el usuario");
                    }

                    return employeeModify;
                }catch(Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
                }


            }


        }
      
    }
}
