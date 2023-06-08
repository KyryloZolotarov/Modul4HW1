using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Models
{
    public class Resource : Validation
    {
        public int Id { get; set; }

        public string Name { get; set; } = (string)null;

        public int Year { get; set; }

        public string Color { get; set; } = (string)null;

        public string PantoneValue { get; set; } = (string)null;
    }
}
