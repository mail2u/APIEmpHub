using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class MailModels : baseModels<MailModels>
    {
        public string id { get; set; }
        public string sysId { get; set; }
        public string mailType { get; set; }
        public string mailitem_id { get; set; }
        public string profileName { get; set; }
        public string mailFrom { get; set; }
        public string mailTo { get; set; }
        public string mailCC { get; set; }
        public string mailBCC { get; set; }
        public string subject { get; set; }
        public string attachments { get; set; }
        public string body { get; set; }
        public string requestDate { get; set; }
        public string sendDate { get; set; }
        public string resendDate { get; set; }
        public int is_send { get; set; }
        public int is_error { get; set; }
        public string errorMessage { get; set; }

        public List<MailModels> DataList(MailModels iProp)
        {
            String query = "up_mail_sel";
            lData = new List<MailModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@subject", HelperConvert.ConvertToString(iProp.subject))
                    , iSql.SqlCom_Parameter("@mailTo", HelperConvert.ConvertToString(iProp.mailTo))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                iProp.total = HelperConvert.ConvertToInt(iSql.sqlCom.Parameters["@total"].Value);

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new MailModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 sysId = HelperConvert.ConvertToString(r.Field<object>("sysId")!)
                                 ,
                                 mailType = HelperConvert.ConvertToString(r.Field<object>("mailType")!)
                                 ,
                                 mailitem_id = HelperConvert.ConvertToString(r.Field<object>("mailitem_id")!)
                                 ,
                                 profileName = HelperConvert.ConvertToString(r.Field<object>("profileName")!)
                                 ,
                                 mailTo = HelperConvert.ConvertToString(r.Field<object>("mailTo")!)
                                 ,
                                 mailCC = HelperConvert.ConvertToString(r.Field<object>("mailCC")!)
                                 ,
                                 mailBCC = HelperConvert.ConvertToString(r.Field<object>("mailBCC")!)
                                 ,
                                 subject = HelperConvert.ConvertToString(r.Field<object>("subject")!)
                                 ,
                                 attachments = HelperConvert.ConvertToString(r.Field<object>("attachments")!)
                                 ,
                                 body = HelperConvert.ConvertToString(r.Field<object>("body")!)
                                 ,
                                 requestDate = HelperConvert.ConvertToString(r.Field<object>("requestDate")!)
                                 ,
                                 sendDate = HelperConvert.ConvertToString(r.Field<object>("sendDate")!)
                                 ,
                                 resendDate = HelperConvert.ConvertToString(r.Field<object>("resendDate")!)
                                 ,
                                 is_send = HelperConvert.ConvertToInt(r.Field<object>("is_send")!)
                                 ,
                                 is_error = HelperConvert.ConvertToInt(r.Field<object>("is_error")!)
                                 ,
                                 errorMessage = HelperConvert.ConvertToString(r.Field<object>("errorMessage")!)
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

        public void Resend(MailModels iProp)
        {
            String query = "up_mail_send";
            lData = new List<MailModels>();

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@flag", SqlDbType.Int, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@msg", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                );

                iProp.errorMessage = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@msg"].Value);
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
    }
}
