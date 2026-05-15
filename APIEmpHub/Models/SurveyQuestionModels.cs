using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class SurveyQuestionModels : baseModels<SurveyQuestionModels>
    {
        public string id { get; set; }
        public string sectionId { get; set; }    
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int is_required { get; set; }
        public int order_index { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(SurveyQuestionModels iProp)
        {
            String query = "up_survey_question_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sectionId", HelperConvert.ConvertToString(iProp.sectionId))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@type", HelperConvert.ConvertToString(iProp.type))
                    , iSql.SqlCom_Parameter("@is_required", iProp.is_required)
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

        public void Update(SurveyQuestionModels iProp)
        {
            String query = "up_survey_question_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@type", HelperConvert.ConvertToString(iProp.type))
                    , iSql.SqlCom_Parameter("@is_required", iProp.is_required)
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

        public void Reorder(SurveyQuestionModels iProp)
        {
            String query = "up_survey_question_reorder";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@new_order", iProp.order_index)
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

        public void Delete(SurveyQuestionModels iProp)
        {
            String query = "up_survey_question_del";

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

        public List<SurveyQuestionModels> DataList(SurveyQuestionModels iProp)
        {
            String query = "up_survey_question_sel";
            List<SurveyQuestionModels> lData = new List<SurveyQuestionModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sectionId", HelperConvert.ConvertToString(iProp.sectionId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyQuestionModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 sectionId = HelperConvert.ConvertToString(r.Field<object>("sectionId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 type = HelperConvert.ConvertToString(r.Field<object>("type")!)
                                 ,
                                 is_required = HelperConvert.ConvertToInt(r.Field<object>("is_required")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
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
