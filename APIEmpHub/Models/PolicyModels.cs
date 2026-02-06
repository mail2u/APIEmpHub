using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class PolicyModels : baseModels<PolicyModels>
    {
        public string id { get; set; }
        public string title { get; set; }
        public string coverId { get; set; }
        public string detail { get; set; }
        public int is_active { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Create(PolicyModels iProp)
        {
            String query = "up_policy_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    );

                iProp.id = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@id"].Value);
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

        public void Update(PolicyModels iProp)
        {
            String query = "up_policy_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@coverId", HelperConvert.ConvertToString(iProp.coverId))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
                    , iSql.SqlCom_Parameter("@is_active", iProp.is_active)
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

        public void Delete(PolicyModels iProp)
        {
            String query = "up_policy_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
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

        public List<PolicyModels> DataList(PolicyModels iProp)
        {
            String query = "up_policy_sel";
            List<PolicyModels> lData = new List<PolicyModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new PolicyModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 coverId = HelperConvert.ConvertToString(r.Field<object>("coverId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 detail = HelperConvert.ConvertToString(r.Field<object>("detail")!)
                                 ,
                                 is_active = HelperConvert.ConvertToInt(r.Field<object>("is_active")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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
