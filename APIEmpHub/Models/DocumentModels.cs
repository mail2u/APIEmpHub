using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class DocumentModels : baseModels<DocumentModels>
    {
        public string docId { get; set; }
        public string title { get; set; }
        public string cover { get; set; }
        public string detail { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(DocumentModels iProp)
        {
            String query = "up_document_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@docId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@cover", HelperConvert.ConvertToString(iProp.cover))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    );

                iProp.docId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@docId"].Value);
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

        public void Update(DocumentModels iProp)
        {
            String query = "up_document_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@docId", HelperConvert.ConvertToString(iProp.docId))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@detail", HelperConvert.ConvertToString(iProp.detail))
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

        public void Delete(DocumentModels iProp)
        {
            String query = "up_document_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@docId", HelperConvert.ConvertToString(iProp.docId))
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

        public List<DocumentModels> DataList(DocumentModels iProp)
        {
            String query = "up_document_sel";
            List<DocumentModels> lData = new List<DocumentModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new DocumentModels
                             {
                                 docId = HelperConvert.ConvertToString(r.Field<object>("docId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 cover = HelperConvert.ConvertToString(r.Field<object>("cover")!)
                                 ,
                                 detail = HelperConvert.ConvertToString(r.Field<object>("detail")!)
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
