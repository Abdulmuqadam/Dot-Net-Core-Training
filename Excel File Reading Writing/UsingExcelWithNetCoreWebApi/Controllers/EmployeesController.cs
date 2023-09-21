using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using UsingExcelWithNetCoreWebApi.Data;
using UsingExcelWithNetCoreWebApi.Models;

namespace UsingExcelWithNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("export")]
        public IActionResult ExportToExcel()
        {
            var employees = GetEmployeesFromDb();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Employees");
                worksheet.Cells.LoadFromCollection(employees, true);

                var fileName = "EmployeesData.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                using (var stream = new MemoryStream())
                {
                    package.SaveAs(stream);

                    var fileContentResult = new FileContentResult(stream.ToArray(), contentType)
                    {
                        FileDownloadName = fileName
                    };

                    return fileContentResult;
                }
            }
        }

        [HttpPost("import")]
        public IActionResult ImportFromExcel([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No File uploaded");
            }

            try
            {
                using (var stream = file.OpenReadStream())
                {
                    ImportDataFromExcel(stream);
                }

                return Ok("Data imported from Excel succesfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        private void ImportDataFromExcel(Stream excelFileStream)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(excelFileStream))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                if (worksheet != null)
                {
                    var employees = new List<Employees>();

                    for (int col = 2; col <= worksheet.Dimension.End.Row; col++)
                    {
                        var employee = new Employees
                        {
                            Name = worksheet.Cells[col, 2].Text,
                            Email = worksheet.Cells[col, 3].Text,
                        };

                        employees.Add(employee);
                    }

                    _context.Employees.AddRange(employees);
                    _context.SaveChanges();

                }
            }
        }

        private List<Employees> GetEmployeesFromDb()
        {
            return _context.Employees.ToList();
        }
    }
}
