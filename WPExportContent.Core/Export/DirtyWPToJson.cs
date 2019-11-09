using System.IO;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class DirtyWPToJson: BaseWPExportData
    {


        public void Run(string outFile)
        {
            WPDirtyExportResult dirtyExport = new WPDirtyExportResult()
            {
                Categories = this.Categories,
                Posts = this.Posts,
                Tags = this.Tags
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
