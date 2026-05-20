using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class SurveyAnswerModels : baseModels<SurveyAnswerModels>
    {
        public string id { get; set; }
        public string surveyId { get; set; }
        public string responseId { get; set; }
        public string questionId { get; set; }
        public string choiceId { get; set; }
        public string choiceText { get; set; }
        public string answerText { get; set; }

        public void Create(SurveyAnswerModels iProp)
        {
            String query = "up_survey_answer_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@responseId", HelperConvert.ConvertToString(iProp.responseId))
                    , iSql.SqlCom_Parameter("@questionId", HelperConvert.ConvertToString(iProp.questionId))
                    , iSql.SqlCom_Parameter("@choiceId", HelperConvert.ConvertToString(iProp.choiceId))
                    , iSql.SqlCom_Parameter("@answerText", HelperConvert.ConvertToString(iProp.answerText))
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

        public List<SurveyAnswerModels> DataList(SurveyAnswerModels iProp)
        {
            String query = "up_survey_answer_sel";
            List<SurveyAnswerModels> lData = new List<SurveyAnswerModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@responseId", HelperConvert.ConvertToString(iProp.responseId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyAnswerModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 responseId = HelperConvert.ConvertToString(r.Field<object>("responseId")!)
                                 ,
                                 questionId = HelperConvert.ConvertToString(r.Field<object>("questionId")!)
                                 ,
                                 choiceId = HelperConvert.ConvertToString(r.Field<object>("choiceId")!)
                                 ,
                                 choiceText = HelperConvert.ConvertToString(r.Field<object>("choiceText")!)
                                 ,
                                 answerText = HelperConvert.ConvertToString(r.Field<object>("answerText")!)
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

        public List<SurveyAnswerModels> DataListBySurvey(SurveyAnswerModels iProp)
        {
            String query = "up_survey_answer_summary";
            List<SurveyAnswerModels> lData = new List<SurveyAnswerModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@surveyId", HelperConvert.ConvertToString(iProp.surveyId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyAnswerModels
                             {
                                 questionId = HelperConvert.ConvertToString(r.Field<object>("questionId")!)
                                 ,
                                 choiceId = HelperConvert.ConvertToString(r.Field<object>("choiceId")!)
                                 ,
                                 answerText = HelperConvert.ConvertToString(r.Field<object>("answerText")!)
                                 ,
                                 total = HelperConvert.ConvertToInt(r.Field<object>("total")!)
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

