using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> CreatNewEmployee(EmployeeViewModel model);
        Task<List<EmployeeViewModel>> GetAllEmployees();
        Task<EmployeeViewModel> GetEmployeeById(int empId);
        Task<bool> UpdateEmployee(int empId, EmployeeViewModel model);
        Task<bool> DeleteEmployee(int empId);
    }
}
