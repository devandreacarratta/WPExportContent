namespace WPExportContent.Core.DTO.Output
{
    public class CategoryDTO: BaseOutputDTO
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
