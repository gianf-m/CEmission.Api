using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CEmission.Application.AutoMapper;

namespace CEmission.Companies {
    public class CompanyAppServices: ICompanyAppServices {
        private readonly ICompanyRepository _companyRepository;
        private readonly Mapper ObjectMapper = MapperConfig.InitializeAutomapper();
        public CompanyAppServices(ICompanyRepository companyRepository) {
            _companyRepository = companyRepository;
        }

        public virtual async Task<CompanyDto> GetAsync(int valId) {
            return ObjectMapper.Map<CompanyDto>(await _companyRepository.GetAsync(valId));
        }

        public virtual async Task UpdateAsync(int valId, CompanyUpdateDto valCompanyUpdateDto) {
            Company vCompany = await _companyRepository.GetAsync(valId);
            vCompany.Name = valCompanyUpdateDto.Name;
            await _companyRepository.UpdateAsync(vCompany);
        }

        public virtual async Task<CompanyDto> CreateAsync(CompanyCreateDto valCompanyCreateDto) {
            Company vNewCompany = new Company(valCompanyCreateDto.Name);
            vNewCompany = await _companyRepository.CreateAsync(vNewCompany);
            return ObjectMapper.Map<CompanyDto>(vNewCompany);
        }

        public virtual async Task DeleteAsync(int valId) {
            await _companyRepository.DeleteAsync(valId);
        }

        public virtual async Task HardDeleteAsync(int valId) {
            await _companyRepository.HardDeleteAsync(valId);
        }

        public virtual async Task<List<CompanyDto>> GetListAsync(CompanyFilterDto valFilterDto) {
            return ObjectMapper.Map<List<CompanyDto>>(await _companyRepository.GetListAsync(valFilterDto.Name, valFilterDto.IsDeleted));
        }

    }
}
