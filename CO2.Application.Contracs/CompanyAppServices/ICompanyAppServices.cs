using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Companies {
    public interface ICompanyAppServices {
        Task<CompanyDto> GetAsync(int valId);
        Task UpdateAsync(int valId, CompanyUpdateDto valCompanyUpdateDto);
        Task<CompanyDto> CreateAsync(CompanyCreateDto valCompanyCreateDto);
        Task DeleteAsync(int valId);
        Task HardDeleteAsync(int valId);
        Task<List<CompanyDto>> GetListAsync(CompanyFilterDto valFilterDto);
    }
}
