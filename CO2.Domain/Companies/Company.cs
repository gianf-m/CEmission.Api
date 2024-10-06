using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Companies {
    public class Company {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime CreationTime { get; protected set; }
        public virtual bool IsDeleted { get; protected set; }
        public virtual DateTime DeletionTime { get; protected set; }
        public Company() {
            Name = string.Empty;
            CreationTime = DateTime.Now.Date;
            IsDeleted = false;
            DeletionTime = new DateTime(1900, 01, 01);
        }

        public void DeleteCompany() {
            DeletionTime = DateTime.Now;
            IsDeleted = true;
        }
        public Company(string valName) {
            Name = valName;
            CreationTime = DateTime.Now.Date;
            IsDeleted = false;
            DeletionTime = new DateTime(1900, 01, 01);
        }

    }
}
