﻿using System.Collections.Generic;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.WordPress
{
    public class WPExportResult
    {
        public IEnumerable<CategoryDTO> Categories { get; set; }
        public IEnumerable<PostDTO> Posts { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}