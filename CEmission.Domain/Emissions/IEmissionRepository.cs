using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public interface IEmissionRepository {
        Task<Emission> GetAsync(int valId);
        Task UpdateAsync(Emission valEmission);
        Task<Emission> CreateAsync(Emission valEmission);
        Task DeleteAsync(int valId);
        Task<List<Emission>> GetListAsync(int? valCompanyId, string valType, DateTime? valEmissionDateMin, DateTime? valEmissionDateMax);
    }
}
