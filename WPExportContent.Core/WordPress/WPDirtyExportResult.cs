using System;
using System.Collections.Generic;
using System.Text;
using WPExportContent.Core.DTO;

namespace WPExportContent.Core.WordPress
{
    public class WPDirtyExportResult
    {
        public IEnumerable<WPCategoryDTO> Categories { get; set; }
        public IEnumerable<WPPostDTO> Posts { get; set; }
        public IEnumerable<WPTagDTO> Tags { get; set; }

    }
}