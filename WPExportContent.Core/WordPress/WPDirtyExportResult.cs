using System.Collections.Generic;
using WPExportContent.Core.DTO;

namespace WPExportContent.Core.WordPress
{
    public class WPDirtyExportResult
    {
        public IEnumerable<WPCategoryDTO> Categories { get; set; }
        public IEnumerable<WPPostDTO> Posts { get; set; }
        public IEnumerable<WPProductDTO> Products { get; set; }

        public IEnumerable<WPPostDTO> PostChildren { get; set; }
        public IEnumerable<WPProductDTO> ProductChildren { get; set; }
        
        public IEnumerable<WPTagDTO> Tags { get; set; }

        public IEnumerable<WPUserDTO> Users { get; set; }
    }
}