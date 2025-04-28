using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class UserInRoleModels : baseModels<UserInRoleModels>
    {
        public string roleId { get; set; }
        public string roleType { get; set; }
        public string roleName { get; set; }
        public string userId { get; set; }
        public string fullname { get; set; }
        public string authenCode { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(UserInRoleModels iProp)
        {
            String query = "up_user_in_role_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
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

        public void Delete(UserInRoleModels iProp)
        {
            String query = "up_user_in_role_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

        public UserInRoleModels Detail(UserInRoleModels iProp)
        {
            String query = "up_user_in_role_detail";
            iData = new UserInRoleModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new UserInRoleModels
                             {
                                 authenCode = HelperConvert.ConvertToString(r.Field<object>("authenCode")!)
                             }).FirstOrDefault();
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

            return iData;
        }

        public List<UserInRoleModels> DataList(UserInRoleModels iProp)
        {
            String query = "up_user_in_role_sel";
            List<UserInRoleModels> lData = new List<UserInRoleModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleType", HelperConvert.ConvertToString(iProp.roleType))
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new UserInRoleModels
                             {
                                 roleId = HelperConvert.ConvertToString(r.Field<object>("roleId")!)
                                 ,
                                 roleName = HelperConvert.ConvertToString(r.Field<object>("roleName")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
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
