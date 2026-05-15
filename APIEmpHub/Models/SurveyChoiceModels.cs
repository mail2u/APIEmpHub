using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class SurveyChoiceModels : baseModels<SurveyChoiceModels>
    {
        public string id { get; set; }
        public string questionId { get; set; }
        public string text { get; set; }
        public string value { get; set; }
        public int order_index { get; set; }


        public void Create(SurveyChoiceModels iProp)
        {
            String query = "up_survey_choice_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@questionId", HelperConvert.ConvertToString(iProp.questionId))
                    , iSql.SqlCom_Parameter("@text", HelperConvert.ConvertToString(iProp.text))
                    , iSql.SqlCom_Parameter("@value", HelperConvert.ConvertToString(iProp.value))
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

        public void Update(SurveyChoiceModels iProp)
        {
            String query = "up_survey_choice_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@text", HelperConvert.ConvertToString(iProp.text))
                    , iSql.SqlCom_Parameter("@value", HelperConvert.ConvertToString(iProp.value))
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

        public void Reorder(SurveyChoiceModels iProp)
        {
            String query = "up_survey_choice_reorder";

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

        public void Delete(SurveyChoiceModels iProp)
        {
            String query = "up_survey_choice_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
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

        public List<SurveyChoiceModels> DataList(SurveyChoiceModels iProp)
        {
            String query = "up_survey_choice_sel";
            List<SurveyChoiceModels> lData = new List<SurveyChoiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@questionId", HelperConvert.ConvertToString(iProp.questionId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new SurveyChoiceModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 questionId = HelperConvert.ConvertToString(r.Field<object>("questionId")!)
                                 ,
                                 text = HelperConvert.ConvertToString(r.Field<object>("text")!)
                                 ,
                                 value = HelperConvert.ConvertToString(r.Field<object>("value")!)
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
