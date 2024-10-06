using CO2.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Companies {
    public class CompanyRepository: ICompanyRepository, IDisposable {
        private readonly ApiDbContext _dbContext;
        private bool disposed = false;
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
            vCompany.DeleteCompany();
            _dbContext.Companies.Update(vCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task HardDeleteAsync(int valId) {
            Company vCompany = await Get(valId);
            _dbContext.Companies.Remove(vCompany);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Company>> GetListAsync(string valName, bool? valOnlyActives = true) {
            var query = _dbContext.Companies.AsQueryable().WhereIf(!string.IsNullOrEmpty(valName), x => x.Name.Contains(valName))
                                                          .WhereIf(valOnlyActives.HasValue && (bool)valOnlyActives, x => x.IsDeleted == !valOnlyActives);
            return query.ToList();
        }

        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
