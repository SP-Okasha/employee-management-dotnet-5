﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models.Interfaces
{
    public interface IUnitofWork:IDisposable
    {
        IEmployeeRepository Employees { get; }

        int Complete();
    }
}