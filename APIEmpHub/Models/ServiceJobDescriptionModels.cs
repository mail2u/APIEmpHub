using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class ServiceJobDescriptionModels : baseModels<ServiceJobDescriptionModels>
    {
        public string refId { get; set; }
        public string positionName { get; set; }
        public string jobFunction { get; set; }
        public string departmentName { get; set; }
        public string sectionName { get; set; }
        public string position_description { get; set; }

        public string major_description { get; set; }

        public string education { get; set; }
        public string experience { get; set; }
        public string functional_competencies { get; set; }
        public string leadership_competencies { get; set; }

        public string financial { get; set; }
        public string customer_and_market { get; set; }
        public string process { get; set; }
        public string people_development { get; set; }

        public string internal_description { get; set; }
        public string internal_contact_description { get; set; }
        public string external_description { get; set; }
        public string external_contact_description { get; set; }

        public int can_edit { get; set; }
        public string userId { get; set; } = "";
        public string create_by { get; set; } = "";

        public void Save(ServiceJobDescriptionModels iProp)
        {
            String query = "up_service_jobdescription_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))

                    , iSql.SqlCom_Parameter("@positionName", HelperConvert.ConvertToString(iProp.positionName))
                    , iSql.SqlCom_Parameter("@jobFunction", HelperConvert.ConvertToString(iProp.jobFunction))
                    , iSql.SqlCom_Parameter("@departmentName", HelperConvert.ConvertToString(iProp.departmentName))
                    , iSql.SqlCom_Parameter("@sectionName", HelperConvert.ConvertToString(iProp.sectionName))
                    , iSql.SqlCom_Parameter("@position_description", HelperConvert.ConvertToString(iProp.position_description))

                    , iSql.SqlCom_Parameter("@major_description", HelperConvert.ConvertToString(iProp.major_description))

                    , iSql.SqlCom_Parameter("@education", HelperConvert.ConvertToString(iProp.education))
                    , iSql.SqlCom_Parameter("@experience", HelperConvert.ConvertToString(iProp.experience))
                    , iSql.SqlCom_Parameter("@functional_competencies", HelperConvert.ConvertToString(iProp.functional_competencies))
                    , iSql.SqlCom_Parameter("@leadership_competencies", HelperConvert.ConvertToString(iProp.leadership_competencies))

                    , iSql.SqlCom_Parameter("@financial", HelperConvert.ConvertToString(iProp.financial))
                    , iSql.SqlCom_Parameter("@customer_and_market", HelperConvert.ConvertToString(iProp.customer_and_market))
                    , iSql.SqlCom_Parameter("@process", HelperConvert.ConvertToString(iProp.process))
                    , iSql.SqlCom_Parameter("@people_development", HelperConvert.ConvertToString(iProp.people_development))

                    , iSql.SqlCom_Parameter("@internal_description", HelperConvert.ConvertToString(iProp.internal_description))
                    , iSql.SqlCom_Parameter("@internal_contact_description", HelperConvert.ConvertToString(iProp.internal_contact_description))
                    , iSql.SqlCom_Parameter("@external_description", HelperConvert.ConvertToString(iProp.external_description))
                    , iSql.SqlCom_Parameter("@external_contact_description", HelperConvert.ConvertToString(iProp.external_contact_description))
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

        public ServiceJobDescriptionModels Detail(ServiceJobDescriptionModels iProp)
        {
            String query = "up_service_jobdescription_detail";
            iData = new ServiceJobDescriptionModels();

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

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceJobDescriptionModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 positionName = HelperConvert.ConvertToString(r.Field<object>("positionName")!)
                                 ,
                                 jobFunction = HelperConvert.ConvertToString(r.Field<object>("jobFunction")!)
                                 ,
                                 departmentName = HelperConvert.ConvertToString(r.Field<object>("departmentName")!)
                                 ,
                                 sectionName = HelperConvert.ConvertToString(r.Field<object>("sectionName")!)
                                 ,
                                 position_description = HelperConvert.ConvertToString(r.Field<object>("position_description")!)
                                 ,
                                 major_description = HelperConvert.ConvertToString(r.Field<object>("major_description")!)
                                 ,
                                 education = HelperConvert.ConvertToString(r.Field<object>("education")!)
                                 ,
                                 experience = HelperConvert.ConvertToString(r.Field<object>("experience")!)
                                 ,
                                 functional_competencies = HelperConvert.ConvertToString(r.Field<object>("functional_competencies")!)
                                 ,
                                 leadership_competencies = HelperConvert.ConvertToString(r.Field<object>("leadership_competencies")!)
                                 ,
                                 financial = HelperConvert.ConvertToString(r.Field<object>("financial")!)
                                 ,
                                 customer_and_market = HelperConvert.ConvertToString(r.Field<object>("customer_and_market")!)
                                 ,
                                 process = HelperConvert.ConvertToString(r.Field<object>("process")!)
                                 ,
                                 people_development = HelperConvert.ConvertToString(r.Field<object>("people_development")!)
                                 ,
                                 internal_description = HelperConvert.ConvertToString(r.Field<object>("internal_description")!)
                                 ,
                                 internal_contact_description = HelperConvert.ConvertToString(r.Field<object>("internal_contact_description")!)
                                 ,
                                 external_description = HelperConvert.ConvertToString(r.Field<object>("external_description")!)
                                 ,
                                 external_contact_description = HelperConvert.ConvertToString(r.Field<object>("external_contact_description")!)
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
    }
}
