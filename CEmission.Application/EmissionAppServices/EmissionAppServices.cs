using AutoMapper;
using CEmission.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CEmission.Application.AutoMapper;

namespace CEmission.Emissions {
    public class EmissionAppServices: IEmissionAppServices {
        private readonly IEmissionRepository _emissionRepository;
        private readonly Mapper ObjectMapper = MapperConfig.InitializeAutomapper();
        public EmissionAppServices(IEmissionRepository emissionRepository) {
            _emissionRepository = emissionRepository;
        }

        public virtual async Task<EmissionDto> GetAsync(int Id) {
            return ObjectMapper.Map<EmissionDto>(await _emissionRepository.GetAsync(Id));
        }

        public virtual async Task UpdateAsync(int Id, EmissionUpdateDto valEmissionUpdateDto) {
            Emission vEmission = await _emissionRepository.GetAsync(Id);
            ObjectMapper.Map(valEmissionUpdateDto, vEmission);
            await _emissionRepository.UpdateAsync(vEmission);
        }

        public virtual async Task<EmissionDto> CreateAsync(EmissionCreateDto valEmissionCreateDto, int valCompanyId) {
            Emission vNewEmission = ObjectMapper.Map<Emission>(valEmissionCreateDto);
            vNewEmission.CompanyId = valCompanyId;
            vNewEmission = await _emissionRepository.CreateAsync(vNewEmission);
            return ObjectMapper.Map<EmissionDto>(vNewEmission);
        }

        public virtual async Task DeleteAsync(int Id) {
            await _emissionRepository.DeleteAsync(Id);
        }

        public virtual async Task<List<EmissionDto>> GetListAsync(EmissionFilterDto valFilterDto) {
            return ObjectMapper.Map<List<EmissionDto>>(await _emissionRepository.GetListAsync(valFilterDto.CompanyId, valFilterDto.Type, valFilterDto.EmissionDateMin, valFilterDto.EmissionDateMax));
        }

        public virtual async Task<List<EmissionDto>> GetByCompanyIdAsync(int CompanyId) {
            return ObjectMapper.Map<List<EmissionDto>>(await _emissionRepository.GetListAsync(CompanyId, string.Empty, null, null));
        }

    }
}
