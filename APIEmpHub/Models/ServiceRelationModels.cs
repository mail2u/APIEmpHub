using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceRelationModels : baseModels<ServiceRelationModels>
    {
        public int rn { get; set; }
        public string sysId { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string fullname { get; set; }
        public string condition1 { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(ServiceRelationModels iProp)
        {
            String query = "up_service_relation_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@condition1", HelperConvert.ConvertToString(iProp.condition1))
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

        public void Replace(ServiceRelationModels iProp)
        {
            String query = "up_service_relation_replace_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@condition1", HelperConvert.ConvertToString(iProp.condition1))
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

        public void Delete(ServiceRelationModels iProp)
        {
            String query = "up_service_relation_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
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

        public List<ServiceRelationModels> DataList(ServiceRelationModels iProp)
        {
            String query = "up_service_relation_sel";
            List<ServiceRelationModels> lData = new List<ServiceRelationModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceRelationModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 sysId = HelperConvert.ConvertToString(r.Field<object>("sysId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 condition1 = HelperConvert.ConvertToString(r.Field<object>("condition1")!)
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


        public DataTable Report()
        {
            String query = "up_service_relation_report_sel";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

            return dtData;
        }
    }
}
