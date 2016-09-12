using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excel
{
    public class AccessRecordType
    {
        public string RowNum { get; set; }
        public string SystemName { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public string ActionUrl { get; set; }
        public string ActionName { get; set; }
        public string ActionStateText { get; set; }
        public string PersonalInformationYN { get; set; }
        public string ActionDateTime { get; set; }
    }
}