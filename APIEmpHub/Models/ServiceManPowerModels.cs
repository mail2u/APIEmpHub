using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceManPowerModels : baseModels<ServiceManPowerModels>
    {
        public string refId { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string required_date { get; set; }
        public int num_employee { get; set; }
        public string type_employment { get; set; }
        public string type_employment_desc { get; set; }
        public string type_requirement { get; set; }
        public string type_reason { get; set; }
        public string type_reason_additional_hire_desc { get; set; }
        public string type_reason_replacement_desc { get; set; }
        public string description_work { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string education { get; set; }
        public string major { get; set; }
        public string knowledge { get; set; }
        public int skill_language { get; set; }
        public string skill_language_desc { get; set; }
        public int skill_computer { get; set; }
        public string skill_computer_desc { get; set; }
        public int skill_other { get; set; }
        public string skill_other_desc { get; set; }
        public string type_experience { get; set; }
        public string type_experience_yes_desc { get; set; }
        public string type_experience_other_desc { get; set; }
        public string userId { get; set; } = "";
        public string create_by { get; set; } = "";

        public void Save(ServiceManPowerModels iProp)
        {
            String query = "up_service_manpower_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@required_date", HelperConvert.ConvertToString(iProp.required_date))
                    , iSql.SqlCom_Parameter("@num_employee", iProp.num_employee)
                    , iSql.SqlCom_Parameter("@type_employment", HelperConvert.ConvertToString(iProp.type_employment))
                    , iSql.SqlCom_Parameter("@type_employment_desc", HelperConvert.ConvertToString(iProp.type_employment_desc))
                    , iSql.SqlCom_Parameter("@type_requirement", HelperConvert.ConvertToString(iProp.type_requirement))
                    , iSql.SqlCom_Parameter("@type_reason", HelperConvert.ConvertToString(iProp.type_reason))
                    , iSql.SqlCom_Parameter("@type_reason_additional_hire_desc", HelperConvert.ConvertToString(iProp.type_reason_additional_hire_desc))
                    , iSql.SqlCom_Parameter("@type_reason_replacement_desc", HelperConvert.ConvertToString(iProp.type_reason_replacement_desc))
                    , iSql.SqlCom_Parameter("@description_work", HelperConvert.ConvertToString(iProp.description_work))
                    , iSql.SqlCom_Parameter("@sex", HelperConvert.ConvertToString(iProp.sex))
                    , iSql.SqlCom_Parameter("@age", iProp.age)
                    , iSql.SqlCom_Parameter("@education", HelperConvert.ConvertToString(iProp.education))
                    , iSql.SqlCom_Parameter("@major", HelperConvert.ConvertToString(iProp.major))
                    , iSql.SqlCom_Parameter("@knowledge", HelperConvert.ConvertToString(iProp.knowledge))
                    , iSql.SqlCom_Parameter("@skill_language", iProp.skill_language)
                    , iSql.SqlCom_Parameter("@skill_language_desc", HelperConvert.ConvertToString(iProp.skill_language_desc))
                    , iSql.SqlCom_Parameter("@skill_computer", iProp.skill_computer)
                    , iSql.SqlCom_Parameter("@skill_computer_desc", HelperConvert.ConvertToString(iProp.skill_computer_desc))
                    , iSql.SqlCom_Parameter("@skill_other", iProp.skill_other)
                    , iSql.SqlCom_Parameter("@skill_other_desc", HelperConvert.ConvertToString(iProp.skill_other_desc))
                    , iSql.SqlCom_Parameter("@type_experience", HelperConvert.ConvertToString(iProp.type_experience))
                    , iSql.SqlCom_Parameter("@type_experience_yes_desc", HelperConvert.ConvertToString(iProp.type_experience_yes_desc))
                    , iSql.SqlCom_Parameter("@type_experience_other_desc", HelperConvert.ConvertToString(iProp.type_experience_other_desc))
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

        public ServiceManPowerModels Detail(ServiceManPowerModels iProp)
        {
            String query = "up_service_manpower_detail";
            iData = new ServiceManPowerModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceManPowerModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 required_date = HelperConvert.ConvertToString(r.Field<object>("required_date")!)
                                 ,
                                 num_employee = HelperConvert.ConvertToInt(r.Field<object>("num_employee")!)
                                 ,
                                 type_employment = HelperConvert.ConvertToString(r.Field<object>("type_employment")!)
                                 ,
                                 type_employment_desc = HelperConvert.ConvertToString(r.Field<object>("type_employment_desc")!)
                                 ,
                                 type_requirement = HelperConvert.ConvertToString(r.Field<object>("type_requirement")!)
                                 ,
                                 type_reason = HelperConvert.ConvertToString(r.Field<object>("type_reason")!)
                                 ,
                                 type_reason_additional_hire_desc = HelperConvert.ConvertToString(r.Field<object>("type_reason_additional_hire_desc")!)
                                 ,
                                 type_reason_replacement_desc = HelperConvert.ConvertToString(r.Field<object>("type_reason_replacement_desc")!)
                                 ,
                                 description_work = HelperConvert.ConvertToString(r.Field<object>("description_work")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 age = HelperConvert.ConvertToInt(r.Field<object>("age")!)
                                 ,
                                 education = HelperConvert.ConvertToString(r.Field<object>("education")!)
                                 ,
                                 major = HelperConvert.ConvertToString(r.Field<object>("major")!)
                                 ,
                                 knowledge = HelperConvert.ConvertToString(r.Field<object>("knowledge")!)
                                 ,
                                 skill_language = HelperConvert.ConvertToInt(r.Field<object>("skill_language")!)
                                 ,
                                 skill_language_desc = HelperConvert.ConvertToString(r.Field<object>("skill_language_desc")!)
                                 ,
                                 skill_computer = HelperConvert.ConvertToInt(r.Field<object>("skill_computer")!)
                                 ,
                                 skill_computer_desc = HelperConvert.ConvertToString(r.Field<object>("skill_computer_desc")!)
                                 ,
                                 skill_other = HelperConvert.ConvertToInt(r.Field<object>("skill_other")!)
                                 ,
                                 skill_other_desc = HelperConvert.ConvertToString(r.Field<object>("skill_other_desc")!)
                                 ,
                                 type_experience = HelperConvert.ConvertToString(r.Field<object>("type_experience")!)
                                 ,
                                 type_experience_yes_desc = HelperConvert.ConvertToString(r.Field<object>("type_experience_yes_desc")!)
                                 ,
                                 type_experience_other_desc = HelperConvert.ConvertToString(r.Field<object>("type_experience_other_desc")!)
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
