using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class DacBase : IDisposable
    {

        private Database db = null;
        /// <summary>
        /// DB에 연결할 connectionString 설정
        /// </summary>
        protected string connectionString = "ConnHomePage";

        /// <summary>
        /// DB 공급자 펙토리
        /// </summary>
        protected DBProviderFactoryEnum DbProviderFactoryEnum;
        public enum DBProviderFactoryEnum
        {
            /// <summary>
            /// MSSQL
            /// </summary>
            MSSQL = 3,
            /// <summary>
            /// Oracle
            /// </summary>
            Oracle = 4,
            /// <summary>
            /// Oracle MySQL
            /// </summary>
            MySQL = 5,
            /// <summary>
            /// IBM DB2
            /// </summary>
            DB2 = 6,
            /// <summary>
            /// IBM Informix
            /// </summary>
            Informix = 7,
            /// <summary>
            /// Teradata
            /// </summary>
            Teradata = 11
        }
        /// <summary>
        /// DacBase 생성자
        /// </summary>
        public DacBase()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);
            this.db = DatabaseFactory.CreateDatabase(connectionString);
        }

        /// <summary>
        /// DacBase 생성자
        /// </summary>
        /// <param name="connectionString"></param>
        public DacBase(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("The value can not be null or an empty string.", "connectionString");
            }
            this.connectionString = connectionString;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            DatabaseFactory.SetDatabaseProviderFactory(factory, false);
            this.db = DatabaseFactory.CreateDatabase(connectionString);
        }

        /// <summary>
        /// DBProviderFactory를 사용하는 생성자
        /// </summary>
        /// <param name="fullConnectionString"></param>
        /// <param name="providerFactoryType"></param>
        public DacBase(string fullConnectionString, DBProviderFactoryEnum providerFactoryType = DBProviderFactoryEnum.MSSQL)
        {
            this.DbProviderFactoryEnum = providerFactoryType;
            DbProviderFactory dbProviderFactory;
            switch (providerFactoryType)
            {
                case DBProviderFactoryEnum.MSSQL:
                    dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    break;
                case DBProviderFactoryEnum.Oracle:
                    dbProviderFactory = DbProviderFactories.GetFactory("Oracle.ManagedDataAccess.Client");
                    break;
                case DBProviderFactoryEnum.MySQL:
                    dbProviderFactory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
                    break;
                case DBProviderFactoryEnum.DB2:
                    dbProviderFactory = DbProviderFactories.GetFactory("IBM.Data.DB2");
                    break;
                case DBProviderFactoryEnum.Informix:
                    dbProviderFactory = DbProviderFactories.GetFactory("IBM.Data.Informix");
                    break;
                case DBProviderFactoryEnum.Teradata:
                    dbProviderFactory = DbProviderFactories.GetFactory("Teradata.Client.Provider");
                    break;
                default:
                    dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                    break;
            }

            this.db = new GenericDatabase(fullConnectionString, dbProviderFactory);
        }

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
