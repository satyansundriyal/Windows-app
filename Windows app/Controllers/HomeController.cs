using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Windows_app.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Windows_app.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeContext _employeeContext;
        public HomeController(IEmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.employees = _employeeContext.GetAllEmployee();
            return View(viewModel);
        }
        public IActionResult GetEmployeeDetail(int id)
        {

            return View();

        }

        [HttpGet]
        public ViewResult Detail(int EmployeeID)
        {
            var employees = _employeeContext.GetEmployeeDetails(EmployeeID);

            return View("Create",employees);
        }
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeID > 0)
                {
                    _employeeContext.Update(employee);
                }
                else
                {
                    _employeeContext.CreateEmployee(employee);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(employee);
            }
        }


    }
}
