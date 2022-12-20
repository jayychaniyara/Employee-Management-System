using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Model
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Age { get; set; }

        public DateTime JoinedDate { get; set; }

        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
    }
}
