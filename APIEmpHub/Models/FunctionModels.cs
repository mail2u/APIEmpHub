using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class FunctionModels : baseModels<FunctionModels>
    {
        public string funcId { get; set; }
        public string funcCode { get; set; }
        public string title { get; set; }
        public string detail { get; set; }

        public List<FunctionModels> DataList(FunctionModels iProp)
        {
            String query = "up_function_sel";
            List<FunctionModels> lData = new List<FunctionModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new FunctionModels
                             {
                                 funcId = HelperConvert.ConvertToString(r.Field<object>("funcId")!)
                                 ,
                                 funcCode = HelperConvert.ConvertToString(r.Field<object>("funcCode")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
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
