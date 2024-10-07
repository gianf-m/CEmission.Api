using CEmission.Companies;
using CEmission.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Emissions {
    public class EmissionRepository: IEmissionRepository {
        private readonly ApiDbContext _dbContext;
        public EmissionRepository(ApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Emission> GetAsync(int valId) {
            return await Get(valId);
        }

        private async Task<Emission> Get(int valId) {
            Emission vEmission = await _dbContext.Emissions.FindAsync(valId);
            if (vEmission is null) {
                throw new ApplicationException("No Emission");
            }
            return vEmission;
        }

        public async Task UpdateAsync(Emission valEmission) {
            CheckCompany(valEmission.CompanyId);
            _dbContext.Emissions.Update(valEmission);
            await _dbContext.SaveChangesAsync();
        }

        private void CheckCompany(int valCompanyId) {
            Company vCompany = _dbContext.Companies.Find(valCompanyId);
            if (vCompany is null) {
                throw new ApplicationException("Company doesnt exist");
            }

            if (vCompany.IsDeleted) {
                throw new ApplicationException("Company is deleted");
            }
        }

        public async Task<Emission> CreateAsync(Emission valEmission) {
            CheckCompany(valEmission.CompanyId);
            _dbContext.Emissions.Add(valEmission);
            await _dbContext.SaveChangesAsync();
            return valEmission;
        }

        public async Task DeleteAsync(int valId) {
            Emission vEmission = await Get(valId);
            _dbContext.Emissions.Remove(vEmission);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Emission>> GetListAsync(int? valCompanyId, string valType, DateTime? valEmissionDateMin, DateTime? valEmissionDateMax) {
            var query = _dbContext.Emissions.WhereIf(valCompanyId.HasValue && valCompanyId != 0, x => x.CompanyId == valCompanyId)
                                            .WhereIf(!string.IsNullOrEmpty(valType), x => x.Type.Contains(valType))
                                            .WhereIf(valEmissionDateMin.HasValue, x => x.EmissionDate.Date >= valEmissionDateMin.Value.Date)
                                            .WhereIf(valEmissionDateMax.HasValue, x => x.EmissionDate.Date <= valEmissionDateMax.Value.Date);
            return await query.ToListAsync();
        }

    }
}
