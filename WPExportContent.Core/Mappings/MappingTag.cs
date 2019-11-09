using AutoMapper;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.Mappings
{
    public class MappingTag : Profile
    {

        Mapper _mapper = null;

        public MappingTag()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<WPTagDTO, TagDTO>()
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.term_id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.slug))
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