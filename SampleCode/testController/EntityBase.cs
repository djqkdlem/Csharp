using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testController
{
    [Serializable]
    public class EntityBase
    {
        #region Constructors
        public EntityBase() { }

        /// <summary>
        /// DataRow에서 각 Entity에 데이터 매핑
        /// </summary>
        /// <param name="dr"></param>
        public EntityBase(DataRow dr)
        {
            this.FillProperties(dr);
        }
        #endregion

        #region #ExtendMethod#
        public void FillProperties(DataRow dr)
        {
            if (dr != null)
            {
                foreach (var property in this.GetType().GetProperties())
                {
                    // readonly 인경우는 회피하도록 조건문 추가
                    if (property.CanWrite)
                    {
                        if (dr.Table.Columns != null && dr.Table.Columns.Contains(property.Name))
                        {
                            Object dbvalue = dr[property.Name];
                            if (dbvalue != null && dbvalue != DBNull.Value)
                            {
                                if ("system.guid".Equals(property.PropertyType.FullName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (dr[property.Name] != System.DBNull.Value)
                                    {
                                        property.SetValue(this, Convert.ChangeType(dbvalue, property.PropertyType));
                                    }
                                }
                                else if (property.PropertyType.BaseType != null && property.PropertyType.BaseType.FullName.Equals("System.Enum", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    property.SetValue(this, Enum.ToObject(property.PropertyType, (Int32)dbvalue), null);
                                }
                                else if (property.PropertyType == Type.GetType("System.Boolean"))
                                {
                                    property.SetValue(this, Convert.ChangeType(dbvalue, property.PropertyType));
                                }
                                else
                                {
                                    property.SetValue(this, Convert.ChangeType(Convert.ToString(dbvalue), property.PropertyType));
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
