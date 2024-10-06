using AutoMapper;

namespace CO2.Application {
    public class AutoMapper {
        public class MapperConfig {
            public static Mapper InitializeAutomapper() {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<CO2ApiProfile>();
                    cfg.AddProfile(new CO2ApiProfile());
                });
                var mapper = new Mapper(config);
                return mapper;
            }

        }
    }
}
