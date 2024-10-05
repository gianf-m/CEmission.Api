using AutoMapper;

namespace CO2.Application {
    public class AutoMapper {
        public class MapperConfig {
            public static Mapper InitializeAutomapper() {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<OrganizationProfile>();
                    cfg.AddProfile(new OrganizationProfile());
                });
                var mapper = new Mapper(config);
                return mapper;
            }

        }
    }
}
