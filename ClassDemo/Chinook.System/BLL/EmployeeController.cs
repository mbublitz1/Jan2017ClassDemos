﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.System.DAL;
using Chinook.Data.Entities;
#endregion
namespace Chinook.System.BLL
{
    public class EmployeeController
    {
        public Employee Employee_Get(int employeeid)
        {
            using (var context = new ChinookContext())
            {
                return context.Employees.Find(employeeid);
            }
        }
    }
}
