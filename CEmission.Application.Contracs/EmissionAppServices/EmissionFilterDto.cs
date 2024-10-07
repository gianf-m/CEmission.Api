using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public class EmissionFilterDto {
        public int? CompanyId { get; set; }
        public string Type { get; set; }
        public DateTime? EmissionDateMin { get; set; }
        public DateTime? EmissionDateMax { get; set; }
    }
}
