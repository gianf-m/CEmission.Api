using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public record EmissionDto {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public DateTime EmissionDate { get; set; }
        public string Type { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
