using AutoMapper;

namespace Web.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
                x.ValidateInlineMaps = false;
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}