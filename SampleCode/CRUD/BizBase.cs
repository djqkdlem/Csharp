using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class BizBase : IDisposable
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public BizBase()
        { }


        /// <summary>
        /// 관리되지 않는 리소스 해제
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
        }
        /// <summary>
        /// 관리되지 않는 리소스 해제
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}