using System;
using System.Linq;
using System.Text;
using IronPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecruitmentSelection.UI.Models;
using RecruitmentSelection.UI.Models.Context;

namespace RecruitmentSelection.UI.Controllers
{
    public class ReportController : Controller
    {
        private readonly RecruitmentDbContext _context;

        public ReportController(RecruitmentDbContext context) 
        {
            _context = context;
        }
        public ActionResult GenerateEmployeeReport(RequestReport requestReport) 
        {
            if(requestReport.InitialDate != null && requestReport.EndDate != null) 
            {
                var Renderer = new HtmlToPdf();
                Renderer.PrintOptions.MarginTop = 50;
                Renderer.PrintOptions.MarginBottom = 50;
                Renderer.PrintOptions.CssMediaType = PdfPrintOptions.PdfCssMediaType.Print;
                Renderer.PrintOptions.Header = new SimpleHeaderFooter()
                {
                    CenterText = "Reporte de Empleados del " + requestReport.InitialDate?.ToString("dd/MM/yyyy") + " hasta el " +
                    requestReport.EndDate?.ToString("dd/MM/yyyy"),
                    DrawDividerLine = true,
                    FontSize = 14
                };
                Renderer.PrintOptions.Footer = new SimpleHeaderFooter()
                {
                    LeftText = "{date} {time}",
                    RightText = "Página {page} de {total-pages}",
                    DrawDividerLine = true,
                    FontSize = 14
                };
                var PDF = Renderer.RenderHtmlAsPdf(GetHtmlAgencyProducts(requestReport.InitialDate, requestReport.EndDate));

                return File(PDF.BinaryData, "application/pdf", $"employees_report_{requestReport.InitialDate?.ToString("yyyyMMdd")}_to_{requestReport.EndDate?.ToString("yyyyMMdd")}.pdf");
            }

            return View();
           
        }

        private string GetHtmlAgencyProducts(DateTime? initDate, DateTime? endDate)
        {
            DateTime initialDate = initDate ?? new DateTime();
            DateTime finalDate = endDate ?? new DateTime();

            var employees = _context.Employees
                .Include(e => e.JobPosition)
                .Where(x => x.InitialDate.Date >= initialDate && x.InitialDate.Date <= finalDate);

            var stringBuilderEmployees = new StringBuilder();
            stringBuilderEmployees.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <br/>
                                <table id='table' align='center' border='1'>
                                    <tr>
                                        <th>Cédula</th>
                                        <th>Nombre</th>
                                        <th>Fecha Ingreso</th>
                                        <th>Departamento</th>
                                        <th>Puesto</th>
                                        <th>Salario</th>
                                    </tr>");

            employees.ToList().ForEach(employee =>
            {
                stringBuilderEmployees.Append(@$"<tr>
                                    <td>{employee.DocumentNumber}</td>
                                    <td>{employee.Name}</td>
                                    <td>{employee.InitialDate.ToString("dd/MM/yyyy")}</td>
                                    <td>{employee.Department}</td>
                                    <td>{employee.JobPosition.Name}</td>
                                    <td>{employee.Salary.ToString("C")}</td>");
            });

            stringBuilderEmployees.Append(@"
                                </table>
                            </body>
                        </html>");

            return stringBuilderEmployees.ToString();
        }
    }
}