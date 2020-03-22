using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows_app.DataAccess;

namespace Windows_app.ViewModels
{
    public class SQLEmployeeRepository : IEmployeeContext
    {
        private readonly ApplicationContext context;

        public SQLEmployeeRepository(ApplicationContext appContext) {
            this.context = appContext;
        
        }
        public bool CreateEmployee(Employee employee)
        {
            this.context.Employees.Add(employee);
            this.context.SaveChanges();
            return true;
        }

        public Employee Delete(int employeeID)
        {
            Employee emp=this.context.Employees.Where(x => x.EmployeeID == employeeID).FirstOrDefault();
            if (emp != null)
            {
                this.context.Employees.Remove(emp);
                this.context.SaveChanges();
                
            }
            return emp;

        }

        public List<Employee> GetAllEmployee()
        {
            return context.Employees.ToList<Employee>();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return context.Employees.FirstOrDefault(x => x.EmployeeID == id);

        }

        public Employee Update(Employee employee)
        {
            var emp=context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
