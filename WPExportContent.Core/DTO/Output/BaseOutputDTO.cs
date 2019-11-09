using System;

namespace WPExportContent.Core.DTO.Output
{
    public class BaseOutputDTO
    {
        public Guid RowID { get; set; } = Guid.NewGuid();
    }
}