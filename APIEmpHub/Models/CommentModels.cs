using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class CommentModels : baseModels<CommentModels>
    {
        public string id { get; set; }
        public string refId { get; set; }
        public string mode { get; set; }
        public string detail { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string create_department { get; set; }
        public string create_date { get; set; }
        public string update_by { get; set; }
        public int can_delete { get; set; }

        public string mailId { get; set; }
        public int is_send { get; set; }
        public string ErrorMessage { get; set; }

        public void Create(CommentModels iProp)
        {
            String query = "up_comment_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
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


        public void CommentMail(CommentModels iProp)
        {
            String query = "up_service_mail_comment";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@commentId", HelperConvert.ConvertToString(iProp.id))
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

        public void MailResponse(CommentModels iProp)
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


        public void Delete(CommentModels iProp)
        {
            String query = "up_comment_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
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

        public List<CommentModels> DataList(CommentModels iProp)
        {
            String query = "up_comment_sel";
            List<CommentModels> lData = new List<CommentModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new CommentModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 detail = HelperConvert.ConvertToString(r.Field<object>("detail")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_department = HelperConvert.ConvertToString(r.Field<object>("create_department")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 can_delete = HelperConvert.ConvertToInt(r.Field<object>("can_delete")!)
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
