using CEmission.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEmission.IdentityUsers {
    public class IdentityUserRepository: IIdentityUserRepository {
        private readonly ApiDbContext _dbContext;
        public IdentityUserRepository(ApiDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<bool> UsernameExist(string valUsername) {
            return await _dbContext.IdentityUsers.AnyAsync(x => x.NormalizedUserName == valUsername.ToUpper());
        }

        public async Task CreateAsync(IdentityUser valIdentityUser) {
            _dbContext.IdentityUsers.Add(valIdentityUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IdentityUser> GetAsync(Guid valIdentityUserId) {
            IdentityUser vIdentityUser = await _dbContext.IdentityUsers.Where(x => x.Id == valIdentityUserId).FirstOrDefaultAsync();
            if (vIdentityUser is null) {
                throw new ApplicationException("No IdentityUser");
            }
            return vIdentityUser;
        }

        public async Task UpdateAsync(IdentityUser valIdentityUser) {
            _dbContext.IdentityUsers.Update(valIdentityUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IdentityUser> GetAsync(string valUsername) {
            IdentityUser vIdentityUser = await _dbContext.IdentityUsers.Where(x => x.NormalizedUserName == valUsername.ToUpper()).FirstOrDefaultAsync();
            if (vIdentityUser is null) {
                throw new ApplicationException("No IdentityUser");
            }
            return vIdentityUser;
        }


    }
}
