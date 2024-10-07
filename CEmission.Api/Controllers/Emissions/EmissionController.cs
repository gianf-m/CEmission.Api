using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace CEmission.Emissions {

    [Area("app")]
    [ControllerName("Emissions")]
    [Route("api/app/")]
    [Authorize]
    public class EmissionController : Controller, IEmissionAppServices {
        private readonly IEmissionAppServices _emissionAppServices;
        public EmissionController(IEmissionAppServices emissionAppServices) {
            _emissionAppServices = emissionAppServices;
        }

        [HttpGet]
        [Route("emission")]
        public Task<List<EmissionDto>> GetListAsync(EmissionFilterDto valFilterDto) {
            //Se agrego filtrado opcional para el listar del GetList
            return _emissionAppServices.GetListAsync(valFilterDto);
        }

        [HttpGet]
        [Route("emission/{Id}")]
        public Task<EmissionDto> GetAsync(int Id) {
            return _emissionAppServices.GetAsync(Id);
        }

        [HttpPost]
        [Route("emission")]
        public Task<EmissionDto> CreateAsync(EmissionCreateDto valEmissionUpdateDto, int valCompanyId) {
            return _emissionAppServices.CreateAsync(valEmissionUpdateDto, valCompanyId);
        }

        [HttpPut]
        [Route("emission/{Id}")]
        public Task UpdateAsync(int Id, EmissionUpdateDto valEmissionUpdateDto) {
            return _emissionAppServices.UpdateAsync(Id, valEmissionUpdateDto);
        }

        [HttpDelete]
        [Route("emission/{Id}")]
        public Task DeleteAsync(int Id) {
            return _emissionAppServices.DeleteAsync(Id);
        }

        [HttpGet]
        [Route("emission/company/{CompanyId}")]
        public Task<List<EmissionDto>> GetByCompanyIdAsync(int CompanyId) {
            return _emissionAppServices.GetByCompanyIdAsync(CompanyId);
        }
    }

}
