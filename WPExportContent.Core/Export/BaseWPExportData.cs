using AutoMapper;
using WPExportContent.Core.DTO;
using WPExportContent.Core.Mappings;

namespace WPExportContent.Core.Export
{
    public class BaseWPExportData
    {

        protected WPExportDTO _export = null;

        protected IMapper MapperPost = null;

        protected IMapper MapperProduct = null;
        protected IMapper MapperCategory = null;
        protected IMapper MapperTag = null;
        protected IMapper MapperUser = null;


        public BaseWPExportData(WPExportDTO export)
        {
            this._export = export;

            MappingPost mappingPost = new MappingPost();
            this.MapperPost = mappingPost.Get;

            MappingProducts mappingProducts = new MappingProducts();
            this.MapperProduct = mappingProducts.Get;

            MappingCategory mappingCategory = new MappingCategory();
            this.MapperCategory = mappingCategory.Get;

            MappingTag mappingTag = new MappingTag();
            this.MapperTag = mappingTag.Get;

            MappingUser mappingUser = new MappingUser();
            this.MapperUser = mappingUser.Get;
        }
    }
}