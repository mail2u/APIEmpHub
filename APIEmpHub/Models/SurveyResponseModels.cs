using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class SurveyResponseModels : baseModels<SurveyResponseModels>
    {
        public string id { get; set; }
        public string surveyId { get; set; }
        public string userId { get; set; }
        public string device_name { get; set; }
        public string ip_address { get; set; }
        public string create_date { get; set; }

        public void Create(SurveyResponseModels iProp)
        {
            String query = "up_survey_response_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@surveyId", HelperConvert.ConvertToString(iProp.surveyId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@device_name", HelperConvert.ConvertToString(iProp.device_name))
                    , iSql.SqlCom_Parameter("@ip_address", HelperConvert.ConvertToString(iProp.ip_address))
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
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

        public SurveyResponseModels Detail(SurveyResponseModels iProp)
        {
            String query = "up_survey_response_detail";
            iData = new SurveyResponseModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new SurveyResponseModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 surveyId = HelperConvert.ConvertToString(r.Field<object>("questionId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("text")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 device_name = HelperConvert.ConvertToString(r.Field<object>("device_name")!)
                                 ,
                                 ip_address = HelperConvert.ConvertToString(r.Field<object>("ip_address")!)
                             }).FirstOrDefault()!;
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

        public List<SurveyResponseModels> DataList(SurveyResponseModels iProp)
        {
            String query = "up_survey_response_sel";
            List<SurveyResponseModels> lData = new List<SurveyResponseModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@surveyId", HelperConvert.ConvertToString(iProp.surveyId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@total",SqlDbType.NVarChar,50,ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyResponseModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 surveyId = HelperConvert.ConvertToString(r.Field<object>("questionId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("text")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 device_name = HelperConvert.ConvertToString(r.Field<object>("device_name")!)
                                 ,
                                 ip_address = HelperConvert.ConvertToString(r.Field<object>("ip_address")!)
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
