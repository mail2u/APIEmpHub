using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class DownloadModels : baseModels<DownloadModels>
    {
        public string code { get; set; }
        public string userId { get; set; }
        public string filename { get; set; }

        public DataTable GetFilePath(DownloadModels iProp)
        {
            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable("up_download_file_storage_getfile", CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                , iSql.SqlCom_Parameter("@filename",SqlDbType.NVarChar, 2000, ParameterDirection.Output)
                );

                iProp.filename = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@filename"].Value);
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
