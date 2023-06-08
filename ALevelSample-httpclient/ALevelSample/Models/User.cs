using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Models
{
    public class User : Validation
    {
        public int Id { get; set; }

        public string Email { get; set; } = (string)null;

        public string FirstName { get; set; } = (string)null;

        public string LastName { get; set; } = (string)null;

        public string Avatar { get; set; } = (string)null;
    }
}
