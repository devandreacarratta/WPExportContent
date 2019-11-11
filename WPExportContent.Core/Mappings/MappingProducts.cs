using AutoMapper;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.Mappings
{
    public class MappingProducts : Profile
    {

        Mapper _mapper = null;

        public MappingProducts()
        {
            var configuration = new MapperConfiguration(cfg =>
                cfg.CreateMap<WPProductDTO, ProductDTO>()
                    .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                    .ForMember(dest => dest.PostAuthor, opt => opt.MapFrom(src => src.post_author))
                    .ForMember(dest => dest.PostDate, opt => opt.MapFrom(src => src.post_date))
                    .ForMember(dest => dest.PostDateGTM, opt => opt.MapFrom(src => src.post_date_gmt))
                    .ForMember(dest => dest.PostContent, opt => opt.MapFrom(src => src.post_content))
                    .ForMember(dest => dest.PostTitle, opt => opt.MapFrom(src => src.post_title))
                    .ForMember(dest => dest.PostExcerpt, opt => opt.MapFrom(src => src.post_excerpt))
                    .ForMember(dest => dest.PostStatus, opt => opt.MapFrom(src => src.post_status))
                    .ForMember(dest => dest.CommentStatus, opt => opt.MapFrom(src => src.comment_status))
                    .ForMember(dest => dest.PingStatus, opt => opt.MapFrom(src => src.ping_status))
                    .ForMember(dest => dest.PostPassword, opt => opt.MapFrom(src => src.post_password))
                    .ForMember(dest => dest.PostName, opt => opt.MapFrom(src => src.post_name))
                    .ForMember(dest => dest.ToPing, opt => opt.MapFrom(src => src.to_ping))
                    .ForMember(dest => dest.Pinged, opt => opt.MapFrom(src => src.pinged))
                    .ForMember(dest => dest.PostModified, opt => opt.MapFrom(src => src.post_modified))
                    .ForMember(dest => dest.PostModifiedGTM, opt => opt.MapFrom(src => src.post_modified_gmt))
                    .ForMember(dest => dest.PostContentFiltered, opt => opt.MapFrom(src => src.post_content_filtered))
                    .ForMember(dest => dest.PostParent, opt => opt.MapFrom(src => src.post_parent))
                    .ForMember(dest => dest.guid, opt => opt.MapFrom(src => src.guid))
                    .ForMember(dest => dest.MenuOrder, opt => opt.MapFrom(src => src.menu_order))
                    .ForMember(dest => dest.PostType, opt => opt.MapFrom(src => src.post_type))
                    .ForMember(dest => dest.PostMimeType, opt => opt.MapFrom(src => src.post_mime_type))
                    .ForMember(dest => dest.CommentCount, opt => opt.MapFrom(src => src.comment_count))

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