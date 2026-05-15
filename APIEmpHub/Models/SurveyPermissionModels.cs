using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class SurveyPermissionModels : baseModels<SurveyPermissionModels>
    {
        public string id { get; set; }
        public string surveyId { get; set; }
        public string permission_type { get; set; }
        public string refId { get; set; }
        public string description { get; set; }
        public int is_active { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }


        public void Create(SurveyPermissionModels iProp)
        {
            String query = "up_survey_permission_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@surveyId", HelperConvert.ConvertToString(iProp.surveyId))
                    , iSql.SqlCom_Parameter("@permission_type", HelperConvert.ConvertToString(iProp.permission_type))
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
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

        public void Delete(SurveyPermissionModels iProp)
        {
            String query = "up_survey_permission_del";

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

        public List<SurveyPermissionModels> DataList(SurveyPermissionModels iProp)
        {
            String query = "up_survey_permission_sel";
            List<SurveyPermissionModels> lData = new List<SurveyPermissionModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@surveyId", HelperConvert.ConvertToString(iProp.surveyId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyPermissionModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 surveyId = HelperConvert.ConvertToString(r.Field<object>("surveyId")!)
                                 ,
                                 permission_type = HelperConvert.ConvertToString(r.Field<object>("permission_type")!)
                                 ,
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 is_active = HelperConvert.ConvertToInt(r.Field<object>("is_active")!)
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
