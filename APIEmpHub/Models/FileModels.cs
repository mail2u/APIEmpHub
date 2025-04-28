using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class FileModels : baseModels<FileModels>
    {
        public int id { get; set; }
        public string refId { get; set; }
        public string attachCode { get; set; }
        public string filename { get; set; }
        public string filetype { get; set; }
        public int filesize { get; set; }
        public string location { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }

        public string callerId { get; set; }
        public string base64 { get; set; }
        public string imageBase64 { get; set; }
        public string outputname { get; set; }

        public int fileindex { get; set; }
        public void Create(FileModels iProp)
        {
            string docFolder = System.IO.Path.Combine(this.webRoot, "docs");

            try
            {
                iSql.Open(connectionString);

                string newFileName = String.Format("{0}{1}{2}", "FIL", DateTime.Now.ToString("yyyyMMddHHmmss"), iProp.fileindex.ToString("000"));

                iProp.location = System.IO.Path.Combine(docFolder, iProp.callerId ?? "caller_dummy");
                iProp.location = System.IO.Path.Combine(iProp.location, DateTime.Now.ToString("yyyy"));
                iProp.location = System.IO.Path.Combine(iProp.location, DateTime.Now.ToString("yyyyMM"));
                iProp.location = System.IO.Path.Combine(iProp.location, DateTime.Now.ToString("yyyyMMdd"));

                if (!String.IsNullOrEmpty(iProp.refId))
                {
                    iProp.location = System.IO.Path.Combine(iProp.location, iProp.refId);
                }

                if (!System.IO.Directory.Exists(iProp.location)) { System.IO.Directory.CreateDirectory(iProp.location); }

                iProp.location = System.IO.Path.Combine(iProp.location, newFileName);

                byte[] bytes = Convert.FromBase64String(iProp.base64);
                MemoryStream memo = new MemoryStream(bytes);
                IFormFile file = new FormFile(memo, 0, bytes.Length, iProp.filename, iProp.filename);

                using (var stream = new System.IO.FileStream(iProp.location, System.IO.FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                iSql.SqlCom_DataAdapterWithDataTable("up_file_ins", CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@callerId", HelperConvert.ConvertToString(iProp.callerId))
                , iSql.SqlCom_Parameter("@attachCode", HelperConvert.ConvertToString(iProp.attachCode))
                , iSql.SqlCom_Parameter("@filename", HelperConvert.ConvertToString(iProp.filename))
                , iSql.SqlCom_Parameter("@filetype", HelperConvert.ConvertToString(iProp.filetype))
                , iSql.SqlCom_Parameter("@filesize", iProp.filesize)
                , iSql.SqlCom_Parameter("@location", HelperConvert.ConvertToString(iProp.location))
                , iSql.SqlCom_Parameter("@createBy", HelperConvert.ConvertToString(iProp.callerId))
                , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                , iSql.SqlCom_Parameter("@refId", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, HelperConvert.ConvertToString(iProp.refId))
                );

                iProp.refId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@refId"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                iSql.Close();
            }
        }

        public void Delete(FileModels iProp)
        {
            String query = "up_file_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", iProp.id)
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
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

        public List<FileModels> DataList(FileModels iProp)
        {
            String query = "up_file_sel";

            lData = new List<FileModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@id", iProp.id)
                    , iSql.SqlCom_Parameter("@attachCode", HelperConvert.ConvertToString(iProp.attachCode))
                    );

                lData = (from r in dtData.AsEnumerable()
                         select new FileModels
                         {
                             id = HelperConvert.ConvertToInt(r.Field<object>("id")!)
                             ,
                             refId = HelperConvert.ConvertToString(r.Field<object>("refid")!)
                             ,
                             attachCode = HelperConvert.ConvertToString(r.Field<object>("attachCode")!)
                             ,
                             imageBase64 = HelperConvert.ConvertToString(r.Field<object>("imageBase64")!)
                             ,
                             outputname = HelperConvert.ConvertToString(r.Field<object>("outputname")!)
                             ,
                             filename = HelperConvert.ConvertToString(r.Field<object>("filename")!)
                             ,
                             filetype = HelperConvert.ConvertToString(r.Field<object>("filetype")!)
                             ,
                             filesize = HelperConvert.ConvertToInt(r.Field<object>("filesize")!)
                             ,
                             location = HelperConvert.ConvertToString(r.Field<object>("location")!)
                         }).ToList();

                /* Load Image Base64 */
                lData = lData.Select(x =>
                {
                    x.base64 = GetStreamFromLocal(x);

                    return x;
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

        public String GetStreamFromLocal(FileModels iData)
        {
            String base64Str = "";

            String filePath = Path.Combine(iData.location, iData.filename);
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                using (System.IO.FileStream fs = fi.OpenRead())
                {
                    if (fs.Length > 0)
                    {
                        using (var ms = new System.IO.MemoryStream())
                        {
                            fs.CopyTo(ms);
                            byte[] bytes = ms.ToArray();
                            base64Str = Convert.ToBase64String(bytes);
                        }
                    }
                }
            }

            return base64Str;
        }
    }
}
