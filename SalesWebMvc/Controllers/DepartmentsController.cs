using SalesWebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });
            list.Add(new Department { Id = 3, Name = "Mechanical" });
            // enviando dados do controller para a view
            return View(list);
        }
    }
}