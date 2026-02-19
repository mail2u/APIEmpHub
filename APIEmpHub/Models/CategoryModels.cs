using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class CategoryModels : baseModels<CategoryModels>
    {
        public string sysId { get; set; }
        public string cateId { get; set; }
        public string categoryCode { get; set; }
        public string categoryDesc { get; set; }
        public string subCateId { get; set; }
        public string subCategoryCode { get; set; }
        public string subCategoryDesc { get; set; }
        public string description { get; set; }
        public int allow_every { get; set; }
        public int order_index { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public List<SubCategoryModels> lSubCate { get; set; }

        public void Create(CategoryModels iProp)
        {
            String query = "up_category_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@categoryCode", HelperConvert.ConvertToString(iProp.categoryCode))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@allow_every", iProp.allow_every)
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

        public void Update(CategoryModels iProp)
        {
            String query = "up_category_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
                    , iSql.SqlCom_Parameter("@categoryCode", HelperConvert.ConvertToString(iProp.categoryCode))
                    , iSql.SqlCom_Parameter("@categoryDesc", HelperConvert.ConvertToString(iProp.categoryDesc))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@allow_every", iProp.allow_every)
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

        public void Sort(CategoryModels iProp)
        {
            String query = "up_category_sort";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
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

        public void Delete(CategoryModels iProp)
        {
            String query = "up_category_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
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

        public List<CategoryModels> DataList(CategoryModels iProp)
        {
            String query = "up_category_sel";
            lData = new List<CategoryModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new CategoryModels
                             {
                                 sysId = HelperConvert.ConvertToString(r.Field<object>("sysId")!)
                                 ,
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                                 ,
                                 categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
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

        public List<CateInRoleModels> AllList(CateInRoleModels iProp)
        {
            String query = "up_category_all";
            List<CateInRoleModels> lData = new List<CateInRoleModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                );

                if (dsData != null && dsData.Tables.Count > 0)
                {
                    lData = (from r in dsData.Tables[0].AsEnumerable()
                             select new CateInRoleModels
                             {
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                 ,
                                 cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                             }).ToList();

                    List<CateInRoleModels> lSubCate = (from r in dsData.Tables[1].AsEnumerable()
                                                       select new CateInRoleModels
                                                       {
                                                           parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                           ,
                                                           cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                           ,
                                                           cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                                           ,
                                                           cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                                           ,
                                                           description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                                           ,
                                                           allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                                           ,
                                                           order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                                       }).ToList();

                    List<CateInRoleModels> lChildCate = (from r in dsData.Tables[2].AsEnumerable()
                                                         select new CateInRoleModels
                                                         {
                                                             parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                             ,
                                                             cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                             ,
                                                             cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                                             ,
                                                             cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
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

                    lSubCate = lSubCate.Select(x =>
                    {
                        x.lSub = lChildCate.Where(c => c.parentId == x.cateId).ToList();

                        return x;
                    }).ToList();

                    lData = lData.Select(x =>
                    {
                        x.lSub = lSubCate.Where(s => s.parentId == x.cateId).ToList();

                        return x;
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


        public List<CateInRoleModels> AuthenList(CategoryModels iProp)
        {
            String query = "up_category_sel_by_authen";
            List<CateInRoleModels>  lData = new List<CateInRoleModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                if (dsData != null && dsData.Tables.Count > 0)
                {
                    lData = (from r in dsData.Tables[0].AsEnumerable()
                             select new CateInRoleModels
                             {
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                 ,
                                 cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                             }).ToList();

                    List<CateInRoleModels> lSubCate = (from r in dsData.Tables[1].AsEnumerable()
                                                       select new CateInRoleModels
                                                       {
                                                           parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                           ,
                                                           cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                           ,
                                                           cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                                           ,
                                                           cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                                           ,
                                                           description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                                           ,
                                                           allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                                           ,
                                                           order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                                       }).ToList();

                    List<CateInRoleModels> lChildCate = (from r in dsData.Tables[2].AsEnumerable()
                                                         select new CateInRoleModels
                                                         {
                                                             parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                             ,
                                                             cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                             ,
                                                             cateCode = HelperConvert.ConvertToString(r.Field<object>("cateCode")!)
                                                             ,
                                                             cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
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

                    lSubCate = lSubCate.Select(x =>
                    {
                        x.lSub = lChildCate.Where(c => c.parentId == x.cateId).ToList();

                        return x;
                    }).ToList();

                    lData = lData.Select(x =>
                    {
                        x.lSub = lSubCate.Where(s => s.parentId == x.cateId).ToList();

                        return x;
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


        public DataTable Report(CategoryModels iProp)
        {
            String query = "up_category_report_sel";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
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

            return dtData;
        }

        public DataTable ReportProcess(CategoryModels iProp)
        {
            String query = "up_category_process_report_sel";

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
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

            return dtData;
        }

        public List<CategoryModels> CategoryByCode(CategoryModels iProp)
        {
            String query = "up_category_sel_by_code";
            lData = new List<CategoryModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@subCategoryCode", HelperConvert.ConvertToString(iProp.subCategoryCode))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new CategoryModels
                             {
                                 sysId = HelperConvert.ConvertToString(r.Field<object>("sysId")!)
                                 ,
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 categoryCode = HelperConvert.ConvertToString(r.Field<object>("categoryCode")!)
                                 ,
                                 categoryDesc = HelperConvert.ConvertToString(r.Field<object>("categoryDesc")!)
                                 ,
                                 subCateId = HelperConvert.ConvertToString(r.Field<object>("subCateId")!)
                                 ,
                                 subCategoryCode = HelperConvert.ConvertToString(r.Field<object>("subCategoryCode")!)
                                 ,
                                 subCategoryDesc = HelperConvert.ConvertToString(r.Field<object>("subCategoryDesc")!)
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
