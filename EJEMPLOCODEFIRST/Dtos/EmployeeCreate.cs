using System.ComponentModel.DataAnnotations;

namespace EJEMPLOCODEFIRST.Dtos
{
    public class EmployeeCreate
    {
        [Required(ErrorMessage = "El Username es obligatorio")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "El Firstname es obligatorio")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "El LastName es obligatorio")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "El Branchoffice es obligatorio")]
        public int BranchOfficeId { get; set; }
    }
}
