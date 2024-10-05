using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Emissions {
    internal class Emission {
        public virtual int Id { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual DateTime EmissionDate { get; set; }
        public virtual string EmissionType { get; set; }
        public virtual DateTime CreationTime { get; protected set; }
        public Emission() {
            Description = string.Empty;
            Quantity = 0M;
            EmissionDate = new DateTime(1900, 01, 01);
            EmissionType = string.Empty;
            CreationTime = DateTime.Now;
        }
    }
}
