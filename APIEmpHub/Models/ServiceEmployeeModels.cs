using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceEmployeeModels : baseModels<ServiceEmployeeModels>
    {
        public string refId { get; set; }
        public string mode { get; set; }
        public string processType { get; set; }
        public string processReason { get; set; }
        public string employeeId { get; set; }
        public string employeeCode { get; set; }
        public string employeeName { get; set; }
        public string employeeType { get; set; }
        public string employeeDesc { get; set; }
        public string email { get; set; }
        public string ext { get; set; }
        public string phone_office { get; set; }
        public string functionCode { get; set; }
        public string functionDesc { get; set; }
        public string divisionCode { get; set; }
        public string divisionDesc { get; set; }
        public string departmentCode { get; set; }
        public string departmentDesc { get; set; }
        public string sectionCode { get; set; }
        public string sectionDesc { get; set; }
        public string positionCode { get; set; }
        public string positionDesc { get; set; }
        public string levelCode { get; set; }
        public string levelDesc { get; set; }
        public string grade { get; set; }
        public string join_date { get; set; }
        public string probation_end_date { get; set; }
        public int probation_day { get; set; }
        public string supervisorId { get; set; }
        public string supervisorName { get; set; }
        public string supervisorPosition { get; set; }
        public string supervisorDepartment { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public int level { get; set; }
        public string location { get; set; }
        public string locationDesc { get; set; }
        public string sso { get; set; }
        public string ssoDesc { get; set; }
        public string workMode { get; set; }
        public string workModeDesc { get; set; }
        public string workTime { get; set; }
        public string workTimeDesc { get; set; }
        public string otMode { get; set; }
        public string otModeDesc { get; set; }
        public string employeeMode { get; set; }
        public string employeeModeDesc { get; set; }
        public string calendarCode { get; set; }
        public string calendarDesc { get; set; }
        public decimal salary { get; set; } = 0;
        public string paymentChannel { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string bookNo { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Save(ServiceEmployeeModels iProp)
        {
            String query = "up_service_employee_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@processType", HelperConvert.ConvertToString(iProp.processType))
                    , iSql.SqlCom_Parameter("@processReason", HelperConvert.ConvertToString(iProp.processReason))
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@employeeType", HelperConvert.ConvertToString(iProp.employeeType))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@ext", HelperConvert.ConvertToString(iProp.ext))
                    , iSql.SqlCom_Parameter("@phone_office", HelperConvert.ConvertToString(iProp.phone_office))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
                    , iSql.SqlCom_Parameter("@grade", HelperConvert.ConvertToString(iProp.grade))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@probration_end_date", HelperConvert.ConvertToDate112(iProp.probation_end_date))
                    , iSql.SqlCom_Parameter("@probration_day", iProp.probation_day)
                    , iSql.SqlCom_Parameter("@supervisorId", HelperConvert.ConvertToString(iProp.supervisorId))
                    , iSql.SqlCom_Parameter("@location", HelperConvert.ConvertToString(iProp.location))
                    , iSql.SqlCom_Parameter("@sso", HelperConvert.ConvertToString(iProp.sso))
                    , iSql.SqlCom_Parameter("@workMode", HelperConvert.ConvertToString(iProp.workMode))
                    , iSql.SqlCom_Parameter("@workModeDesc", HelperConvert.ConvertToString(iProp.workModeDesc))
                    , iSql.SqlCom_Parameter("@workTime", HelperConvert.ConvertToString(iProp.workTime))
                    , iSql.SqlCom_Parameter("@workTimeDesc", HelperConvert.ConvertToString(iProp.workTimeDesc))
                    , iSql.SqlCom_Parameter("@otMode", HelperConvert.ConvertToString(iProp.otMode))
                    , iSql.SqlCom_Parameter("@otModeDesc", HelperConvert.ConvertToString(iProp.otModeDesc))
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

        public ServiceEmployeeModels Detail(ServiceEmployeeModels iProp)
        {
            String query = "up_service_employee_detail";
            iData = new ServiceEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 processType = HelperConvert.ConvertToString(r.Field<object>("processType")!)
                                 ,
                                 processReason = HelperConvert.ConvertToString(r.Field<object>("processReason")!)
                                 ,
                                 employeeId = HelperConvert.ConvertToString(r.Field<object>("employeeId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 employeeType = HelperConvert.ConvertToString(r.Field<object>("employeeType")!)
                                 ,
                                 employeeDesc = HelperConvert.ConvertToString(r.Field<object>("employeeDesc")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 ext = HelperConvert.ConvertToString(r.Field<object>("ext")!)
                                 ,
                                 phone_office = HelperConvert.ConvertToString(r.Field<object>("phone_office")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 positionCode = HelperConvert.ConvertToString(r.Field<object>("positionCode")!)
                                 ,
                                 positionDesc = HelperConvert.ConvertToString(r.Field<object>("positionDesc")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 levelDesc = HelperConvert.ConvertToString(r.Field<object>("levelDesc")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 probation_end_date = HelperConvert.ConvertToString(r.Field<object>("probation_end_date")!)
                                 ,
                                 probation_day = HelperConvert.ConvertToInt(r.Field<object>("probation_day")!)
                                 ,
                                 supervisorId = HelperConvert.ConvertToString(r.Field<object>("supervisorId")!)
                                 ,
                                 supervisorName = HelperConvert.ConvertToString(r.Field<object>("supervisorName")!)
                                 ,
                                 supervisorPosition = HelperConvert.ConvertToString(r.Field<object>("supervisorPosition")!)
                                 ,
                                 supervisorDepartment = HelperConvert.ConvertToString(r.Field<object>("supervisorDepartment")!)
                                 ,
                                 location = HelperConvert.ConvertToString(r.Field<object>("location")!)
                                 ,
                                 locationDesc = HelperConvert.ConvertToString(r.Field<object>("locationDesc")!)
                                 ,
                                 sso = HelperConvert.ConvertToString(r.Field<object>("sso")!)
                                 ,
                                 ssoDesc = HelperConvert.ConvertToString(r.Field<object>("ssoDesc")!)
                                 ,
                                 workMode = HelperConvert.ConvertToString(r.Field<object>("workMode")!)
                                 ,
                                 workModeDesc = HelperConvert.ConvertToString(r.Field<object>("workModeDesc")!)
                                 ,
                                 workTime = HelperConvert.ConvertToString(r.Field<object>("workTime")!)
                                 ,
                                 workTimeDesc = HelperConvert.ConvertToString(r.Field<object>("workTimeDesc")!)
                                 ,
                                 otMode = HelperConvert.ConvertToString(r.Field<object>("otMode")!)
                                 ,
                                 otModeDesc = HelperConvert.ConvertToString(r.Field<object>("otModeDesc")!)
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
