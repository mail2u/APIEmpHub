using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceEducationModels : baseModels<ServiceEducationModels>
    {
        public string refId { get; set; }
        public string educationId { get; set; }
        public string mode { get; set; } = "";
        public string institution { get; set; }
        public string degreeCode { get; set; }
        public string degreeName { get; set; }
        public string programCode { get; set; }
        public string programName { get; set; }
        public string major { get; set; }
        public int startYear { get; set; } = 0;
        public int year { get; set; } = 0;
        public decimal grade { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Save(ServiceEducationModels iProp)
        {
            String query = "up_service_education_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@educationId", HelperConvert.ConvertToString(iProp.educationId))
                    , iSql.SqlCom_Parameter("@institution", HelperConvert.ConvertToString(iProp.institution))
                    , iSql.SqlCom_Parameter("@degreeCode", HelperConvert.ConvertToString(iProp.degreeCode))
                    , iSql.SqlCom_Parameter("@degreeName", HelperConvert.ConvertToString(iProp.degreeName))
                    , iSql.SqlCom_Parameter("@programCode", HelperConvert.ConvertToString(iProp.programCode))
                    , iSql.SqlCom_Parameter("@programName", HelperConvert.ConvertToString(iProp.programName))
                    , iSql.SqlCom_Parameter("@major", HelperConvert.ConvertToString(iProp.major))
                    , iSql.SqlCom_Parameter("@startYear", iProp.startYear)
                    , iSql.SqlCom_Parameter("@year", iProp.year)
                    , iSql.SqlCom_Parameter("@grade", iProp.grade)
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

        public List<ServiceEducationModels> DataList(ServiceEducationModels iProp)
        {
            String query = "up_service_education_sel";
            lData = new List<ServiceEducationModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceEducationModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 educationId = HelperConvert.ConvertToString(r.Field<object>("educationId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 institution = HelperConvert.ConvertToString(r.Field<object>("institution")!)
                                 ,
                                 degreeCode = HelperConvert.ConvertToString(r.Field<object>("degreeCode")!)
                                 ,
                                 degreeName = HelperConvert.ConvertToString(r.Field<object>("degreeName")!)
                                 ,
                                 programCode = HelperConvert.ConvertToString(r.Field<object>("programCode")!)
                                 ,
                                 programName = HelperConvert.ConvertToString(r.Field<object>("programName")!)
                                 ,
                                 major = HelperConvert.ConvertToString(r.Field<object>("major")!)
                                 ,
                                 startYear = HelperConvert.ConvertToInt(r.Field<object>("startYear")!)
                                 ,
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
                                 ,
                                 grade = HelperConvert.ConvertToInt(r.Field<object>("grade")!)
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
    }
}
