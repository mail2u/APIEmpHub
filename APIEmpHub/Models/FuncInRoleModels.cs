using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class FuncInRoleModels:baseModels<FuncInRoleModels>
    {
        public string roleId { get; set; }
        public string funcId { get; set; }
        public string title { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(FuncInRoleModels iProp)
        {
            String query = "up_func_in_role_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@funcId", HelperConvert.ConvertToString(iProp.funcId))
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

        public void Delete(FuncInRoleModels iProp)
        {
            String query = "up_func_in_role_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@funcId", HelperConvert.ConvertToString(iProp.funcId))
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
        public List<FuncInRoleModels> DataList(FuncInRoleModels iProp)
        {
            String query = "up_func_in_role_sel";
            List<FuncInRoleModels> lData = new List<FuncInRoleModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new FuncInRoleModels
                             {
                                 funcId = HelperConvert.ConvertToString(r.Field<object>("funcId")!)
                                 ,
                                 roleId = HelperConvert.ConvertToString(r.Field<object>("roleId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
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
