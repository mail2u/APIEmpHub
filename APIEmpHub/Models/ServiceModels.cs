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
        public string categoryCode { get; set; }
        public string categoryDesc { get; set; }
        public string title { get; set; }
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

        public string actionDate { get; set; }
        public string userBy { get; set; }
        public string userName { get; set; }
        public string userPosition { get; set; }
        public string userDepartment { get; set; }
        public string description { get; set; }

        public string search_create_by { get; set; }

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
                             title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                             ,
                             status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             ,
                             statusCss = HelperConvert.ConvertToString(r.Field<object>("statusCss")!)
                             ,
                             statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                             ,
                             createName = HelperConvert.ConvertToString(r.Field<object>("createName")!)
                             ,
                             createDate = HelperConvert.ConvertToString(r.Field<object>("createDate")!)
                             ,
                             userName = HelperConvert.ConvertToString(r.Field<object>("userName")!)
                             ,
                             userPosition = HelperConvert.ConvertToString(r.Field<object>("userPosition")!)
                             ,
                             userDepartment = HelperConvert.ConvertToString(r.Field<object>("userDepartment")!)
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

    }
}
