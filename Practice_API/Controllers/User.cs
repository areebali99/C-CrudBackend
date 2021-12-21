using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Practice_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {

        private readonly Models.CrudUserContext _context;

        public User(CrudUserContext context)
        {
            _context = context;
        }


        [HttpGet]
        public object GetAll()
        {
            List<Employee> employees = _context.Employees.ToList();

            return employees;
        }


        [HttpPost("GetById/{id}")]
        public IActionResult GetById(long id)
        {
            var item = _context.Employees.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost("create")]
        public IActionResult Create( Employee item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Employees.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute( new { id = item.Id }, item);
        }



        [HttpPost("Update")]
    public IActionResult Update([FromBody] Employee item)
    {
        if (item == null || item.Id != item.Id)
        {
            return BadRequest();
        }

        var employee = _context.Employees.FirstOrDefault(t => t.Id == item.Id);
        if (employee == null)
        {
            return NotFound();
        }

            employee.Name = item.Name;
            employee.UserName = item.UserName;
            employee.Email = item.Email;
            employee.Phone = item.Phone;
            employee.Website = item.Website;

        _context.Employees.Update(employee);
        _context.SaveChanges();
        return new NoContentResult();
    }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var supplier = _context.Employees.FirstOrDefault(t => t.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(supplier);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
