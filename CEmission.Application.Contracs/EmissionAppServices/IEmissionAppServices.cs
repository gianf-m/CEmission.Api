using CEmission.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public interface IEmissionAppServices {
        Task<EmissionDto> GetAsync(int Id);
        Task UpdateAsync(int Id, EmissionUpdateDto valEmissionUpdateDto);
        Task<EmissionDto> CreateAsync(EmissionCreateDto valEmissionCreateDto, int valCompanyId);
        Task DeleteAsync(int Id);
        Task<List<EmissionDto>> GetListAsync(int companyId);
        Task<PagedListDto<EmissionDto>> GetPagedListAsync(EmissionFilterDto valFilterDto);
        Task<byte[]> GetEmissionExcelAsync(string valType, DateTime? valEmissionDate);
    }
}
