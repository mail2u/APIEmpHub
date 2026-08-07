using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceTrainingModels : baseModels<ServiceTrainingModels>
    {
        public string refId { get; set; }
        public string trainingId { get; set; }
        public string mode { get; set; } = "";
        public string license { get; set; }
        public string certificateNo { get; set; }
        public string organization { get; set; }
        public string issueDate { get; set; }
        public string expireDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Save(ServiceTrainingModels iProp)
        {
            String query = "up_service_training_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@trainingId", HelperConvert.ConvertToString(iProp.trainingId))
                    , iSql.SqlCom_Parameter("@license", HelperConvert.ConvertToString(iProp.license))
                    , iSql.SqlCom_Parameter("@certificateNo", HelperConvert.ConvertToString(iProp.certificateNo))
                    , iSql.SqlCom_Parameter("@organization", HelperConvert.ConvertToString(iProp.organization))
                    , iSql.SqlCom_Parameter("@issueDate", HelperConvert.ConvertToDate112(iProp.issueDate))
                    , iSql.SqlCom_Parameter("@expireDate", HelperConvert.ConvertToDate112(iProp.expireDate))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
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

        public List<ServiceTrainingModels> DataList(ServiceTrainingModels iProp)
        {
            String query = "up_service_training_sel";
            lData = new List<ServiceTrainingModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceTrainingModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 trainingId = HelperConvert.ConvertToString(r.Field<object>("trainingId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 certificateNo = GetOptionalString(r, "certificateNo")
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 issueDate = HelperConvert.ConvertToString(r.Field<object>("issueDate")!)
                                 ,
                                 expireDate = HelperConvert.ConvertToString(r.Field<object>("expireDate")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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

        private static string GetOptionalString(DataRow row, string columnName)
        {
            if (row == null || row.Table == null || !row.Table.Columns.Contains(columnName))
            {
                return "";
            }

            return HelperConvert.ConvertToString(row.Field<object>(columnName)!);
        }
    }
}
