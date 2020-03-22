using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_app.ViewModels
{
    public class EmployeeContext : IEmployeeContext
    {
       private   List<Employee> _EmployeeList = new System.Collections.Generic.List<Employee>() {
        new Employee (){EmployeeID=1,FirstName="Satyan" ,LastName="Sundriyal" },
        new Employee (){ EmployeeID=2,FirstName="Anuja",LastName="Bhardwaj" },
        };
        public List<Employee> GetAllEmployee()
        {
            return _EmployeeList;
        }
        public Employee GetEmployeeDetails(int id)
        {
            return _EmployeeList.Where(x=>x.EmployeeID==id).FirstOrDefault();
        }
        public bool CreateEmployee(Employee employee) {
            int index = _EmployeeList.Count() + 1;
            employee.EmployeeID = index;
            _EmployeeList.Add(employee);
            return true;
        }

        public Employee Update(Employee employee)
        {
            Employee emp = _EmployeeList.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID);
            if (emp != null)
            {
                emp.Department = employee.Department;
                emp.FirstName = employee.FirstName;
                emp.LastName= employee.LastName;
                emp.Email = employee.Email;
            }
            return emp;
        }

        public Employee Delete(int employeeID)
        {
           Employee emp= _EmployeeList.FirstOrDefault(x => x.EmployeeID == employeeID);
            if (emp != null)
            {
                _EmployeeList.Remove(emp);
            
            }
            return emp;
        }
    }
}
