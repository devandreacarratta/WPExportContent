using AutoMapper;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.Mappings
{
    public class MappingUser : Profile
    {

        Mapper _mapper = null;

        public MappingUser()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<WPUserDTO, UserDTO>()
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.user_login))
                    .ForMember(dest => dest.UserPassword, opt => opt.MapFrom(src => src.user_pass))
                    .ForMember(dest => dest.UserNicename, opt => opt.MapFrom(src => src.user_nicename))
                    .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.user_email))
                    .ForMember(dest => dest.UserUrl, opt => opt.MapFrom(src => src.user_url))
                    .ForMember(dest => dest.UserRegistered, opt => opt.MapFrom(src => src.user_registered))
                    .ForMember(dest => dest.UserActivationKey, opt => opt.MapFrom(src => src.user_activation_key))
                    .ForMember(dest => dest.UserStatus, opt => opt.MapFrom(src => src.user_status))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.display_name))
            );
            this._mapper = new Mapper(configuration);
        }

        public Mapper Get
        {
            get
            {
                return this._mapper;
            }
        }

    }
}