using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public class EmissionCreateDto {
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public DateTime EmissionDate { get; set; }
        public string Type { get; set; }
    }
}
