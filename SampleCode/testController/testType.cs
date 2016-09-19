using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace testController
{
    public class TestType : EntityBase
    {
        #region Properties
        /// <summary>
        /// 상태
        /// </summary>
        public string name { get; set; }

        #endregion Properties

        #region Constructors

        public TestType()
        {
        }

        public TestType(DataRow dr)
            : base(dr)
        {
        }

        #endregion Constructors
    }
}