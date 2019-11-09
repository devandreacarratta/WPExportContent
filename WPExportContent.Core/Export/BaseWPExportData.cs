using AutoMapper;
using System.Collections.Generic;
using WPExportContent.Core.DTO;
using WPExportContent.Core.Mappings;

namespace WPExportContent.Core.Export
{
    public class BaseWPExportData
    {
        public IEnumerable<WPPostDTO> Posts;
        public IEnumerable<WPTagDTO> Tags;
        public IEnumerable<WPCategoryDTO> Categories;

        protected IMapper MapperPost = null;
        protected IMapper MapperCategory = null;
        protected IMapper MapperTag = null;


        public BaseWPExportData()
        {
            MappingPost mappingPost = new MappingPost();
            this.MapperPost = mappingPost.Get;

            MappingCategory mappingCategory = new MappingCategory();
            this.MapperCategory = mappingCategory.Get;

            MappingTag mappingTag = new MappingTag();
            this.MapperTag = mappingTag.Get;
        }
    }
}