using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelSample.Models
{
    public class CollectionData<T> : Validation
    {
        public IReadOnlyCollection<T> Data { get; init; }
    }
}
