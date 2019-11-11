using System;
using System.Collections.Generic;

namespace WPExportContent.Core.DTO.Output
{
    public class BaseTablePostDTO : BaseOutputDTO
    {
        public long ID { get; set; }

        public List<long> Categories { get; set; } = new List<long>();
        public List<long> Tags { get; set; } = new List<long>();
        public long PostAuthor { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDateGTM { get; set; }
        public string PostContent { get; set; }
        public string PostTitle { get; set; }

        public string PostExcerpt { get; set; }
        public string PostStatus { get; set; }
        public string CommentStatus { get; set; }
        public string PingStatus { get; set; }
        public string PostPassword { get; set; }

        public string PostName { get; set; }
        public string ToPing { get; set; }
        public string Pinged { get; set; }
        public DateTime PostModified { get; set; }
        public DateTime PostModifiedGTM { get; set; }
        public string PostContentFiltered { get; set; }

        public long PostParent { get; set; }
        public string guid { get; set; }
        public int MenuOrder { get; set; }

        public string PostType { get; set; }
        public string PostMimeType { get; set; }
        public int CommentCount { get; set; }

    }
}