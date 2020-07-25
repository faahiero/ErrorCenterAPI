using AutoMapper;
using ErrorCenter.Entities;
using ErrorCenter.Models.Environment;
using ErrorCenter.Models.Error;
using ErrorCenter.Models.Level;
using ErrorCenter.Models.Users;

namespace ErrorCenter.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            
            CreateMap<Error, ErrorModel>().ReverseMap();
            CreateMap<Error, ErrorRegisterModel>().ReverseMap();
            CreateMap<ErrorModel, ErrorRegisterModel>().ReverseMap();
            
            CreateMap<Environment, EnvironmentModel>().ReverseMap();
            CreateMap<Environment, EnvironmentRegisterModel>().ReverseMap();
            CreateMap<EnvironmentModel, EnvironmentRegisterModel>().ReverseMap();
            
            CreateMap<Level, LevelModel>().ReverseMap();
            CreateMap<Level, LevelRegisterModel>().ReverseMap();
            CreateMap<LevelModel, LevelRegisterModel>().ReverseMap();
            
        }
    }
}