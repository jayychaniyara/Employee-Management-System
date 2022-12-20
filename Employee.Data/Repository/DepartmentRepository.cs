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
    public class DepartmentRepository : IDepartment
    {
        private readonly EMSDbContext dbContext;
        public DepartmentRepository(EMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Department DeleteDepartment(int id)
        {
            var dept = this.dbContext.Department.FirstOrDefault(x => x.Id == id);
            this.dbContext.Department.Remove(dept);
            this.dbContext.SaveChangesAsync();
            return dept;
        }

        public List<Department> GetActiveDepartments()
        {
            return this.dbContext.Department.Where(x => x.IsActive == true).ToList();
        }

        public List<Employees> GetAllEmployeeByDepartment(int id)
        {
            return this.dbContext.Employee.Where(x => x.Id == id).ToList();
        }

        public Department GetDepartmentDetailById(int id)
        {
            return this.dbContext.Department.FirstOrDefault(x => x.Id == id);
        }

        public List<Department> GetDepartments()
        {
            return this.dbContext.Department.ToList();
        }
    }
}
