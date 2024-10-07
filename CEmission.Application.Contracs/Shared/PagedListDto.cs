using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Shared {
    public class PagedListDto<T> {
        public List<T> List { get; set; }
        public int Count { get; set; }

    }
}
