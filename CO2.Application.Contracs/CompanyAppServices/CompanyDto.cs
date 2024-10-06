using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Companies {
    public class CompanyDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime DeletionTime { get; protected set; }

    }
}
