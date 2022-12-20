using Employee.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Business.Interface
{
    public interface IEmployee
    {
        public Employees GetEmployeeDetailById(int id);

        public List<Employees> GetActiveEmployee();

        public Employees UpdateEmployeeDetail(Employees employee);

        public Employees CreateEmployeeDetail(Employees employee);

        public Employees DeleteEmployee(int id);
    }
}
