using Microsoft.AspNetCore.Mvc;
using CSharpASPandADO.Models;

namespace CSharpASPandADO.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: Display the employee form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Handle form submission
        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddEmployee(employee);
                ViewBag.Message = "Employee added successfully.";

                // Clear form inputs after successful submission
                ModelState.Clear();
                return View(); // Stay on the same view to show the message
            }

            return View(employee); // Re-display form with validation errors
        }

        // To see all Employee on web page

        public IActionResult EmployeeInformation()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        // GET: Edit employee
        public IActionResult UpdateEmployee(int id)
        {
            var emp = _employeeService.GetEmployeeById(id);
            return View(emp);
        }

        // POST: Edit employee
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.UpdateEmployee(employee);
            return RedirectToAction("EmployeeInformation");
        }

        // GET: Delete employee
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("EmployeeInformation");
        }

    }
}
