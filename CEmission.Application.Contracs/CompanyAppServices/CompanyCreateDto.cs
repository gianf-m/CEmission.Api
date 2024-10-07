using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Companies {
    public class CompanyCreateDto {
        [Required]
        [StringLength(CompaniesConsts.NameMaxLength, MinimumLength = CompaniesConsts.NameMinLength)]
        public string Name { get; set; }
    }
}
