using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Models.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {

        public IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<List<EmployeeViewModel>> GetAllEmployees()
        {
            return _mapper.Map<List<EmployeeViewModel>>(await _unitofWork.Employees.GetAll());
        }

        public async Task<EmployeeViewModel> GetEmployeeById(int empId)
        {
            if (empId > 0)
            {
                var emp = await _unitofWork.Employees.Get(empId);
                if (emp is not null)
                {
                    return _mapper.Map<EmployeeViewModel>(emp);
                }
            }
            return null;
        }
       
        
        public async Task<bool> CreatNewEmployee(EmployeeViewModel model)
        {
            if (model is not null)
            {
                var newEmployee = _mapper.Map<Employee>(model);
                newEmployee.CreatedBy = "API";
                newEmployee.CreatedOn = DateTime.Now;
                await _unitofWork.Employees.Add(newEmployee);
                return _unitofWork.Complete() > 0;
            }
            return false;
        }




        public async Task<bool> UpdateEmployee(int empId, EmployeeViewModel viewModel)
        {
            if (empId > 0)
            {
                var employee = await _unitofWork.Employees.Get(empId);
                if (employee is not null)
                {
                    employee.EmplName = viewModel.EmplName;
                    employee.EmplCode = viewModel.EmplCode;
                    employee.EmplRoleId= viewModel.EmplRoleId;
                    employee.UpdatedBy = "API";
                    employee.UpdatedOn = DateTime.Now;
                    _unitofWork.Employees.Update(employee);
                    return _unitofWork.Complete() > 0;

                }
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int empId)
        {
            if (empId > 0)
            {
                var employee = await _unitofWork.Employees.Get(empId);
                if (employee is not null)
                {
                    employee.UpdatedBy = "API";
                    employee.UpdatedOn = DateTime.Now;
                    _unitofWork.Employees.Delete(employee);
                    return _unitofWork.Complete() > 0;
                }
            }
            return false;
        }
    }
}
