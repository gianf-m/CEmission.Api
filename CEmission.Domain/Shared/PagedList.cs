using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Shared {
    public class PagedList<T> {
        public virtual List<T> List { get; set; }
        public virtual int Count { get; set; }
    }
}
