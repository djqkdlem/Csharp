using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testController
{
    public class ContextBase : IDisposable
    {
        #region Properties
        private Database db = null;
        /// <summary>
        /// DB에 연결할 connectionString 설정
        /// </summary>
        protected string connectionStringKey = "ConnBJWDB";

        /// <summary>
        /// Database에 접근
        /// </summary>
        protected Database Db
        {
            get
            {
                return this.db;
            }
            set
            {
                this.db = value;
            }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// DacBase 생성자
        /// </summary>
        public ContextBase()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);
            this.db = DatabaseFactory.CreateDatabase(connectionStringKey);
        }

        /// <summary>
        /// DacBase 생성자
        /// </summary>
        /// <param name="connectionString"></param>
        public ContextBase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("The value can not be null or an empty string.", "connectionString");
            }
            this.connectionStringKey = connectionString;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);
            this.db = DatabaseFactory.CreateDatabase(connectionString);
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
