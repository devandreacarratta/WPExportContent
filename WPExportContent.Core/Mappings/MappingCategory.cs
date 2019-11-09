using AutoMapper;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.Mappings
{
    public class MappingCategory : Profile
    {

        Mapper _mapper = null;

        public MappingCategory()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<WPCategoryDTO, CategoryDTO>()
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