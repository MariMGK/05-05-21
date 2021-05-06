using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db(); 
        public IActionResult Index()
        {
            DataSet ds = dbop.Getrecord();
                ViewBag.details = ds.Tables[0];


            return View();
            
        }
        public IActionResult ExporttoExcel()
        {
            DataSet ds = dbop.Getrecord();
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.LoadFromDataTable(ds.Tables[0], true);
                package.Save();
            }
            stream.Position = 0;
            string excelname = $"Department.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelname);
        }

    }



}
