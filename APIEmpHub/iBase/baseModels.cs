using APIEmpHub.Models;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.iBase
{
    public class baseModels<TModel>
    {
        #region Prop
        public string connectionString;
        public string webRoot;
        public DataTable dtData;
        public DataSet dsData;
        public TModel iData;
        public List<TModel> lData;
        public HelperSql iSql;
        public ConnectionModels connection;
        public int row { get; set; }
        public int page { get; set; }
        public int total { get; set; }
        public int can_view { get; set; }
        public int can_edit { get; set; }
        public string sortBy { get; set; }
        public string orderDate1 { get; set; }
        public string orderDate2 { get; set; }
        #endregion

        public baseModels()
        {
            iSql = new HelperSql();
        }

        #region Method
        public virtual DataTable Select(TModel iProp) { return null; }
        public virtual List<TModel> ConvertToList(DataTable dtData) { return null; }
        //public virtual Boolean Update(TModel iProp) { return false; }
        //public virtual Boolean UpdateAll(List<TModel> lProp) { return false; }
        //public virtual Boolean Delete(TModel iProp) { return false; }
        #endregion
    }
}
