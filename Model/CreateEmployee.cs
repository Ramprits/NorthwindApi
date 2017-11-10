using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationNorthwind.Entities;

namespace WebApplicationNorthwind.Model
{
    public class CreateEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
