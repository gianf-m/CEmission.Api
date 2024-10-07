using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public class EmissionCreateDto {
        [Required, MinLength(EmissionsConsts.DescriptionMinLength), MaxLength(EmissionsConsts.DescriptionMaxLength)]
        public string Description { get; set; }
        [Required, Range(0, 1000)]
        public decimal Quantity { get; set; }
        public DateTime EmissionDate { get; set; }
        [Required, MinLength(EmissionsConsts.TypeMinLength), MaxLength(EmissionsConsts.TypenMaxLength)]
        public string Type { get; set; }
        public int CompanyId { get; set; }
    }
}
