using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class ServiceProcessModels : baseModels<ServiceProcessModels>
    {
        public int rn { get; set; }
        public string sysId { get; set; }
        public string name { get; set; }
        public int level { get; set; }

        public void Create(ServiceProcessModels iProp)
        {
            String query = "up_service_process_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@name", HelperConvert.ConvertToString(iProp.name))
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

        public void Update(ServiceProcessModels iProp)
        {
            String query = "up_service_process_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
                    , iSql.SqlCom_Parameter("@name", HelperConvert.ConvertToString(iProp.name))
                    , iSql.SqlCom_Parameter("@level", iProp.level)
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

        public void Delete(ServiceProcessModels iProp)
        {
            String query = "up_service_process_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
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

        public List<ServiceProcessModels> DataList(ServiceProcessModels iProp)
        {
            String query = "up_service_process_sel";
            List<ServiceProcessModels> lData = new List<ServiceProcessModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceProcessModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 sysId = HelperConvert.ConvertToString(r.Field<object>("sysId")!)
                                 ,
                                 name = HelperConvert.ConvertToString(r.Field<object>("name")!)
                                 ,
                                 level = HelperConvert.ConvertToInt(r.Field<object>("level")!)
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
