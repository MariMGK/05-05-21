using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;
using System.IO;
using OfficeOpenXml;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<List<Department>> Import(Microsoft.AspNetCore.Http.IFormFile file)
        {
            var list = new List<Department>();
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowcount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowcount; row++)
                    {
                        list.Add(new Department
                        {
                            DepartmentId = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            DepartmentName = worksheet.Cells[row, 2].Value.ToString().Trim(),
                        });
                    }
                }
                return list;
            }
        }


    }
}
