using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class SubCategoryModels : baseModels<SubCategoryModels>
    {
        public string parentId { get; set; }
        public string subCateId { get; set; }
        public string subCategoryCode { get; set; }
        public string subCategoryDesc { get; set; }
        public string description { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string userId { get; set; }
        public int allow_every { get; set; }
        public int order_index { get; set; }
        public decimal min_amount { get; set; }
        public decimal max_amount { get; set; }
        public List<SubCategoryModels> lChildCate { get; set; }

        public void Create(SubCategoryModels iProp)
        {
            String query = "up_sub_category_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
                    , iSql.SqlCom_Parameter("@subCategoryCode", HelperConvert.ConvertToString(iProp.subCategoryCode))
                    , iSql.SqlCom_Parameter("@subCategoryDesc", HelperConvert.ConvertToString(iProp.subCategoryDesc))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@allow_every", iProp.allow_every)
                    , iSql.SqlCom_Parameter("@min_amount", iProp.min_amount)
                    , iSql.SqlCom_Parameter("@max_amount", iProp.max_amount)
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

        public void Update(SubCategoryModels iProp)
        {
            String query = "up_sub_category_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@subCateId", HelperConvert.ConvertToString(iProp.subCateId))
                    , iSql.SqlCom_Parameter("@subCategoryCode", HelperConvert.ConvertToString(iProp.subCategoryCode))
                    , iSql.SqlCom_Parameter("@subCategoryDesc", HelperConvert.ConvertToString(iProp.subCategoryDesc))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@allow_every", iProp.allow_every)
                    , iSql.SqlCom_Parameter("@min_amount", iProp.min_amount)
                    , iSql.SqlCom_Parameter("@max_amount", iProp.max_amount)
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

        public void Sort(SubCategoryModels iProp)
        {
            String query = "up_sub_category_sort";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@subCateId", HelperConvert.ConvertToString(iProp.subCateId))
                    , iSql.SqlCom_Parameter("@order_index", iProp.order_index)
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

        public void Delete(SubCategoryModels iProp)
        {
            String query = "up_sub_category_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@subCateId", HelperConvert.ConvertToString(iProp.subCateId))
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

        public List<SubCategoryModels> DataList(SubCategoryModels iProp)
        {
            String query = "up_sub_category_sel";
            lData = new List<SubCategoryModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new SubCategoryModels
                             {
                                 parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                 ,
                                 subCateId = HelperConvert.ConvertToString(r.Field<object>("subCateId")!)
                                 ,
                                 subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                                 ,
                                 subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                 ,
                                 min_amount = HelperConvert.ConvertToDecimal(r.Field<object>("min_amount")!)
                                 ,
                                 max_amount = HelperConvert.ConvertToDecimal(r.Field<object>("max_amount")!)
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


        public List<SubCategoryModels> AuthenList(SubCategoryModels iProp)
        {
            String query = "up_sub_category_sel_by_authen";
            lData = new List<SubCategoryModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new SubCategoryModels
                             {
                                 parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                 ,
                                 subCateId = HelperConvert.ConvertToString(r.Field<object>("subCateId")!)
                                 ,
                                 subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                                 ,
                                 subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 min_amount = HelperConvert.ConvertToDecimal(r.Field<object>("min_amount")!)
                                 ,
                                 max_amount = HelperConvert.ConvertToDecimal(r.Field<object>("max_amount")!)
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
