using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class PositionModels : baseModels<PositionModels>
    {
        public int rn { get; set; }
        public string code { get; set; }
        public string desc_th { get; set; }
        public string desc_en { get; set; }
        public string shortCode { get; set; }
        public string levelCode { get; set; }
        public string create_date { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(PositionModels iProp)
        {
            String query = "up_position_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@shortCode", HelperConvert.ConvertToString(iProp.shortCode))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
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

        public void Update(PositionModels iProp)
        {
            String query = "up_position_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@shortCode", HelperConvert.ConvertToString(iProp.shortCode))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
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

        public void Delete(PositionModels iProp)
        {
            String query = "up_position_del";

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

        public List<PositionModels> DataList(PositionModels iProp)
        {
            String query = "up_position_sel";
            lData = new List<PositionModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new PositionModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 code = HelperConvert.ConvertToString(r.Field<object>("code")!)
                                 ,
                                 desc_th = HelperConvert.ConvertToString(r.Field<object>("desc_th")!)
                                 ,
                                 desc_en = HelperConvert.ConvertToString(r.Field<object>("desc_en")!)
                                 ,
                                 shortCode = HelperConvert.ConvertToString(r.Field<object>("shortCode")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
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
