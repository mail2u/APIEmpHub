using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class ServiceModels : baseModels<ServiceModels>
    {
        public string id { get; set; }
        public string userId { get; set; }
        public string serviceNo { get; set; }
        public string categoryId { get; set; }
        public string categoryCode { get; set; }
        public string categoryDesc { get; set; }
        public string subCategoryId { get; set; }
        public string subCategoryCode { get; set; }
        public string subCategoryDesc { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string status { get; set; }
        public string statusCss { get; set; }
        public string statusDesc { get; set; }
        public string createBy { get; set; }
        public string createName { get; set; }
        public string createPosition { get; set; }
        public string createDepartment { get; set; }
        public string createDate { get; set; }
        public string cancelBy { get; set; }
        public string cancelDate { get; set; }
        public string cancelDesc { get; set; }
        public string rejectBy { get; set; }
        public string rejectName { get; set; }
        public string rejectDate { get; set; }
        public string rejectDesc { get; set; }
        public string approveBy { get; set; }
        public string approveName { get; set; }
        public string approveDate { get; set; }
        public string approveDesc { get; set; }
        public int is_action { get; set; }
        public int can_cancel { get; set; }
        public int can_approve { get; set; }
        public int can_work { get; set; }
        public int can_assign { get; set; }
        public int can_previous { get; set; }
        public int can_edit { get; set; }

        public string actionDate { get; set; }
        public string userBy { get; set; }
        public string userName { get; set; }
        public string userPosition { get; set; }
        public string userDepartment { get; set; }
        public string description { get; set; }

        public string search_create_by { get; set; }
        public int year { get; set; }
        public int month { get; set; }

        public string mailId { get; set; }
        public int is_send { get; set; }
        public string ErrorMessage { get; set; }

        /* หน้า Service/OnBehalf : สร้างใบงานแทนผู้ใช้ */
        public string createMode { get; set; }
        public string batchId { get; set; }
        public string userSection { get; set; }
        public string employeeCode { get; set; }
        public List<string> lUserId { get; set; }
        public int total_created { get; set; }
        public int total_skip { get; set; }
        public int total_cancel { get; set; }
        public int total_expired { get; set; }
        public int total_filled { get; set; }


        public List<ServiceModels> lUser { get; set; }

        public ServiceModels Detail(ServiceModels iProp)
        {
            String query = "up_service_detail";

            iData = new ServiceModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                );

                iData = (from r in dtData.AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             userName = HelperConvert.ConvertToString(r.Field<object>("userName")!)
                             ,
                             userPosition = HelperConvert.ConvertToString(r.Field<object>("userPosition")!)
                             ,
                             userDepartment = HelperConvert.ConvertToString(r.Field<object>("userDepartment")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createPosition = HelperConvert.ConvertToString(r.Field<object>("createPosition")!)
                             ,
                             createDepartment = HelperConvert.ConvertToString(r.Field<object>("createDepartment")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             approveName = HelperConvert.ConvertToString(r.Field<object>("approveName")!)
                             ,
                             approveDate = HelperConvert.ConvertToString(r.Field<object>("approveDate")!)
                             ,
                             rejectName = HelperConvert.ConvertToString(r.Field<object>("rejectName")!)
                             ,
                             rejectDate = HelperConvert.ConvertToString(r.Field<object>("rejectDate")!)
                             ,
                             rejectDesc = HelperConvert.ConvertToString(r.Field<object>("rejectDesc")!)
                             ,
                             can_cancel = HelperConvert.ConvertToInt(r.Field<object>("can_cancel")!)
                             ,
                             can_approve = HelperConvert.ConvertToInt(r.Field<object>("can_approve")!)
                             ,
                             can_work = HelperConvert.ConvertToInt(r.Field<object>("can_work")!)
                             ,
                             can_assign = HelperConvert.ConvertToInt(r.Field<object>("can_assign")!)
                             ,
                             can_edit = HelperConvert.ConvertToInt(r.Field<object>("can_edit")!)
                             ,
                             can_previous = HelperConvert.ConvertToInt(r.Field<object>("can_previous")!)
                         }).FirstOrDefault()!;
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

        public void Create(ServiceModels iProp)
        {
            String query = "up_service_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@categoryId", HelperConvert.ConvertToString(iProp.categoryId))
                    , iSql.SqlCom_Parameter("@categoryCode", HelperConvert.ConvertToString(iProp.categoryCode))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@subCategoryId", HelperConvert.ConvertToString(iProp.subCategoryId))
                    , iSql.SqlCom_Parameter("@subCategoryCode", HelperConvert.ConvertToString(iProp.subCategoryCode))
                    , iSql.SqlCom_Parameter("@subCategoryDesc", HelperConvert.ConvertToString(iProp.subCategoryDesc))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
                    , iSql.SqlCom_Parameter("@createBy", HelperConvert.ConvertToString(iProp.createBy))
                    /* ว่าง = 'Request' ตาม default ใน proc  ส่ง 'Draft' เมื่อสร้างแทนผู้ใช้ */
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    /* ว่าง = NULL ตาม proc  ใบปกติไม่ต้องส่ง 2 ตัวนี้ */
                    , iSql.SqlCom_Parameter("@createMode", HelperConvert.ConvertToString(iProp.createMode))
                    , iSql.SqlCom_Parameter("@batchId", HelperConvert.ConvertToString(iProp.batchId))
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

        public void Request(ServiceModels iProp)
        {
            String query = "up_service_request_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.serviceNo = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@serviceNo"].Value);
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

        public void RequestResend(ServiceModels iProp)
        {
            String query = "up_service_request_upd_resend";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.serviceNo = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@serviceNo"].Value);
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

        public void Cancel(ServiceModels iProp)
        {
            String query = "up_service_cancel_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
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

        public void Approve(ServiceModels iProp)
        {
            String query = "up_service_approve_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@status", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@subCategoryCode", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.status = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@status"].Value);
                iProp.subCategoryCode = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@subCategoryCode"].Value);
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

        public void ApproveMail(ServiceModels iProp)
        {
            String query = "up_service_mail_approve";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.mailId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@id"].Value);
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

        public void Reject(ServiceModels iProp)
        {
            String query = "up_service_reject_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
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

        //public void RejectMail(ServiceModels iProp)
        //{
        //    String query = "up_service_mail_reject";

        //    try
        //    {
        //        iSql.Open(connectionString);
        //        iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
        //            , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.id))
        //            , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
        //            );

        //        iProp.mailId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@id"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        iSql.Close();
        //    }
        //}

        /* รับเรื่องไว้ดำเนินการ (กำลังดำเนินการ)
           ไม่เปลี่ยน status เพราะ 'Assign' ในระบบนี้เป็นสถานะเสมือน (ใบ Work ที่ยังไม่มีผู้รับผิดชอบ)
           และ ServiceStepInfo ผูกกับ status อยู่ จึงบันทึกที่ progressBy/progressDate แทน
           ทำให้ can_work ไม่ถูกกระทบ ปุ่มดำเนินการ/ปฏิเสธ ยังใช้ได้ */
        public void Progress(ServiceModels iProp)
        {
            String query = "up_service_progress_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@status", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@subCategoryCode", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.status = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@status"].Value);
                iProp.subCategoryCode = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@subCategoryCode"].Value);
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

        public void Assign(ServiceModels iProp)
        {
            String query = "up_service_assign_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
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

        public void Work(ServiceModels iProp)
        {
            String query = "up_service_work_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@status", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@subCategoryCode", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.status = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@status"].Value);
                iProp.subCategoryCode = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@subCategoryCode"].Value);
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

        public void Previous(ServiceModels iProp)
        {
            String query = "up_service_previous_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
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

        public void CompleteMail(ServiceModels iProp)
        {
            String query = "up_service_mail_complete";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.mailId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@id"].Value);
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

        public void MailResponse(ServiceModels iProp)
        {
            if (String.IsNullOrEmpty(iProp.mailId)) { return; }

            String query = "up_mail_upd_response";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.mailId))
                    , iSql.SqlCom_Parameter("@is_send", iProp.is_send)
                    , iSql.SqlCom_Parameter("@ErrorMessage", HelperConvert.ConvertToString(iProp.ErrorMessage))
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

        public List<ServiceModels> RequestList(ServiceModels iProp)
        {
            String query = "up_service_request_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                lData = (from r in dsData.Tables[0].AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createBy = HelperConvert.ConvertToString(r.Field<object>("createBy")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             orderDate1 = HelperConvert.ConvertToString(r.Field<object>("orderDate1")!)
                             ,
                             orderDate2 = HelperConvert.ConvertToString(r.Field<object>("orderDate2")!)
                         }).ToList();
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

        public DataTable RequestSummary(ServiceModels iProp)
        {
            String query = "up_service_request_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
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

        public List<ServiceModels> ApproveList(ServiceModels iProp)
        {
            String query = "up_service_approve_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                lData = (from r in dsData.Tables[0].AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createBy = HelperConvert.ConvertToString(r.Field<object>("createBy")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             orderDate1 = HelperConvert.ConvertToString(r.Field<object>("orderDate1")!)
                             ,
                             orderDate2 = HelperConvert.ConvertToString(r.Field<object>("orderDate2")!)
                         }).ToList();
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

        public DataTable ApproveSummary(ServiceModels iProp)
        {
            String query = "up_service_approve_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
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

        public List<ServiceModels> WorkList(ServiceModels iProp)
        {
            String query = "up_service_work_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                lData = (from r in dsData.Tables[0].AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createBy = HelperConvert.ConvertToString(r.Field<object>("createBy")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             orderDate1 = HelperConvert.ConvertToString(r.Field<object>("orderDate1")!)
                             ,
                             orderDate2 = HelperConvert.ConvertToString(r.Field<object>("orderDate2")!)
                         }).ToList();
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

        public DataTable WorkSummary(ServiceModels iProp)
        {
            String query = "up_service_work_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
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

        /* ====================================================================
           หน้า Service/OnBehalf : สร้างใบงานแทนผู้ใช้
           ==================================================================== */

        /* ค่าใน ServiceInfo.createMode
           ต้องตรงกับที่ up_service_onbehalf_sel / _summary ใช้กรอง
           ถ้าแก้ที่นี่ต้องแก้ใน proc ด้วย ไม่งั้นหน้าจอจะว่างโดยไม่มี error */
        public const string ONBEHALF_DRAFT = "OnBehalfDraft";

        public List<ServiceModels> OnBehalfList(ServiceModels iProp)
        {
            String query = "up_service_onbehalf_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@userName", HelperConvert.ConvertToString(iProp.userName))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                lData = (from r in dsData.Tables[0].AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                             ,
                             userName = HelperConvert.ConvertToString(r.Field<object>("userName")!)
                             ,
                             employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                             ,
                             userDepartment = HelperConvert.ConvertToString(r.Field<object>("userDepartment")!)
                             ,
                             userSection = HelperConvert.ConvertToString(r.Field<object>("userSection")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                         }).ToList();
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

        public DataTable OnBehalfSummary(ServiceModels iProp)
        {
            String query = "up_service_onbehalf_summary";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@userName", HelperConvert.ConvertToString(iProp.userName))
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

        /* สร้างใบงานสถานะ Draft ให้พนักงานหลายคนในครั้งเดียว

           วนสร้างฝั่ง server ไม่ให้หน้าจอวนเอง
           เลือก 200 คนจะกลายเป็นยิง API 200 ครั้ง ช้าและถ้าหลุดกลางทางจะค้างครึ่ง ๆ กลาง ๆ

           กันสร้างซ้ำ : ถ้าพนักงานคนนั้นมีใบ Draft ประเภทเดียวกันค้างอยู่แล้วให้ข้าม
           ใช้วิธีดึงรายการ Draft ที่มีอยู่มาเทียบครั้งเดียว ไม่ query ทีละคน  */
        public void CreateBulk(ServiceModels iProp)
        {
            iProp.total_created = 0;
            iProp.total_skip = 0;

            if (iProp.lUserId == null || iProp.lUserId.Count == 0)
            {
                throw new Exception("กรุณาเลือกพนักงานอย่างน้อย 1 คน");
            }

            if (String.IsNullOrEmpty(iProp.subCategoryCode))
            {
                throw new Exception("กรุณาเลือกประเภทแบบฟอร์ม");
            }

            /* 1 รอบการสร้างของ HR = 1 batchId ทุกใบในรอบใช้ค่าเดียวกัน
               ต้องใส่ตั้งแต่ตอนสร้าง ภายหลัง backfill ไม่ได้

               คืนค่านี้กลับไปให้หน้าจอด้วย เพื่อให้ toast มีปุ่มเรียกกลับทั้งชุดได้ */
            string batchId = "batch_" + Guid.NewGuid().ToString().ToLower();
            iProp.batchId = batchId;

            /* รายชื่อที่มีใบ Draft ประเภทเดียวกันค้างอยู่แล้ว */
            List<ServiceModels> lExist = OnBehalfList(new ServiceModels
            {
                userBy = iProp.createBy
                ,
                status = "Draft"
                ,
                page = 1
                ,
                row = 9999
            });

            HashSet<string> hExist = new HashSet<string>(
                lExist.Where(x => x.subCategoryCode == iProp.subCategoryCode).Select(x => x.userId));

            foreach (string userId in iProp.lUserId.Distinct())
            {
                if (String.IsNullOrEmpty(userId)) { continue; }

                if (hExist.Contains(userId))
                {
                    iProp.total_skip = iProp.total_skip + 1;
                    continue;
                }

                Create(new ServiceModels
                {
                    userId = userId
                    ,
                    categoryId = iProp.categoryId
                    ,
                    categoryCode = iProp.categoryCode
                    ,
                    categoryDesc = iProp.categoryDesc
                    ,
                    subCategoryId = iProp.subCategoryId
                    ,
                    subCategoryCode = iProp.subCategoryCode
                    ,
                    subCategoryDesc = iProp.subCategoryDesc
                    ,
                    title = iProp.title
                    ,
                    detail = iProp.detail
                    ,
                    createBy = iProp.createBy
                    ,
                    status = "Draft"
                    ,
                    /* ตั้งค่าตายตัวที่นี่ ไม่รับจากหน้าจอ
                       ไม่งั้นจะปลอมใบธรรมดาให้ดูเหมือนใบที่สร้างแทนได้ */
                    createMode = ONBEHALF_DRAFT
                    ,
                    batchId = batchId
                });

                iProp.total_created = iProp.total_created + 1;
            }
        }

        /* เรียกกลับใบงานทั้งชุดที่สร้างในรอบเดียวกัน

           proc คืนผลเป็น result set 1 แถว ไม่ใช่ output parameter
           จึงใช้ DataAdapterWithDataTable ไม่ใช่ ExecuteNonQuery

           ถ้ายกเลิกไม่ได้เลย proc จะ raiserror เอง ไม่ต้องเช็คซ้ำที่นี่ */
        public void CancelBatch(ServiceModels iProp)
        {
            String query = "up_service_onbehalf_cancel_batch";

            iProp.total_cancel = 0;
            iProp.total_expired = 0;
            iProp.total_filled = 0;

            if (String.IsNullOrEmpty(iProp.batchId))
            {
                throw new Exception("ไม่พบรหัสชุดใบงานที่ต้องการยกเลิก");
            }

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@batchId", HelperConvert.ConvertToString(iProp.batchId))
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    /* ผู้ยกเลิกคือคนเดียวกับเจ้าของชุด proc มี default ให้อยู่แล้ว
                       ส่งซ้ำเพื่อความชัดเจน ServiceModels ไม่มี property update_by */
                    , iSql.SqlCom_Parameter("@update_by", HelperConvert.ConvertToString(iProp.userBy))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    DataRow r = dtData.Rows[0];

                    iProp.total_cancel = HelperConvert.ConvertToInt(r["total_cancel"]);
                    iProp.total_expired = HelperConvert.ConvertToInt(r["total_expired"]);
                    iProp.total_filled = HelperConvert.ConvertToInt(r["total_filled"]);
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
        }

        public List<ServiceModels> InquireList(ServiceModels iProp)
        {
            String query = "up_service_inquire_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                lData = (from r in dsData.Tables[0].AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createBy = HelperConvert.ConvertToString(r.Field<object>("createBy")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             orderDate1 = HelperConvert.ConvertToString(r.Field<object>("orderDate1")!)
                             ,
                             orderDate2 = HelperConvert.ConvertToString(r.Field<object>("orderDate2")!)
                         }).ToList();
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

        public List<ServiceModels> RequiredDocumentList(ServiceModels iProp)
        {
            String query = @"up_service_required_document_sel";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                lData = (from r in dtData.AsEnumerable()
                         select new ServiceModels
                         {
                             id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                             ,
                             serviceNo = HelperConvert.ConvertToString(r.Field<object>("serviceNo")!)
                             ,
                             categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                             ,
                             categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                             ,
                             subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                             ,
                             subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                             ,
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createBy = HelperConvert.ConvertToString(r.Field<object>("createBy")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             orderDate1 = HelperConvert.ConvertToString(r.Field<object>("orderDate1")!)
                             ,
                             orderDate2 = HelperConvert.ConvertToString(r.Field<object>("orderDate2")!)
                         }).ToList();
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

        public DataTable InquireSummary(ServiceModels iProp)
        {
            String query = "up_service_inquire_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                    , iSql.SqlCom_Parameter("@serviceNo", HelperConvert.ConvertToString(iProp.serviceNo))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@createName", HelperConvert.ConvertToString(iProp.createName))
                    , iSql.SqlCom_Parameter("@createDate", HelperConvert.ConvertToDate112(iProp.createDate))
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

        #region Dashboard

        public DataTable DashboardCategorySummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_category_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardUserCategorySummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_category_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardCategoryWait()
        {
            String query = "up_service_dashboard_category_wait";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardSubCategorySummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_subcategory_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardUserSubCategorySummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_subcategory_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardDepartmentSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_department_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardUserDepartmentSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_department_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardDepartmentWait()
        {
            String query = "up_service_dashboard_department_wait";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardStatusToday()
        {
            String query = "up_service_dashboard_status_today";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardStatusSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_status_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardUserStatusSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_status_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardStatusCurrent()
        {
            String query = "up_service_dashboard_status_current";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardYearSummary()
        {
            String query = "up_service_dashboard_year_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardUserYearSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_year_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardMonthSummary()
        {
            String query = "up_service_dashboard_month_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardDaySummary()
        {
            String query = "up_service_dashboard_day_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardWorkMonthSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_work_month_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
                , iSql.SqlCom_Parameter("@month", iProp.month)
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

        public DataTable DashboardWorkYearSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_work_year_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardWorkSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_work_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardApproveMonthSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_approve_month_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
                , iSql.SqlCom_Parameter("@month", iProp.month)
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

        public DataTable DashboardUserRequestWaitApproveSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_request_wait_approve_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardUserRequestWaitWorkSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_user_request_wait_work_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataTable DashboardApproveYearSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_approve_year_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public DataTable DashboardApproveSummary(ServiceModels iProp)
        {
            String query = "up_service_dashboard_approve_summary";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
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

        public DataSet DashboardWorkSLA(ServiceModels iProp)
        {
            String query = "up_service_dashboard_work_sla";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
                , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
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

            return dsData;
        }

        public DataSet DashboardApproveSLA(ServiceModels iProp)
        {
            String query = "up_service_dashboard_approve_sla";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
                , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
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

            return dsData;
        }

        public DataSet DashboardRequestNoClose(ServiceModels iProp)
        {
            String query = "up_service_dashboard_request_no_close";

            lData = new List<ServiceModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
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

            return dsData;
        }

        #endregion
    }
}
