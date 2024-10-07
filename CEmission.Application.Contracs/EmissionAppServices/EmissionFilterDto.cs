using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public class EmissionFilterDto {
        public int? CompanyId { get; set; }
        public string Type { get; set; }
        public DateTime? EmissionDateMin { get; set; }
        public DateTime? EmissionDateMax { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Value Must Bigger Than {1}")]
        public int? Page { get; set; }
    }
}
