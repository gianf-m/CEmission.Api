using AutoMapper;

namespace CEmission.Application {
    public class AutoMapper {
        public class MapperConfig {
            public static Mapper InitializeAutomapper() {
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<CEmissionApiProfile>();
                    cfg.AddProfile(new CEmissionApiProfile());
                });
                var mapper = new Mapper(config);
                return mapper;
            }

        }
    }
}
