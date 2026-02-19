using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceEmployeeModels : baseModels<ServiceEmployeeModels>
    {
        public string refId { get; set; }
        public string employeeId { get; set; }
        public string mode { get; set; }
        public string employeeCode { get; set; }
        public string employeeType { get; set; }
        public string employeeDesc { get; set; }
        public string email { get; set; }
        public string ext { get; set; }
        public string departmentCode { get; set; }
        public string departmentDesc { get; set; }
        public string positionCode { get; set; }
        public string positionDesc { get; set; }
        public string join_date { get; set; }
        public string supervisorId { get; set; }
        public string supervisorName { get; set; }
        public string supervisorPosition { get; set; }
        public string supervisorDepartment { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Save(ServiceEmployeeModels iProp)
        {
            String query = "up_service_employee_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@employeeType", HelperConvert.ConvertToString(iProp.employeeType))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@ext", HelperConvert.ConvertToString(iProp.ext))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@supervisorId", HelperConvert.ConvertToString(iProp.supervisorId))
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
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 positionCode = HelperConvert.ConvertToString(r.Field<object>("positionCode")!)
                                 ,
                                 positionDesc = HelperConvert.ConvertToString(r.Field<object>("positionDesc")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 supervisorId = HelperConvert.ConvertToString(r.Field<object>("supervisorId")!)
                                 ,
                                 supervisorName = HelperConvert.ConvertToString(r.Field<object>("supervisorName")!)
                                 ,
                                 supervisorPosition = HelperConvert.ConvertToString(r.Field<object>("supervisorPosition")!)
                                 ,
                                 supervisorDepartment = HelperConvert.ConvertToString(r.Field<object>("supervisorDepartment")!)
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
