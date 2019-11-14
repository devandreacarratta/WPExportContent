using System;

namespace WPExportContent.Core.DTO.Output
{
    public class UserDTO : BaseOutputDTO
    {
        public long ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserNicename { get; set; }
        public string UserEmail { get; set; }
        public string UserUrl { get; set; }
        public DateTime UserRegistered { get; set; }
        public string UserActivationKey { get; set; }
        public string UserStatus { get; set; }
        public string DisplayName { get; set; }

    }
}