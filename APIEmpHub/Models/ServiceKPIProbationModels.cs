using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceKPIProbationModels : baseModels<ServiceKPIProbationModels>
    {
        public string refId { get; set; }
        public string userId { get; set; }

        public string performance_indicator { get; set; }
        public decimal target { get; set; }
        public decimal weight { get; set; }
        public string performance_result { get; set; }
        public int answer { get; set; }
        public int order_index { get; set; }

        public int can_edit { get; set; }
        public string create_by { get; set; }
        public string create_date { get; set; }
        public void Save(List<ServiceKPIProbationModels> lProp)
        {
            String query = "up_service_kpiprobation_save";

            try
            {
                iSql.Open(connectionString);
                iSql.BeginTran();

                dtData = HelperConvert.ConvertToDataTable<ServiceKPIProbationModels>(lProp);

                String query_table = iSql.GetQueryCreateTable(dtData!, "#data_kpiprobation");

                iSql.SqlCom_ExecuteNonQuery(query_table, CommandType.Text);
                iSql.SqlBulkCopy(dtData, "#data_kpiprobation");

                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                );

                iSql.CommitTran();
            }
            catch (Exception ex)
            {
                iSql.RollbackTran();
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                iSql.Close();
            }
        }

        public List<ServiceKPIProbationModels> Detail(ServiceKPIProbationModels iProp)
        {
            String query = "up_service_kpiprobation_detail";
            lData = new List<ServiceKPIProbationModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceKPIProbationModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 performance_indicator = HelperConvert.ConvertToString(r.Field<object>("performance_indicator")!)
                                 ,
                                 target = HelperConvert.ConvertToDecimal(r.Field<object>("target")!)
                                 ,
                                 weight = HelperConvert.ConvertToDecimal(r.Field<object>("weight")!)
                                 ,
                                 performance_result = HelperConvert.ConvertToString(r.Field<object>("performance_result")!)
                                 ,
                                 answer = HelperConvert.ConvertToInt(r.Field<object>("answer")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                             }).ToList()!;

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
