using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_app.ViewModels
{
    public class HomeViewModel
    {
       public HomeViewModel() {
            employees = new List<Employee>();
        }
        public List<Employee> employees;

    }
}
