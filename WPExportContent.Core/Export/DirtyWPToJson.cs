using System.IO;
using WPExportContent.Core.DTO;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class DirtyWPToJson : BaseWPExportData
    {
        public DirtyWPToJson(WPExportDTO export) : base(export)
        {
        }

        public void Run(string outFile)
        {
            WPDirtyExportResult dirtyExport = new WPDirtyExportResult()
            {
                Categories = this._export.WPCategories,
                Products = this._export.WPProducts,
                Posts = this._export.WPPosts,
                Tags = this._export.WPTags,
                Users = this._export.WPUsers
            };

            string dirtyExportJson = Newtonsoft.Json.JsonConvert.SerializeObject(dirtyExport, Newtonsoft.Json.Formatting.Indented);
            File.Delete(outFile);
            File.WriteAllText(outFile, dirtyExportJson);

            outFile = outFile.Replace(".json", ".min.json");
            string dirtyExportMinJson = Newtonsoft.Json.JsonConvert.SerializeObject(dirtyExport, Newtonsoft.Json.Formatting.None);
            File.Delete(outFile);
            File.WriteAllText(outFile, dirtyExportMinJson);
        }

    }
}