using System;

namespace WPExportContent.Core.DTO.Output
{
    public class BaseOutputDTO
    {
        public Guid RowID { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
        public DateTime RowCreationDateUTC { get; set; } = DateTime.UtcNow;
    }
}