using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class UserModels : baseModels<UserModels>
    {
        public string userId { get; set; }
        public string role { get; set; }
        public string display_base64 { get; set; }
        public string username { get; set; }
        public string prefix_en { get; set; }
        public string firstname_en { get; set; }
        public string lastname_en { get; set; }
        public string prefix_th { get; set; }
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
        public string sectionCode { get; set; }
        public string sectionDesc { get; set; }
        public string departmentCode { get; set; }
        public string departmentDesc { get; set; }
        public string divisionCode { get; set; }
        public string divisionDesc { get; set; }
        public string positionCode { get; set; }
        public string positionDesc { get; set; }
        public string levelCode { get; set; }
        public string authenCode { get; set; }
        public string employeeCode { get; set; }
        public string employeeType { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string ipaddress { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public int have_signature { get; set; }
        public string base64 { get; set; }

        private static string GetOptionalString(DataRow row, string columnName)
        {
            return row.Table.Columns.Contains(columnName)
                ? HelperConvert.ConvertToString(row.Field<object>(columnName)!)
                : "";
        }

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

        public void UpdateSignature(UserModels iProp)
        {
            String query = "up_signature_sync_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@base64", HelperConvert.ConvertToString(iProp.base64))
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

        public void DeleteSignature(UserModels iProp)
        {
            String query = "up_signature_sync_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
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
                    , iSql.SqlCom_Parameter("@position", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@department", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@role", SqlDbType.NVarChar, 200, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@ipaddress", HelperConvert.ConvertToString(iProp.ipaddress))
                    );

                iProp.userId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@userId"].Value);
                iProp.firstname_th = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@firstname_th"].Value);
                iProp.lastname_th = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@lastname_th"].Value);
                iProp.positionDesc = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@position"].Value);
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
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new UserModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 username = HelperConvert.ConvertToString(r.Field<object>("username")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 prefix_en = HelperConvert.ConvertToString(r.Field<object>("prefix_en")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
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
                                 ,
                                 have_signature = HelperConvert.ConvertToInt(r.Field<object>("have_signature")!)
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

        public DataTable UserSummary(UserModels iProp)
        {
            String query = "up_user_summary";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@firstname_th", HelperConvert.ConvertToString(iProp.firstname_th))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
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

        #region Person
        public void UserPersonalSave(ServicePersonalModels iProp)
        {
            String query = "up_user_personal_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@prefix_th", HelperConvert.ConvertToString(iProp.prefix_th))
                    , iSql.SqlCom_Parameter("@firstname_th", HelperConvert.ConvertToString(iProp.firstname_th))
                    , iSql.SqlCom_Parameter("@lastname_th", HelperConvert.ConvertToString(iProp.lastname_th))
                    , iSql.SqlCom_Parameter("@prefix_en", HelperConvert.ConvertToString(iProp.prefix_en))
                    , iSql.SqlCom_Parameter("@firstname_en", HelperConvert.ConvertToString(iProp.firstname_en))
                    , iSql.SqlCom_Parameter("@lastname_en", HelperConvert.ConvertToString(iProp.lastname_en))
                    , iSql.SqlCom_Parameter("@nickname", HelperConvert.ConvertToString(iProp.nickname))
                    , iSql.SqlCom_Parameter("@sex", HelperConvert.ConvertToString(iProp.sex))
                    , iSql.SqlCom_Parameter("@birth_date", HelperConvert.ConvertToString(iProp.birth_date))
                    , iSql.SqlCom_Parameter("@age", HelperConvert.ConvertToString(iProp.age))
                    , iSql.SqlCom_Parameter("@weight", iProp.weight)
                    , iSql.SqlCom_Parameter("@height", iProp.height)
                    , iSql.SqlCom_Parameter("@blood", HelperConvert.ConvertToString(iProp.blood))
                    , iSql.SqlCom_Parameter("@idcard", HelperConvert.ConvertToString(iProp.idcard))
                    , iSql.SqlCom_Parameter("@passport", HelperConvert.ConvertToString(iProp.passport))
                    , iSql.SqlCom_Parameter("@workPermitNo", HelperConvert.ConvertToString(iProp.workPermitNo))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@phoneNo", HelperConvert.ConvertToString(iProp.phoneNo))
                    , iSql.SqlCom_Parameter("@mobile", HelperConvert.ConvertToString(iProp.mobile))
                    , iSql.SqlCom_Parameter("@nationality", HelperConvert.ConvertToString(iProp.nationality))
                    , iSql.SqlCom_Parameter("@ethnicity", HelperConvert.ConvertToString(iProp.ethnicity))
                    , iSql.SqlCom_Parameter("@religion", HelperConvert.ConvertToString(iProp.religion))
                    , iSql.SqlCom_Parameter("@maritalStatus", HelperConvert.ConvertToString(iProp.maritalStatus))
                    , iSql.SqlCom_Parameter("@militaryStatus", HelperConvert.ConvertToString(iProp.militaryStatus))
                    , iSql.SqlCom_Parameter("@disabilityStatus", HelperConvert.ConvertToString(iProp.disabilityStatus))
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
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServicePersonalModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 personalId = HelperConvert.ConvertToString(r.Field<object>("personalId")!)
                                 ,
                                 prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
                                 ,
                                 prefix_th_desc = HelperConvert.ConvertToString(r.Field<object>("prefix_th_desc")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 prefix_en = HelperConvert.ConvertToString(r.Field<object>("prefix_en")!)
                                 ,
                                 prefix_en_desc = HelperConvert.ConvertToString(r.Field<object>("prefix_en_desc")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 nickname = HelperConvert.ConvertToString(r.Field<object>("nickname")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 sex_desc = HelperConvert.ConvertToString(r.Field<object>("sex_desc")!)
                                 ,
                                 birth_date = HelperConvert.ConvertToString(r.Field<object>("birth_date")!)
                                 ,
                                 age = HelperConvert.ConvertToString(r.Field<object>("age")!)
                                 ,
                                 weight = HelperConvert.ConvertToInt(r.Field<object>("weight")!)
                                 ,
                                 height = HelperConvert.ConvertToInt(r.Field<object>("height")!)
                                 ,
                                 blood = HelperConvert.ConvertToString(r.Field<object>("blood")!)
                                 ,
                                 idcard = HelperConvert.ConvertToString(r.Field<object>("idcard")!)
                                 ,
                                 passport = HelperConvert.ConvertToString(r.Field<object>("passport")!)
                                 ,
                                 workPermitNo = HelperConvert.ConvertToString(r.Field<object>("workPermitNo")!)
                                 ,
                                 bankName = HelperConvert.ConvertToString(r.Field<object>("bankName")!)
                                 ,
                                 bookNo = HelperConvert.ConvertToString(r.Field<object>("bookNo")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 phoneNo = HelperConvert.ConvertToString(r.Field<object>("phoneNo")!)
                                 ,
                                 mobile = HelperConvert.ConvertToString(r.Field<object>("mobile")!)
                                 ,
                                 emergency_fullname = GetOptionalString(r, "emergency_fullname")
                                 ,
                                 emergency_relation = GetOptionalString(r, "emergency_relation")
                                 ,
                                 emergency_phone = GetOptionalString(r, "emergency_phone")
                                 ,
                                 emergency_email = GetOptionalString(r, "emergency_email")
                                 ,
                                 emergency_address = GetOptionalString(r, "emergency_address")
                                 ,
                                 nationality = HelperConvert.ConvertToString(r.Field<object>("nationality")!)
                                 ,
                                 nationalityDesc = HelperConvert.ConvertToString(r.Field<object>("nationalityDesc")!)
                                 ,
                                 ethnicity = HelperConvert.ConvertToString(r.Field<object>("ethnicity")!)
                                 ,
                                 ethnicityDesc = HelperConvert.ConvertToString(r.Field<object>("ethnicityDesc")!)
                                 ,
                                 religion = HelperConvert.ConvertToString(r.Field<object>("religion")!)
                                 ,
                                 religionDesc = HelperConvert.ConvertToString(r.Field<object>("religionDesc")!)
                                 ,
                                 maritalStatus = HelperConvert.ConvertToString(r.Field<object>("maritalStatus")!)
                                 ,
                                 maritalStatusDesc = HelperConvert.ConvertToString(r.Field<object>("maritalStatusDesc")!)
                                 ,
                                 militaryStatus = HelperConvert.ConvertToString(r.Field<object>("militaryStatus")!)
                                 ,
                                 militaryStatusDesc = HelperConvert.ConvertToString(r.Field<object>("militaryStatusDesc")!)
                                 ,
                                 disabilityStatus = HelperConvert.ConvertToString(r.Field<object>("disabilityStatus")!)
                                 ,
                                 disabilityStatusDesc = HelperConvert.ConvertToString(r.Field<object>("disabilityStatusDesc")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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
        #endregion

        #region Address
        public void UserAddressSave(ServiceAddressModels iProp)
        {
            String query = "up_user_address_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@registered_home", HelperConvert.ConvertToString(iProp.registered_home))
                    , iSql.SqlCom_Parameter("@registered_road", HelperConvert.ConvertToString(iProp.registered_road))
                    , iSql.SqlCom_Parameter("@registered_subDistrictCode", HelperConvert.ConvertToString(iProp.registered_subDistrictCode))
                    , iSql.SqlCom_Parameter("@registered_subDistrictName", HelperConvert.ConvertToString(iProp.registered_subDistrictName))
                    , iSql.SqlCom_Parameter("@registered_districtCode", HelperConvert.ConvertToString(iProp.registered_districtCode))
                    , iSql.SqlCom_Parameter("@registered_districtName", HelperConvert.ConvertToString(iProp.registered_districtName))
                    , iSql.SqlCom_Parameter("@registered_provinceCode", HelperConvert.ConvertToString(iProp.registered_provinceCode))
                    , iSql.SqlCom_Parameter("@registered_provinceName", HelperConvert.ConvertToString(iProp.registered_provinceName))
                    , iSql.SqlCom_Parameter("@registered_postcode", HelperConvert.ConvertToString(iProp.registered_postcode))

                    , iSql.SqlCom_Parameter("@card_home", HelperConvert.ConvertToString(iProp.card_home))
                    , iSql.SqlCom_Parameter("@card_road", HelperConvert.ConvertToString(iProp.card_road))
                    , iSql.SqlCom_Parameter("@card_subDistrictCode", HelperConvert.ConvertToString(iProp.card_subDistrictCode))
                    , iSql.SqlCom_Parameter("@card_subDistrictName", HelperConvert.ConvertToString(iProp.card_subDistrictName))
                    , iSql.SqlCom_Parameter("@card_districtCode", HelperConvert.ConvertToString(iProp.card_districtCode))
                    , iSql.SqlCom_Parameter("@card_districtName", HelperConvert.ConvertToString(iProp.card_districtName))
                    , iSql.SqlCom_Parameter("@card_provinceCode", HelperConvert.ConvertToString(iProp.card_provinceCode))
                    , iSql.SqlCom_Parameter("@card_provinceName", HelperConvert.ConvertToString(iProp.card_provinceName))
                    , iSql.SqlCom_Parameter("@card_postcode", HelperConvert.ConvertToString(iProp.card_postcode))

                    , iSql.SqlCom_Parameter("@live_home", HelperConvert.ConvertToString(iProp.live_home))
                    , iSql.SqlCom_Parameter("@live_road", HelperConvert.ConvertToString(iProp.live_road))
                    , iSql.SqlCom_Parameter("@live_subDistrictCode", HelperConvert.ConvertToString(iProp.live_subDistrictCode))
                    , iSql.SqlCom_Parameter("@live_subDistrictName", HelperConvert.ConvertToString(iProp.live_subDistrictName))
                    , iSql.SqlCom_Parameter("@live_districtCode", HelperConvert.ConvertToString(iProp.live_districtCode))
                    , iSql.SqlCom_Parameter("@live_districtName", HelperConvert.ConvertToString(iProp.live_districtName))
                    , iSql.SqlCom_Parameter("@live_provinceCode", HelperConvert.ConvertToString(iProp.live_provinceCode))
                    , iSql.SqlCom_Parameter("@live_provinceName", HelperConvert.ConvertToString(iProp.live_provinceName))
                    , iSql.SqlCom_Parameter("@live_postcode", HelperConvert.ConvertToString(iProp.live_postcode))
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
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceAddressModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 addressId = HelperConvert.ConvertToString(r.Field<object>("addressId")!)
                                 ,
                                 registered_home = HelperConvert.ConvertToString(r.Field<object>("registered_home")!)
                                 ,
                                 registered_road = HelperConvert.ConvertToString(r.Field<object>("registered_road")!)
                                 ,
                                 registered_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("registered_subDistrictCode")!)
                                 ,
                                 registered_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("registered_subDistrictName")!)
                                 ,
                                 registered_districtCode = HelperConvert.ConvertToString(r.Field<object>("registered_districtCode")!)
                                 ,
                                 registered_districtName = HelperConvert.ConvertToString(r.Field<object>("registered_districtName")!)
                                 ,
                                 registered_provinceCode = HelperConvert.ConvertToString(r.Field<object>("registered_provinceCode")!)
                                 ,
                                 registered_provinceName = HelperConvert.ConvertToString(r.Field<object>("registered_provinceName")!)
                                 ,
                                 registered_postcode = HelperConvert.ConvertToString(r.Field<object>("registered_postcode")!)
                                 ,
                                 card_home = HelperConvert.ConvertToString(r.Field<object>("card_home")!)
                                 ,
                                 card_road = HelperConvert.ConvertToString(r.Field<object>("card_road")!)
                                 ,
                                 card_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("card_subDistrictCode")!)
                                 ,
                                 card_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("card_subDistrictName")!)
                                 ,
                                 card_districtCode = HelperConvert.ConvertToString(r.Field<object>("card_districtCode")!)
                                 ,
                                 card_districtName = HelperConvert.ConvertToString(r.Field<object>("card_districtName")!)
                                 ,
                                 card_provinceCode = HelperConvert.ConvertToString(r.Field<object>("card_provinceCode")!)
                                 ,
                                 card_provinceName = HelperConvert.ConvertToString(r.Field<object>("card_provinceName")!)
                                 ,
                                 card_postcode = HelperConvert.ConvertToString(r.Field<object>("card_postcode")!)
                                 ,
                                 live_home = HelperConvert.ConvertToString(r.Field<object>("live_home")!)
                                 ,
                                 live_road = HelperConvert.ConvertToString(r.Field<object>("live_road")!)
                                 ,
                                 live_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("live_subDistrictCode")!)
                                 ,
                                 live_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("live_subDistrictName")!)
                                 ,
                                 live_districtCode = HelperConvert.ConvertToString(r.Field<object>("live_districtCode")!)
                                 ,
                                 live_districtName = HelperConvert.ConvertToString(r.Field<object>("live_districtName")!)
                                 ,
                                 live_provinceCode = HelperConvert.ConvertToString(r.Field<object>("live_provinceCode")!)
                                 ,
                                 live_provinceName = HelperConvert.ConvertToString(r.Field<object>("live_provinceName")!)
                                 ,
                                 live_postcode = HelperConvert.ConvertToString(r.Field<object>("live_postcode")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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
        #endregion

        #region Employee
        public void UserEmployeeSave(ServiceEmployeeModels iProp)
        {
            String query = "up_user_employee_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@processType", HelperConvert.ConvertToString(iProp.processType))
                    , iSql.SqlCom_Parameter("@processReason", HelperConvert.ConvertToString(iProp.processReason))
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@employeeType", HelperConvert.ConvertToString(iProp.employeeType))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@ext", HelperConvert.ConvertToString(iProp.ext))
                    , iSql.SqlCom_Parameter("@phone_office", HelperConvert.ConvertToString(iProp.phone_office))
                    , iSql.SqlCom_Parameter("@divisionCode", HelperConvert.ConvertToString(iProp.divisionCode))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@sectionCode", HelperConvert.ConvertToString(iProp.sectionCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
                    , iSql.SqlCom_Parameter("@grade", HelperConvert.ConvertToString(iProp.grade))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@probation_end_date", HelperConvert.ConvertToDate112(iProp.probation_end_date))
                    , iSql.SqlCom_Parameter("@probation_day", iProp.probation_day)
                    , iSql.SqlCom_Parameter("@supervisorId", HelperConvert.ConvertToString(iProp.supervisorId))
                    , iSql.SqlCom_Parameter("@location", HelperConvert.ConvertToString(iProp.location))
                    , iSql.SqlCom_Parameter("@sso", HelperConvert.ConvertToString(iProp.sso))
                    , iSql.SqlCom_Parameter("@workMode", HelperConvert.ConvertToString(iProp.workMode))
                    , iSql.SqlCom_Parameter("@workTime", HelperConvert.ConvertToString(iProp.workTime))
                    , iSql.SqlCom_Parameter("@otMode", HelperConvert.ConvertToString(iProp.otMode))
                    , iSql.SqlCom_Parameter("@employeeMode", HelperConvert.ConvertToString(iProp.employeeMode))
                    , iSql.SqlCom_Parameter("@calendarCode", HelperConvert.ConvertToString(iProp.calendarCode))
                    , iSql.SqlCom_Parameter("@salary", iProp.salary)
                    , iSql.SqlCom_Parameter("@paymentChannel", HelperConvert.ConvertToString(iProp.paymentChannel))
                    , iSql.SqlCom_Parameter("@bankCode", HelperConvert.ConvertToString(iProp.bankCode))
                    , iSql.SqlCom_Parameter("@bookNo", HelperConvert.ConvertToString(iProp.bookNo))
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
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceEmployeeModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
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
                                 divisionCode = HelperConvert.ConvertToString(r.Field<object>("divisionCode")!)
                                 ,
                                 divisionDesc = HelperConvert.ConvertToString(r.Field<object>("divisionDesc")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 sectionCode = HelperConvert.ConvertToString(r.Field<object>("sectionCode")!)
                                 ,
                                 sectionDesc = HelperConvert.ConvertToString(r.Field<object>("sectionDesc")!)
                                 ,
                                 positionCode = HelperConvert.ConvertToString(r.Field<object>("positionCode")!)
                                 ,
                                 positionDesc = HelperConvert.ConvertToString(r.Field<object>("positionDesc")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 levelDesc = HelperConvert.ConvertToString(r.Field<object>("levelDesc")!)
                                 ,
                                 grade = HelperConvert.ConvertToString(r.Field<object>("grade")!)
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
                                 ,
                                 employeeMode = HelperConvert.ConvertToString(r.Field<object>("employeeMode")!)
                                 ,
                                 calendarCode = HelperConvert.ConvertToString(r.Field<object>("calendarCode")!)
                                 ,
                                 salary = HelperConvert.ConvertToDecimal(r.Field<object>("salary")!)
                                 ,
                                 paymentChannel = HelperConvert.ConvertToString(r.Field<object>("paymentChannel")!)
                                 ,
                                 bankCode = HelperConvert.ConvertToString(r.Field<object>("bankCode")!)
                                 ,
                                 bookNo = HelperConvert.ConvertToString(r.Field<object>("bookNo")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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
        #endregion

        #region Display
        public void UserDisplaySave(UserModels iProp)
        {
            String query = "up_user_display_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@display_base64", HelperConvert.ConvertToString(iProp.display_base64))
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

        public UserModels UserDisplay(UserModels iProp)
        {
            String query = "up_user_display_detail";
            UserModels iData = new UserModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new UserModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 display_base64 = GetOptionalString(r, "display_base64")
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
        #endregion

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
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceEducationModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 educationId = HelperConvert.ConvertToString(r.Field<object>("educationId")!)
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
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
                                 ,
                                 grade = HelperConvert.ConvertToDecimal(r.Field<object>("grade")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

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
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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

        public List<ServiceTrainingModels> UserTraining(UserModels iProp)
        {
            String query = "up_user_training_sel";
            List<ServiceTrainingModels> lData = new List<ServiceTrainingModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    , iSql.SqlCom_Parameter("@can_view", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@can_edit", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.can_view = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_view"].Value);
                iProp.can_edit = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@can_edit"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceTrainingModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 trainingId = HelperConvert.ConvertToString(r.Field<object>("trainingId")!)
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
                                 ,
                                 update_by = HelperConvert.ConvertToString(r.Field<object>("update_by")!)
                                 ,
                                 update_date = HelperConvert.ConvertToString(r.Field<object>("update_date")!)
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

        public List<ServiceEmployeeModels> UserSub(UserModels iProp)
        {
            String query = "up_user_sub_with_me";
            List<ServiceEmployeeModels> lData = new List<ServiceEmployeeModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceEmployeeModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 employeeName = HelperConvert.ConvertToString(r.Field<object>("employeeName")!)
                                 ,
                                 sectionCode = HelperConvert.ConvertToString(r.Field<object>("sectionCode")!)
                                 ,
                                 sectionDesc = HelperConvert.ConvertToString(r.Field<object>("sectionDesc")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 divisionCode = HelperConvert.ConvertToString(r.Field<object>("divisionCode")!)
                                 ,
                                 divisionDesc = HelperConvert.ConvertToString(r.Field<object>("divisionDesc")!)
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

        public List<ServiceEmployeeModels> UserSup(UserModels iProp)
        {
            String query = "up_user_sup_me";
            List<ServiceEmployeeModels> lData = new List<ServiceEmployeeModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceEmployeeModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 employeeName = HelperConvert.ConvertToString(r.Field<object>("employeeName")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 positionDesc = HelperConvert.ConvertToString(r.Field<object>("positionDesc")!)
                                 ,
                                 level = HelperConvert.ConvertToInt(r.Field<object>("level")!)
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

        public ServiceEmployeeModels Detail(UserModels iProp)
        {
            String query = "up_user_detail";
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
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 employeeName = HelperConvert.ConvertToString(r.Field<object>("employeeName")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 sectionCode = HelperConvert.ConvertToString(r.Field<object>("sectionCode")!)
                                 ,
                                 sectionDesc = HelperConvert.ConvertToString(r.Field<object>("sectionDesc")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 departmentDesc = HelperConvert.ConvertToString(r.Field<object>("departmentDesc")!)
                                 ,
                                 divisionCode = HelperConvert.ConvertToString(r.Field<object>("divisionCode")!)
                                 ,
                                 divisionDesc = HelperConvert.ConvertToString(r.Field<object>("divisionDesc")!)
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
                                 employeeType = HelperConvert.ConvertToString(r.Field<object>("employeeType")!)
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
