using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class UserModels : baseModels<UserModels>
    {
        public string userId { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string firstname_en { get; set; }
        public string lastname_en { get; set; }
        public string firstname_th { get; set; }
        public string lastname_th { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string birth_date { get; set; }
        public string education { get; set; }
        public string educationDesc { get; set; }
        public string status { get; set; }
        public string statusDesc { get; set; }
        public string email { get; set; }
        public string departmentCode { get; set; }
        public string departmentDesc { get; set; }
        public string positionCode { get; set; }
        public string positionDesc { get; set; }
        public string levelCode { get; set; }
        public string authenCode { get; set; }
        public string employeeType { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string ipaddress { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }

        public void Register(UserModels iProp)
        {
            String query = "up_user_register";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@firstname", HelperConvert.ConvertToString(iProp.firstname_en))
                    , iSql.SqlCom_Parameter("@lastname", HelperConvert.ConvertToString(iProp.lastname_en))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@ipaddress", HelperConvert.ConvertToString(iProp.ipaddress))
                    );

                iProp.userId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@userId"].Value);
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

        public void Create(UserModels iProp)
        {
            String query = "up_user_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    );

                iProp.userId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@userId"].Value);
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

        public void Delete(UserModels iProp)
        {
            String query = "up_user_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

        public void Login(UserModels iProp)
        {
            String query = "up_user_login";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@firstname_th", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@lastname_th", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@department", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@role", SqlDbType.NVarChar, 200, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@ipaddress", HelperConvert.ConvertToString(iProp.ipaddress))
                    );

                iProp.userId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@userId"].Value);
                iProp.firstname_th = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@firstname_th"].Value);
                iProp.lastname_th = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@lastname_th"].Value);
                iProp.departmentDesc = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@department"].Value);
                iProp.role = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@role"].Value);
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

        public DataTable ProfileSummary(UserModels iProp)
        {
            String query = "up_user_profile_summary";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

            return dtData;
        }

        public List<UserModels> DataList(UserModels iProp)
        {
            String query = "up_user_sel";
            lData = new List<UserModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@firstname_th", HelperConvert.ConvertToString(iProp.firstname_th))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
                    , iSql.SqlCom_Parameter("@employeeType", HelperConvert.ConvertToString(iProp.employeeType))
                    , iSql.SqlCom_Parameter("@dateFrom", HelperConvert.ConvertToString(iProp.dateFrom))
                    , iSql.SqlCom_Parameter("@dateTo", HelperConvert.ConvertToString(iProp.dateTo))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new UserModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 username = HelperConvert.ConvertToString(r.Field<object>("username")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 nickname = HelperConvert.ConvertToString(r.Field<object>("nickname")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 positionCode = HelperConvert.ConvertToString(r.Field<object>("positionCode")!)
                                 ,
                                 positionDesc = HelperConvert.ConvertToString(r.Field<object>("positionDesc")!)
                                 ,
                                 employeeType = HelperConvert.ConvertToString(r.Field<object>("employeeType")!)
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

        public ServiceAddressModels UserAddress(UserModels iProp)
        {
            String query = "up_user_address_detail";
            ServiceAddressModels iData = new ServiceAddressModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceAddressModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 addressId = HelperConvert.ConvertToString(r.Field<object>("addressId")!)
                                 ,
                                 home = HelperConvert.ConvertToString(r.Field<object>("home")!)
                                 ,
                                 road = HelperConvert.ConvertToString(r.Field<object>("road")!)
                                 ,
                                 subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("subDistrictCode")!)
                                 ,
                                 subDistrictName = HelperConvert.ConvertToString(r.Field<object>("subDistrictName")!)
                                 ,
                                 districtCode = HelperConvert.ConvertToString(r.Field<object>("districtCode")!)
                                 ,
                                 districtName = HelperConvert.ConvertToString(r.Field<object>("districtName")!)
                                 ,
                                 provinceCode = HelperConvert.ConvertToString(r.Field<object>("provinceCode")!)
                                 ,
                                 provinceName = HelperConvert.ConvertToString(r.Field<object>("provinceName")!)
                                 ,
                                 postcode = HelperConvert.ConvertToString(r.Field<object>("postcode")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public List<ServiceEducationModels> UserEducation(UserModels iProp)
        {
            String query = "up_user_education_sel";
            List<ServiceEducationModels> lData = new List<ServiceEducationModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
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
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 levelName = HelperConvert.ConvertToString(r.Field<object>("levelName")!)
                                 ,
                                 institution = HelperConvert.ConvertToString(r.Field<object>("institution")!)
                                 ,
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public ServiceEmployeeModels UserEmployee(UserModels iProp)
        {
            String query = "up_user_employee_detail";
            ServiceEmployeeModels iData = new ServiceEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
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
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public List<ServiceJobExperienceModels> UserJobExperience(UserModels iProp)
        {
            String query = "up_user_job_experience_sel";
            List<ServiceJobExperienceModels> lData = new List<ServiceJobExperienceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceJobExperienceModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 jobId = HelperConvert.ConvertToString(r.Field<object>("jobId")!)
                                 ,
                                 company = HelperConvert.ConvertToString(r.Field<object>("company")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 fromDate = HelperConvert.ConvertToString(r.Field<object>("fromDate")!)
                                 ,
                                 endDate = HelperConvert.ConvertToString(r.Field<object>("endDate")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public ServicePersonalModels UserPersonal(UserModels iProp)
        {
            String query = "up_user_personal_detail";
            ServicePersonalModels iData = new ServicePersonalModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServicePersonalModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 personalId = HelperConvert.ConvertToString(r.Field<object>("personalId")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 nickname = HelperConvert.ConvertToString(r.Field<object>("nickname")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 birth_date = HelperConvert.ConvertToString(r.Field<object>("birth_date")!)
                                 ,
                                 maritalStatus = HelperConvert.ConvertToString(r.Field<object>("maritalStatus")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 phoneNo = HelperConvert.ConvertToString(r.Field<object>("phoneNo")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public List<ServiceTraningModels> UserTraning(UserModels iProp)
        {
            String query = "up_service_traning_sel";
            List<ServiceTraningModels> lData = new List<ServiceTraningModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceTraningModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 traningId = HelperConvert.ConvertToString(r.Field<object>("traningId")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 issueDate = HelperConvert.ConvertToString(r.Field<object>("issueDate")!)
                                 ,
                                 expireDate = HelperConvert.ConvertToString(r.Field<object>("expireDate")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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
