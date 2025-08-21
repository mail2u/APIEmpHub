using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class DashboardModels : baseModels<DashboardModels>
    {
        public DataSet DataList()
        {
            String query = "up_dashboard_sel";

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
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
    }
}
