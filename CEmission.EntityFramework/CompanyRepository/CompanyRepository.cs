using CEmission.Emissions;
using CEmission.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.Companies {
    public class CompanyRepository: ICompanyRepository {
        private readonly ApiDbContext _dbContext;
        public CompanyRepository(ApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Company> GetAsync(int valId) {
            return await Get(valId);
        }

        private async Task<Company> Get(int valId) {
            Company vCompany = await _dbContext.Companies.FindAsync(valId);
            if (vCompany is null) {
                throw new ApplicationException("No Company");
            }
            return vCompany;
        }

        public async Task UpdateAsync(Company valCompany) {
            _dbContext.Companies.Update(valCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Company> CreateAsync(Company valCompany) {
            _dbContext.Companies.Add(valCompany);
            await _dbContext.SaveChangesAsync();
            return valCompany;
        }

        public async Task DeleteAsync(int valId) {
            Company vCompany = await Get(valId);
            vCompany.SetAsDeleted();
            _dbContext.Companies.Update(vCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(int valId) {
            Company vCompany = await Get(valId);
            List<Emission> vEmissionsByCompany = _dbContext.Emissions.Where(x => x.CompanyId == vCompany.Id).ToList();
            if (vEmissionsByCompany.Count > 0) {
                _dbContext.Emissions.RemoveRange(vEmissionsByCompany);
            }
            _dbContext.Companies.Remove(vCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetListAsync(string valName, bool? valIsDeleted = false) {
            var query = _dbContext.Companies.WhereIf(!string.IsNullOrEmpty(valName), x => x.Name.Contains(valName))
                                            .WhereIf(valIsDeleted.HasValue && (bool)valIsDeleted, x => x.IsDeleted == valIsDeleted);
            return await query.ToListAsync();
        }

    }
}
