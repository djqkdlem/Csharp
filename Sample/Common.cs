using System;
using System.Collections.Generic;

namespace Sample
{
    public static class Common
    {
        public static List<Info> InfoList = new List<Info>()
         {
            new Info(){Name="철수",Room="1",Score=new int[]{10,20,30}, PhoneNumber = "010-111-1111"},
            new Info(){Name="영희",Room="1",Score=new int[]{100,200,300}, PhoneNumber = "010-2222-2222"},
            new Info(){Name="민수",Room="2",Score=new int[]{1000,2000,3000},PhoneNumber = "010-333-3333"}
         };

        public class Info
        {
            public string Name { get; set; }
            public string Room { get; set; }
            public int[] Score { get; set; }
            public string PhoneNumber { get; set; }
        }

        [Flags]
        public enum ApprovalStatus
        {
            NONE = 1,
            READY = 2,
            APPROVAL = 4,
            RETURN = 8
        }
    }
}
