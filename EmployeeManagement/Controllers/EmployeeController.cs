using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _employeeService.GetAllEmployees();
            return Ok(list);
        }

        [HttpGet("{empId}")]
        public async Task<IActionResult> Get(int empId)
        {
            var list = await _employeeService.GetEmployeeById(empId);
            if (list is not null)
                return Ok(list);
            else
                return BadRequest("Employee not found!");


        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeViewModel viewModel)
        {
            if (viewModel is not null)
            {
                await _employeeService.CreatNewEmployee(viewModel);
                return Ok("Employee has been added successfully.");
            }
            else
                return BadRequest("Invalid Data!");
        }

        [HttpPut]
        public async Task<IActionResult> Update(int empId, EmployeeViewModel viewModel)
        {
            if (viewModel is not null)
            {
                var response = await _employeeService.UpdateEmployee(empId, viewModel) ? "User has been Updated Successfully" : "User not found!";
                return Ok(response);
            }
            else
                return BadRequest("Invalid Data!");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int empId)
        {

            if (await _employeeService.DeleteEmployee(empId))
            {
                return Ok("Employee has been deleted successfully.");
            }
            else
                return BadRequest("Invalid Data!");
        }
    }
}