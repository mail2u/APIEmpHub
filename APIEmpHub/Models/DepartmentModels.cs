using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class DepartmentModels : baseModels<DepartmentModels>
    {
        public int rn { get; set; }
        public string parentCode { get; set; }
        public string code { get; set; }
        public string desc_th { get; set; }
        public string desc_en { get; set; }
        public string groupCode { get; set; }
        public string buCode { get; set; }
        public string create_date { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(DepartmentModels iProp)
        {
            String query = "up_department_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@parentCode", HelperConvert.ConvertToString(iProp.parentCode))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@groupCode", HelperConvert.ConvertToString(iProp.groupCode))
                    , iSql.SqlCom_Parameter("@buCode", HelperConvert.ConvertToString(iProp.buCode))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
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

        public void Update(DepartmentModels iProp)
        {
            String query = "up_department_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@parentCode", HelperConvert.ConvertToString(iProp.parentCode))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@groupCode", HelperConvert.ConvertToString(iProp.groupCode))
                    , iSql.SqlCom_Parameter("@buCode", HelperConvert.ConvertToString(iProp.buCode))
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

        public void Delete(DepartmentModels iProp)
        {
            String query = "up_department_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
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

        public void SetParent(DepartmentModels iProp)
        {
            String query = "up_department_set_parent";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
                    , iSql.SqlCom_Parameter("@parentCode", HelperConvert.ConvertToString(iProp.parentCode))
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

        public List<DepartmentModels> DataList(DepartmentModels iProp)
        {
            String query = "up_department_sel";
            lData = new List<DepartmentModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new DepartmentModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 parentCode = HelperConvert.ConvertToString(r.Field<object>("parentCode")!)
                                 ,
                                 code = HelperConvert.ConvertToString(r.Field<object>("code")!)
                                 ,
                                 desc_th = HelperConvert.ConvertToString(r.Field<object>("desc_th")!)
                                 ,
                                 desc_en = HelperConvert.ConvertToString(r.Field<object>("desc_en")!)
                                 ,
                                 groupCode = HelperConvert.ConvertToString(r.Field<object>("groupCode")!)
                                 ,
                                 buCode = HelperConvert.ConvertToString(r.Field<object>("buCode")!)
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
