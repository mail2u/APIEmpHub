using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class RoleModels : baseModels<RoleModels>
    {
        public string roleId { get; set; }
        public string roleType { get; set; }
        public string title { get; set; }
        public string authenCode { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(RoleModels iProp)
        {
            String query = "up_role_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleType", HelperConvert.ConvertToString(iProp.roleType))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@authenCode", HelperConvert.ConvertToString(iProp.authenCode))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                iSql.Close();
            }
        }

        public void Update(RoleModels iProp)
        {
            String query = "up_role_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@authenCode", HelperConvert.ConvertToString(iProp.authenCode))
                    , iSql.SqlCom_Parameter("@update_by", HelperConvert.ConvertToString(iProp.update_by))
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                iSql.Close();
            }
        }

        public void Delete(RoleModels iProp)
        {
            String query = "up_role_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@update_by", HelperConvert.ConvertToString(iProp.update_by))
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                iSql.Close();
            }
        }

        public List<RoleModels> DataList(RoleModels iProp)
        {
            String query = "up_role_sel";
            List<RoleModels> lData = new List<RoleModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleType", HelperConvert.ConvertToString(iProp.roleType))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new RoleModels
                             {
                                 roleId = HelperConvert.ConvertToString(r.Field<object>("roleId")!)
                                 ,
                                 roleType = HelperConvert.ConvertToString(r.Field<object>("roleType")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 authenCode = HelperConvert.ConvertToString(r.Field<object>("authenCode")!)
                             }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                iSql.Close();
            }

            return lData;
        }
    }
}
