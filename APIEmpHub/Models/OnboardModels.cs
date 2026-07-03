using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class OnboardModels : baseModels<OnboardModels>
    {
        public string userId { get; set; }
        public string idcard { get;set; }
        public string employeeCode { get; set; }
        public string prefix_th { get; set; }
        public string firstname_th { get; set; }
        public string lastname_th { get; set; }
        public string prefix_en { get; set; }
        public string firstname_en { get; set; }
        public string lastname_en { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string join_date { get; set; }
        public string status { get; set; }
        public string create_by { get; set; }
        public string create_date { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Create(OnboardModels iProp)
        {
            String query = "up_user_onboard_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
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

        public List<OnboardModels> ExistsByIDCard(OnboardModels iProp)
        {
            String query = "up_user_onboard_exists_by_idcard";
            lData = new List<OnboardModels>();

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@idcard", HelperConvert.ConvertToString(iProp.idcard))
                    );


                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                    select new OnboardModels
                    {
                        userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                        ,
                        employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                        ,
                        prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
                        ,
                        firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                        ,
                        lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                        ,
                        position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                        ,
                        department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                        ,
                        join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                        ,
                        status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public void Delete(OnboardModels iProp)
        {
            String query = "up_user_onboard_del";

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

        public void Cancel(OnboardModels iProp)
        {
            String query = "up_user_onboard_cancel_upd";

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

        public void Send(OnboardModels iProp)
        {
            String query = "up_user_onboard_send_upd";

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

        public DataTable Summary(OnboardModels iProp)
        {
            String query = "up_user_onboard_summary";

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

        public OnboardModels Detail(OnboardModels iProp)
        {
            String query = "up_user_onboard_detail";
            iData = new OnboardModels();

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
                             select new OnboardModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                             }).FirstOrDefault()!;
                }
                else
                {
                    throw new Exception("userId invalid");
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

        public List<OnboardModels> DataList(OnboardModels iProp)
        {
            String query = "up_user_onboard_sel";
            lData = new List<OnboardModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@firstname_th", HelperConvert.ConvertToString(iProp.firstname_th))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new OnboardModels
                             {
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 prefix_en = HelperConvert.ConvertToString(r.Field<object>("prefix_en")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
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
