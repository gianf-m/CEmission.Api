using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Companies {
    public interface ICompanyRepository {
        Task<Company> GetAsync(int valId);
        Task UpdateAsync(Company valCompany);
        Task<Company> CreateAsync(Company valCompany);
        Task DeleteAsync(int valId);
        Task HardDeleteAsync(int valId);
        Task<List<Company>> GetListAsync(string valName, bool? valIsDeleted = false);
    }
}
