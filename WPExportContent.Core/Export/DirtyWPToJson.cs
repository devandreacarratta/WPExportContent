using WPExportContent.Core.DTO;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class DirtyWPToJson : BaseWPExportData
    {
        public DirtyWPToJson(WPExportDTO export) : base(export)
        {
        }

        public string CreateJSON(Newtonsoft.Json.Formatting formatting )
        {
            WPDirtyExportResult dirtyExport = new WPDirtyExportResult()
            {
                Categories = this._export.WPCategories,
                Products = this._export.WPProducts,
                Posts = this._export.WPPosts,
                Tags = this._export.WPTags,
                Users = this._export.WPUsers
            };

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(dirtyExport, formatting);

            return result;

        }

    }
}