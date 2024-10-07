using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using CEmission.Shared;

namespace CEmission.Emissions {

    [Area("app")]
    [ControllerName("Emissions")]
    [Route("api/app/")]
    [Authorize]
    public class EmissionController : Controller {
        private readonly IEmissionAppServices _emissionAppServices;
        public EmissionController(IEmissionAppServices emissionAppServices) {
            _emissionAppServices = emissionAppServices;
        }

        [HttpGet]
        [Route("emission")]
        public Task<PagedListDto<EmissionDto>> GetPagedListAsync(EmissionFilterDto valFilterDto) {
            //Se agrego filtrado opcional para el listar del GetList
            return _emissionAppServices.GetPagedListAsync(valFilterDto);
        }

        [HttpGet]
        [Route("emission/{Id}")]
        public Task<EmissionDto> GetAsync(int Id) {
            return _emissionAppServices.GetAsync(Id);
        }

        [HttpPost]
        [Route("emission")]
        public Task<EmissionDto> CreateAsync(EmissionCreateDto valEmissionUpdateDto) {
            return _emissionAppServices.CreateAsync(valEmissionUpdateDto);
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
        [Route("emission/company/{companyId}")]
        public Task<List<EmissionDto>> GetListAsync(int companyId) {
            return _emissionAppServices.GetListAsync(companyId);
        }

        [HttpGet]
        [Route("emission/Excel")]
        public async Task<ActionResult> GetEmissionExcelAsync(string valType, DateTime? valEmissionDate) {
            byte[] vDocument = await _emissionAppServices.GetEmissionExcelAsync(valType, valEmissionDate);
            return File(vDocument, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Emissions_{DateTime.Now.Year}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Minute}_{DateTime.Now.Second}.xlsx");
        }
    }

}
