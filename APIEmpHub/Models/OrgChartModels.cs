using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class OrgChartModels : baseModels<OrgChartModels>
    {
        public string chartId { get; set; }
        public string mode { get; set; }
        public string id { get; set; }
        public string parentId { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string type { get; set; }
        public int levelOffset { get; set; }
        public int pos_x { get; set; }
        public int pos_y { get; set; }
        public int pos_w { get; set; }
        public int pos_h { get; set; }
        public int is_lock { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        //public void Create(OrgChartModels iProp)
        //{
        //    String query = "up_orgchart_ins";

        //    try
        //    {
        //        iSql.Open(connectionString);
        //        iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
        //            , iSql.SqlCom_Parameter("@id", SqlDbType.NVarChar, 50, ParameterDirection.Output)
        //            , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
        //            , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
        //            , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
        //            , iSql.SqlCom_Parameter("@name", HelperConvert.ConvertToString(iProp.name))
        //            , iSql.SqlCom_Parameter("@levelOffset", iProp.levelOffset)
        //            , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
        //            );

        //        iProp.id = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@id"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        iSql.Close();
        //    }
        //}

        //public void Update(OrgChartModels iProp)
        //{
        //    String query = "up_orgchart_upd";

        //    try
        //    {
        //        iSql.Open(connectionString);
        //        iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
        //            , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
        //            , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
        //            , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
        //            , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
        //            , iSql.SqlCom_Parameter("@name", HelperConvert.ConvertToString(iProp.name))
        //            , iSql.SqlCom_Parameter("@levelOffset", iProp.levelOffset)
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        iSql.Close();
        //    }
        //}

        public void UpdatePosition(OrgChartModels iProp)
        {
            String query = "up_orgchart_upd_position";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@pos_x", iProp.pos_x)
                    , iSql.SqlCom_Parameter("@pos_y", iProp.pos_y)
                    , iSql.SqlCom_Parameter("@pos_w", iProp.pos_w)
                    , iSql.SqlCom_Parameter("@pos_h", iProp.pos_h)
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

        public void UpdateParent(OrgChartModels iProp)
        {
            String query = "up_orgchart_upd_parent";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@parentId", HelperConvert.ConvertToString(iProp.parentId))
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


        //public void Delete(OrgChartModels iProp)
        //{
        //    String query = "up_orgchart_del";

        //    try
        //    {
        //        iSql.Open(connectionString);
        //        iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
        //            , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
        //            , iSql.SqlCom_Parameter("@update_by", HelperConvert.ConvertToString(iProp.update_by))
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        iSql.Close();
        //    }
        //}

        public void Lock(OrgChartModels iProp)
        {
            String query = "up_orgchart_upd_lock";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@is_lock", iProp.is_lock)
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

        public List<OrgChartModels> DataList(OrgChartModels iProp)
        {
            String query = "up_orgchart_sel";
            lData = new List<OrgChartModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new OrgChartModels
                             {
                                 chartId = HelperConvert.ConvertToString(r.Field<object>("chartId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 name = HelperConvert.ConvertToString(r.Field<object>("name")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 type = HelperConvert.ConvertToString(r.Field<object>("type")!)
                                 ,
                                 levelOffset = HelperConvert.ConvertToInt(r.Field<object>("levelOffset")!)
                                 ,
                                 pos_x = HelperConvert.ConvertToInt(r.Field<object>("pos_x")!)
                                 ,
                                 pos_y = HelperConvert.ConvertToInt(r.Field<object>("pos_y")!)
                                 ,
                                 pos_w = HelperConvert.ConvertToInt(r.Field<object>("pos_w")!)
                                 ,
                                 pos_h = HelperConvert.ConvertToInt(r.Field<object>("pos_h")!)
                                 ,
                                 is_lock = HelperConvert.ConvertToInt(r.Field<object>("is_lock")!)
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


        //public List<OrgChartModels> Company(OrgChartModels iProp)
        //{
        //    String query = "up_orgchart_company_sel";
        //    lData = new List<OrgChartModels>();

        //    try
        //    {
        //        iSql.Open(connectionString);
        //        dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
        //            , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
        //        );

        //        if (dtData != null && dtData.Rows.Count > 0)
        //        {

        //            lData = (from r in dtData.AsEnumerable()
        //                     select new OrgChartModels
        //                     {
        //                         id = HelperConvert.ConvertToString(r.Field<object>("id")!)
        //                         ,
        //                         parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
        //                         ,
        //                         title = HelperConvert.ConvertToString(r.Field<object>("title")!)
        //                         ,
        //                         name = HelperConvert.ConvertToString(r.Field<object>("name")!)
        //                         ,
        //                         levelOffset = HelperConvert.ConvertToInt(r.Field<object>("levelOffset")!)
        //                         ,
        //                         pos_x = HelperConvert.ConvertToInt(r.Field<object>("pos_x")!)
        //                         ,
        //                         pos_y = HelperConvert.ConvertToInt(r.Field<object>("pos_y")!)
        //                     }).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }
        //    finally
        //    {
        //        iSql.Close();
        //    }

        //    return lData;
        //}


        public List<OrgChartModels> Team(OrgChartModels iProp)
        {
            String query = "up_orgchart_team_sel";
            lData = new List<OrgChartModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new OrgChartModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 parentId = HelperConvert.ConvertToString(r.Field<object>("parentId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 name = HelperConvert.ConvertToString(r.Field<object>("name")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 type = HelperConvert.ConvertToString(r.Field<object>("type")!)
                                 ,
                                 levelOffset = HelperConvert.ConvertToInt(r.Field<object>("levelOffset")!)
                                 ,
                                 pos_x = HelperConvert.ConvertToInt(r.Field<object>("pos_x")!)
                                 ,
                                 pos_y = HelperConvert.ConvertToInt(r.Field<object>("pos_y")!)
                                 ,
                                 pos_w = HelperConvert.ConvertToInt(r.Field<object>("pos_w")!)
                                 ,
                                 pos_h = HelperConvert.ConvertToInt(r.Field<object>("pos_h")!)
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
