using System.Collections.Generic;

namespace WPExportContent.Core.DTO
{
    public class WPExportDTO
    {
        public IEnumerable<WPPostDTO> WPPosts { get; set; }
        public IEnumerable<WPTagDTO> WPTags { get; set; }
        public IEnumerable<WPCategoryDTO> WPCategories { get; set; }
        public IEnumerable<WPUserDTO> WPUsers { get; set; }
        public IEnumerable<WPProductDTO> WPProducts { get; set; }
    }
}