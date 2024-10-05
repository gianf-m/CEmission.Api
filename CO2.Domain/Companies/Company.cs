using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Companies {
    public class Company {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual DateTime FechaDeCreacion { get; protected set; }
        public virtual bool EstaInactiva { get; protected set; }
        public virtual DateTime FechaDesactivacion { get; protected set; }

        public Company() {
            Nombre = string.Empty;
            FechaDeCreacion = DateTime.Now.Date;
            EstaInactiva = true;
            FechaDesactivacion = new DateTime(1900, 01, 01);
        }

        public void DesactivarEmpresa() {
            FechaDesactivacion = DateTime.Now;
            EstaInactiva = true;
        }
       
    }
}
