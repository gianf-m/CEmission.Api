using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Companies {
    public class CompanyFilterDto {
        public string Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
