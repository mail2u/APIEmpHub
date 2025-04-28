using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class MasterCodeModels : baseModels<MasterCodeModels>
    {
        public int id { get; set; }
        public string groupName { get; set; }
        public string code { get; set; }
        public string desc_th { get; set; }
        public string desc_en { get; set; }
        public string condition_1 { get; set; }
        public string condition_2 { get; set; }
        public string condition_3 { get; set; }
        public string condition_4 { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(MasterCodeModels iProp)
        {
            String query = "up_mastercode_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@groupName", HelperConvert.ConvertToString(iProp.groupName))
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@condition_1", HelperConvert.ConvertToString(iProp.condition_1))
                    , iSql.SqlCom_Parameter("@condition_2", HelperConvert.ConvertToString(iProp.condition_2))
                    , iSql.SqlCom_Parameter("@condition_3", HelperConvert.ConvertToString(iProp.condition_3))
                    , iSql.SqlCom_Parameter("@condition_4", HelperConvert.ConvertToString(iProp.condition_4))
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

        public void Update(MasterCodeModels iProp)
        {
            String query = "up_mastercode_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", iProp.id)
                    , iSql.SqlCom_Parameter("@groupName", HelperConvert.ConvertToString(iProp.groupName))
                    , iSql.SqlCom_Parameter("@code", HelperConvert.ConvertToString(iProp.code))
                    , iSql.SqlCom_Parameter("@desc_th", HelperConvert.ConvertToString(iProp.desc_th))
                    , iSql.SqlCom_Parameter("@desc_en", HelperConvert.ConvertToString(iProp.desc_en))
                    , iSql.SqlCom_Parameter("@condition_1", HelperConvert.ConvertToString(iProp.condition_1))
                    , iSql.SqlCom_Parameter("@condition_2", HelperConvert.ConvertToString(iProp.condition_2))
                    , iSql.SqlCom_Parameter("@condition_3", HelperConvert.ConvertToString(iProp.condition_3))
                    , iSql.SqlCom_Parameter("@condition_4", HelperConvert.ConvertToString(iProp.condition_4))
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

        public void Delete(MasterCodeModels iProp)
        {
            String query = "up_mastercode_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", iProp.id)
                    , iSql.SqlCom_Parameter("@groupName", HelperConvert.ConvertToString(iProp.groupName))
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

        public List<MasterCodeModels> DataList(MasterCodeModels iProp)
        {
            String query = "up_mastercode_sel";
            lData = new List<MasterCodeModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@groupName", HelperConvert.ConvertToString(iProp.groupName))
                    );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new MasterCodeModels
                             {
                                 id = HelperConvert.ConvertToInt(r.Field<object>("id")!)
                                 ,
                                 groupName = HelperConvert.ConvertToString(r.Field<object>("groupName")!)
                                 ,
                                 code = HelperConvert.ConvertToString(r.Field<object>("code")!)
                                 ,
                                 desc_th = HelperConvert.ConvertToString(r.Field<object>("desc_th")!)
                                 ,
                                 desc_en = HelperConvert.ConvertToString(r.Field<object>("desc_en")!)
                                 ,
                                 condition_1 = HelperConvert.ConvertToString(r.Field<object>("condition_1")!)
                                 ,
                                 condition_2 = HelperConvert.ConvertToString(r.Field<object>("condition_2")!)
                                 ,
                                 condition_3 = HelperConvert.ConvertToString(r.Field<object>("condition_3")!)
                                 ,
                                 condition_4 = HelperConvert.ConvertToString(r.Field<object>("condition_4")!)
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
