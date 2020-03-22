using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Windows_app.ViewModels
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        
        [Required(ErrorMessage = "First Name is Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Department is required")]
        [Display(Name = "Department")]
        public Department? Department { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Email is not in Valid Format")]
        public String Email { get; set; }


    }

}
