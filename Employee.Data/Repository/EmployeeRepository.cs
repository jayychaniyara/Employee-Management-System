using Employee.Business.Interface;
using Employee.Business.Model;
using Employee.Data.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Repository
{
    public class EmployeeRepository: IEmployee
    {
        private readonly EMSDbContext dbContext;
        public EmployeeRepository(EMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employees CreateEmployeeDetail(Employees employee)
        {
            this.dbContext.Add(employee);
            this.dbContext.SaveChanges();
            return employee;
        }

        public Employees DeleteEmployee(int id)
        {
            var emp = this.dbContext.Employee.FirstOrDefault(x => x.Id == id);
            this.dbContext.Employee.Remove(emp);
            this.dbContext.SaveChangesAsync();
            return emp;
        }

        public List<Employees> GetActiveEmployee()
        {
            return this.dbContext.Employee.Where(x => x.IsActive == true).ToList();
        }

        public Employees GetEmployeeDetailById(int id)
        {
            return this.dbContext.Employee.FirstOrDefault(x => x.Id == id);
        }

        public Employees UpdateEmployeeDetail(Employees employee)
        {
            var employees = this.dbContext.Employee.Any(x => x.Id == employee.Id);
            this.dbContext.Employee.Update(employee);
            this.dbContext.SaveChanges();
            return employee;
        }
    }
}
