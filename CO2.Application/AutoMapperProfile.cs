using AutoMapper;
using CO2.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CO2.Application {
    public class CO2ApiProfile : Profile {
        public CO2ApiProfile() {
            CreateMap<Company, CompanyDto>();
        }
    }
}
