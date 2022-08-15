using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.DTO;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly APIDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, APIDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public void InserirDepartamentosCargaInicial()
        {
            var department1 = new Department();
            var department2 = new Department();
            var department3 = new Department();
            var department4 = new Department();
            var department5 = new Department();

            department1.DepartmentName = "Department 1";
            department2.DepartmentName = "Department 2";
            department3.DepartmentName = "Department 3";
            department4.DepartmentName = "Department 4";
            department5.DepartmentName = "Department 5";

            _context.Departments.AddRange(department1);
            _context.Departments.AddRange(department2);
            _context.Departments.AddRange(department3);
            _context.Departments.AddRange(department4);
            _context.Departments.AddRange(department5);

            _context.SaveChanges();
        }

        //[HttpPost]
        //public void CriarDepartamento(DepartmentDTO departmentDTO)
        //{
        //    var department = new Department();
        //    department.DepartmentName = departmentDTO.DepartmentName;
        //    _context.Departments.AddRange(department);

        //    _context.SaveChanges();
        //}
    }
}
