using AutoMapper;

namespace CodingCraftHOMod1Ex1EF.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ModelToViewModel>();
                 x.AddProfile<ViewModelToModel>();
            });
        }
    }
}