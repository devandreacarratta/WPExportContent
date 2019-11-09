using System;
using System.Collections.Generic;
using System.Text;

namespace WPExportContent.Core.DTO
{
    public class WPUserDTO
    {
        public long ID { get; set; }
        public string user_login { get; set; }
        public string user_pass { get; set; }
        public string user_nicename { get; set; }
        public string user_email { get; set; }
        public string user_url { get; set; }
        public DateTime user_registered { get; set; }
        public string user_activation_key { get; set; }
        public string user_status { get; set; }
        public string display_name { get; set; }

    }
}
