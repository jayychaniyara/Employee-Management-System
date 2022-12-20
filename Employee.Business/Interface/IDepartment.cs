using Employee.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Interface
{
    public interface IDepartment
    {
        public List<Department> GetDepartments();

        public List<Department> GetActiveDepartments();

        public Department GetDepartmentDetailById(int id);

        public List<Employees> GetAllEmployeeByDepartment(int id);

        public Department DeleteDepartment(int id);
    }
}
