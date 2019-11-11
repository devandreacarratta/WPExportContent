using System.IO;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class DirtyWPToJson : BaseWPExportData
    {

        public void Run(string outFile)
        {
            WPDirtyExportResult dirtyExport = new WPDirtyExportResult()
            {
                Categories = this.Categories,
                Products = this.Products,
                Posts = this.Posts,
                Tags = this.Tags,
                Users = this.Users
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