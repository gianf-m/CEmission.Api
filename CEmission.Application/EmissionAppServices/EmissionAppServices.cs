using AutoMapper;
using CEmission.Companies;
using CEmission.Shared;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

        public virtual async Task<List<EmissionDto>> GetListAsync(int companyId) {
            return ObjectMapper.Map<List<EmissionDto>>(await _emissionRepository.GetListAsync(companyId));
        }

        public virtual async Task<PagedListDto<EmissionDto>> GetPagedListAsync(EmissionFilterDto valFilterDto) {
            if (!valFilterDto.Page.HasValue || valFilterDto.Page <= 0) {
                valFilterDto.Page = 1;
            }
            return ObjectMapper.Map<PagedListDto<EmissionDto>>(await _emissionRepository.GetPagedListAsync(valFilterDto.CompanyId, valFilterDto.Type, valFilterDto.EmissionDateMin, valFilterDto.EmissionDateMax, (int)valFilterDto.Page));
        }

        public virtual async Task<byte[]> GetEmissionExcelAsync(string valType, DateTime? valEmissionDate) {
            using (XLWorkbook wb = new XLWorkbook()) {
                DataTable vDataTable = await GetEmissionsTableAsync(valType, valEmissionDate);
                wb.AddWorksheet(vDataTable, "Emissions");
                wb.ColumnWidth = 65;
                using (MemoryStream ms = new MemoryStream()) {
                    wb.SaveAs(ms);
                    return ms.ToArray();
                }
            }
        }

        private async Task<DataTable> GetEmissionsTableAsync(string valType, DateTime? valEmissionDate) {
            List<Emission> vTable = await _emissionRepository.GetEmissionsForExcelAsync(valType, valEmissionDate);
            DataTable vDt = GetTableExcel();
            foreach (var vItem in vTable) {
                DataRow vDr = vDt.NewRow();
                vDr["Id"] = vItem.Id.ToString();
                vDr["CompanyId"] = vItem.CompanyId.ToString();
                vDr["Description"] = vItem.Description;
                vDr["Quantity"] = Math.Round(vItem.Quantity, 2).ToString();
                vDr["EmissionDate"] = vItem.EmissionDate.Date.ToString("dd/MM/yyyy");
                vDr["Type"] = vItem.Type;
                vDt.Rows.Add(vDr);
            }
            return vDt;
        }

        private DataTable GetTableExcel() {
            DataTable vDt = new DataTable();
            vDt.Columns.Add("Id", typeof(string));
            vDt.Columns.Add("CompanyId", typeof(string));
            vDt.Columns.Add("Description", typeof(string));
            vDt.Columns.Add("Quantity", typeof(string));
            vDt.Columns.Add("EmissionDate", typeof(string));
            vDt.Columns.Add("Type", typeof(string));
            return vDt;
        }


    }
}
