﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationNorthwind.Entities;

namespace WebApplicationNorthwind.Model
{
    public class EmployeeVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Guid Gender { get; set; }
        public string Address { get; set; }
    }
}
