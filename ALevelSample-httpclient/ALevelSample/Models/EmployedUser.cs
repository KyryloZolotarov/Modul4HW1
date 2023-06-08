using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Models
{
    public class EmployedUser : Validation
    {
        public string Name { get; set; } = (string)null;

        public string Job { get; set; } = (string)null;

        public int Id { get; set; }

        public string CreatedAt { get; set; } = (string)null;

        public string UpdatedAt { get; set; }
    }
}
