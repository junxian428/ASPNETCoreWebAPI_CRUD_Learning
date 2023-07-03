﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reactjscrud.Models;

namespace reactjscrud.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            if(_employeeContext.Employees == null)
            {
                return NotFound();
            }


            return await _employeeContext.Employees.ToListAsync();
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_employeeContext.Employees == null)
            {
                return NotFound();
            }

            var employee = await _employeeContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }


            return employee;
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();


            return CreatedAtAction(nameof(Employee), new {id = employee.ID}, employee);
        }



    }
}
