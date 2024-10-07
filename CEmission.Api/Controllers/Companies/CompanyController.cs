using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using CEmission.Companies;

namespace CEmission.Companies {

    [Area("app")]
    [ControllerName("Company")]
    [Route("api/app/company")]
    public class CompanyController : Controller, ICompanyAppServices {
        private readonly ICompanyAppServices _companyAppServices;
        public CompanyController(ICompanyAppServices companyAppServices) {
            _companyAppServices = companyAppServices;
        }

        [HttpGet]
        [Route("GET/{valId}")]
        public Task<CompanyDto> GetAsync(int valId) {
            return _companyAppServices.GetAsync(valId);
        }

        [HttpPut]
        [Route("PUT/{valId}")]
        public Task UpdateAsync(int valId, CompanyUpdateDto valCompanyUpdateDto) {
            return _companyAppServices.UpdateAsync(valId, valCompanyUpdateDto);
        }

        [HttpPost]
        [Route("POST")]
        public Task<CompanyDto> CreateAsync(CompanyCreateDto valCompanyCreateDto) {
            return _companyAppServices.CreateAsync(valCompanyCreateDto);
        }

        [HttpPut]
        [Route("DELETE/{valId}")]
        public Task DeleteAsync(int valId) {
            return _companyAppServices.DeleteAsync(valId);
        }

        [HttpDelete]
        [Route("HARDDELETE/{valId}")]
        public Task HardDeleteAsync(int valId) {
            return _companyAppServices.HardDeleteAsync(valId);
        }

        [HttpGet]
        [Route("GET-LIST")]
        public Task<List<CompanyDto>> GetListAsync(CompanyFilterDto valFilterDto) {
            return _companyAppServices.GetListAsync(valFilterDto);
        }
    }
}
