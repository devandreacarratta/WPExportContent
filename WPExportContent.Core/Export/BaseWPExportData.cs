using AutoMapper;
using System.Collections.Generic;
using WPExportContent.Core.DTO;

namespace WPExportContent.Core.Export
{
    public class BaseWPExportData
    {
        public IEnumerable<WPPostDTO> Posts;
        public IEnumerable<WPTagDTO> Tags;
        public IEnumerable<WPCategoryDTO> Categories;

        protected IMapper MapperPost = null;


        public BaseWPExportData()
        {
            Mappings.MappingPost post = new Mappings.MappingPost();
            this.MapperPost = post.Get;
        }
    }
}