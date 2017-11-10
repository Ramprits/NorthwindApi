using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationNorthwind.Entities
{
    [Table("Gender", Schema = "mst")]
    public class Gender
    {
        [Key]
        public Guid GenderGuid { get; set; }
        public string Name { get; set; }
    }
}
