using Microsoft.AspNetCore.Mvc;
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
    public class DepartmentController : ControllerBase
    {
        private readonly APIDbContext _context;
        public DepartmentController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var departments = _context.Departments.OrderBy(x => x.DepartmentId).ToList();

            return Ok(departments);
        }

        [HttpGet("by-id/{departmentId}")]
        public IActionResult GetById(int departmentId)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);

            if (department == null)
                return NotFound();

            return Ok(department);
        }

        [HttpGet("by-name/{departmentName}")]
        public IActionResult GetByName(string departmentName)
        {
            var departments = _context.Departments.Where(x => x.DepartmentName.Contains(departmentName));

            if (!departments.Any())
                return NotFound();

            return Ok(departments);
        }

        [HttpPost]
        public IActionResult Post(DepartmentDTO departmentDTO)
        {
            var department = new Department();
            department.DepartmentName = departmentDTO.DepartmentName;
            _context.Departments.AddRange(department);
            _context.SaveChanges();

            return Ok();
        }        

        [HttpDelete("{departmentId}")]
        public IActionResult Delete (int departmentId)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);

            if (department == null)
                return NotFound();

            _context.Departments.Remove(department);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{departmentId}")]
        public IActionResult Update(int departmentId, DepartmentDTO departmentDTO)
        {
            var department = _context.Departments.FirstOrDefault(x => x.DepartmentId == departmentId);

            if (department == null)
                return NotFound();

            department.UpdateDepartmentName(departmentDTO.DepartmentName);

            _context.Departments.Update(department);

            _context.SaveChanges();

            return Ok();
        }



        //[HttpPost("carga-inicial")]
        //public void InserirDepartamentosCargaInicial()
        //{
        //    var department1 = new Department();
        //    var department2 = new Department();
        //    var department3 = new Department();
        //    var department4 = new Department();
        //    var department5 = new Department();

        //    department1.DepartmentName = "Department 1";
        //    department2.DepartmentName = "Department 2";
        //    department3.DepartmentName = "Department 3";
        //    department4.DepartmentName = "Department 4";
        //    department5.DepartmentName = "Department 5";

        //    _context.Departments.AddRange(department1);
        //    _context.Departments.AddRange(department2);
        //    _context.Departments.AddRange(department3);
        //    _context.Departments.AddRange(department4);
        //    _context.Departments.AddRange(department5);

        //    _context.SaveChanges();
        //}

    }
}
