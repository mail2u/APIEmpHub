using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class CateInRoleModels : baseModels<CateInRoleModels>
    {
        public string sysId { get; set; }
        public string roleId { get; set; }
        public string parentId { get; set; }
        public string cateId { get; set; }
        public string cateDesc { get; set; }
        public string description { get; set; }
        public int is_authen { get; set; }
        public int allow_every { get; set; }
        public int allow_pr_po { get; set; }
        public int allow_pr_non_po { get; set; }
        public int allow_pr_non_po_adv { get; set; }
        public int order_index { get; set; }
        public decimal min_amount { get; set; }
        public decimal max_amount { get; set; }

        public string create_by { get; set; }
        public string update_by { get; set; }

        public List<CateInRoleModels> lSub { get; set; }

        public void Create(CateInRoleModels iProp)
        {
            String query = "up_cate_in_role_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
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

        public void Delete(CateInRoleModels iProp)
        {
            String query = "up_cate_in_role_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
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

        public List<CateInRoleModels> AllList(CateInRoleModels iProp)
        {
            String query = "up_cate_in_role_all";
            lData = new List<CateInRoleModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@sysId", HelperConvert.ConvertToString(iProp.sysId))
                    , iSql.SqlCom_Parameter("@roleId", HelperConvert.ConvertToString(iProp.roleId))
                );

                if (dsData != null && dsData.Tables.Count > 0)
                {
                    lData = (from r in dsData.Tables[0].AsEnumerable()
                             select new CateInRoleModels
                             {
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                 ,
                                 order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                 ,
                                 is_authen = HelperConvert.ConvertToInt(r.Field<object>("is_authen")!)
                             }).ToList();

                    List<CateInRoleModels> lSubCate = (from r in dsData.Tables[1].AsEnumerable()
                                                       select new CateInRoleModels
                                                       {
                                                           parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                           ,
                                                           cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                           ,
                                                           cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                                           ,
                                                           description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                                           ,
                                                           allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                                           ,
                                                           order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                                           ,
                                                           is_authen = HelperConvert.ConvertToInt(r.Field<object>("is_authen")!)
                                                       }).ToList();

                    List<CateInRoleModels> lChildCate = (from r in dsData.Tables[2].AsEnumerable()
                                                        select new CateInRoleModels
                                                        {
                                                            parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                                            ,
                                                            cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                                            ,
                                                            cateDesc = HelperConvert.ConvertToString(r.Field<object>("cateDesc")!)
                                                            ,
                                                            description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                                            ,
                                                            allow_every = HelperConvert.ConvertToInt(r.Field<object>("allow_every")!)
                                                            ,
                                                            order_index = HelperConvert.ConvertToInt(r.Field<object>("order_index")!)
                                                            ,
                                                            is_authen = HelperConvert.ConvertToInt(r.Field<object>("is_authen")!)
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


    }
}
