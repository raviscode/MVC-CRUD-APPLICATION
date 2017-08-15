using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCcrudApplication.Models;

namespace MVCcrudApplication.Controllers
{
    public class EmployeeController : Controller
    {
        DAC dac = new DAC();
        List<Employee> empRecord = new List<Employee>();

        // GET: Employee
        public ActionResult EmployeeRecord()
        {
            empRecord = dac.getEmployee();
            return View(empRecord);
        }

        [HttpGet] //call on the page load only.
        public ActionResult EmpDteail(int EmpID)
        {
            Employee emp = new Employee();
            emp = dac.getEmployeebyID(EmpID);
            return View(emp);
        }

        [HttpGet]
        public ActionResult InsertEmpDetail()
        {
            return View();
        }

        [HttpPost] //call while redirecting to server.
        public ActionResult InsertEmpDetail(Employee emp)
        {
            dac.insertEmployee(emp.Name, emp.Department, emp.Location, emp.Salary);
            return RedirectToAction("EmployeeRecord");
        }

        [HttpPost]
        //Calling view using only one BeginForm
        public ActionResult ProcessForm(Employee emp, string Delete, string Update)
        {
            if (!string.IsNullOrEmpty(Delete))
            {
                dac.deleteEmployee(emp.EmpID);
                return RedirectToAction("EmployeeRecord");
            }
            else 
            {
                dac.updateEmployee(emp.EmpID, emp.Name, emp.Department, emp.Location, emp.Salary);
                return RedirectToAction("EmployeeRecord");
            }
        }
    }
}