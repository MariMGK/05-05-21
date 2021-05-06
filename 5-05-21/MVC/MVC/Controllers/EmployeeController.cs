using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Getdetails()
        {
            Employee emp = new Employee();
            emp.EmployeeId = 1;

            emp.Name = "Ankit";
            return View(emp);
            
        }
    }
}