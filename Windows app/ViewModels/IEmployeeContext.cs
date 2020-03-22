using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_app.ViewModels
{
   public interface IEmployeeContext
    {
        Employee GetEmployeeDetails(int id);
        List<Employee> GetAllEmployee();
        Employee Update(Employee employee);
        bool CreateEmployee(Employee employee);
        Employee Delete(int employeeID);

    }
}
