﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNorthwind.Entities
{
    [Table("Employee", Schema = "mst")]
    public class Employee
    {
        [Key]
        public Guid EmployeeGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedDate { get; set; } = new DateTime();
        public string Address { get; set; }
        public string Gender { get; set; }
    }

}
