using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ChartModels : baseModels<ChartModels>
    {
        public string chartId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public int font_size { get; set; }
        public int font_bold { get; set; }
        public string sub_color { get; set; }
        public int sub_font_size { get; set; }
        public int sub_font_bold { get; set; }
        public string bg { get; set; }
        public string stroke { get; set; }
        public int stroke_width { get; set; } = 0;
        public string status { get; set; }
        public string create_by { get; set; }
        public string create_date { get; set; }
        public string update_by { get; set; }

        public void Create(ChartModels iProp)
        {
            String query = "up_chart_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@color", HelperConvert.ConvertToString(iProp.color))
                    , iSql.SqlCom_Parameter("@bg", HelperConvert.ConvertToString(iProp.bg))
                    , iSql.SqlCom_Parameter("@stroke", HelperConvert.ConvertToString(iProp.stroke))
                    , iSql.SqlCom_Parameter("@stroke_width", iProp.stroke_width)
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    , iSql.SqlCom_Parameter("@chartId", SqlDbType.NVarChar,50,ParameterDirection.Output)
                    );

                iProp.chartId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@chartId"].Value);
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

        public void Update(ChartModels iProp)
        {
            String query = "up_chart_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                    , iSql.SqlCom_Parameter("@title", HelperConvert.ConvertToString(iProp.title))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@color", HelperConvert.ConvertToString(iProp.color))
                    , iSql.SqlCom_Parameter("@font_size", iProp.font_size)
                    , iSql.SqlCom_Parameter("@font_bold", iProp.font_bold)
                    , iSql.SqlCom_Parameter("@sub_color", HelperConvert.ConvertToString(iProp.sub_color))
                    , iSql.SqlCom_Parameter("@sub_font_size", iProp.sub_font_size)
                    , iSql.SqlCom_Parameter("@sub_font_bold", iProp.sub_font_bold)
                    , iSql.SqlCom_Parameter("@bg", HelperConvert.ConvertToString(iProp.bg))
                    , iSql.SqlCom_Parameter("@stroke", HelperConvert.ConvertToString(iProp.stroke))
                    , iSql.SqlCom_Parameter("@stroke_width", iProp.stroke_width)
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
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

        public void Delete(ChartModels iProp)
        {
            String query = "up_chart_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
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

        public List<ChartModels> DataList(ChartModels iProp)
        {
            String query = "up_chart_sel";
            lData = new List<ChartModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new ChartModels
                             {
                                 chartId = HelperConvert.ConvertToString(r.Field<object>("chartId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 color = HelperConvert.ConvertToString(r.Field<object>("color")!)
                                 ,
                                 bg = HelperConvert.ConvertToString(r.Field<object>("bg")!)
                                 ,
                                 stroke = HelperConvert.ConvertToString(r.Field<object>("stroke")!)
                                 ,
                                 stroke_width = HelperConvert.ConvertToInt(r.Field<object>("stroke_width")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
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

        public ChartModels Detail(ChartModels iProp)
        {
            String query = "up_chart_detail";
            iData = new ChartModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@chartId", HelperConvert.ConvertToString(iProp.chartId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new ChartModels
                             {
                                 chartId = HelperConvert.ConvertToString(r.Field<object>("chartId")!)
                                 ,
                                 title = HelperConvert.ConvertToString(r.Field<object>("title")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 color = HelperConvert.ConvertToString(r.Field<object>("color")!)
                                 ,
                                 font_size = HelperConvert.ConvertToInt(r.Field<object>("font_size")!)
                                 ,
                                 font_bold = HelperConvert.ConvertToInt(r.Field<object>("font_bold")!)
                                 ,
                                 sub_color = HelperConvert.ConvertToString(r.Field<object>("sub_color")!)
                                 ,
                                 sub_font_size = HelperConvert.ConvertToInt(r.Field<object>("sub_font_size")!)
                                 ,
                                 sub_font_bold = HelperConvert.ConvertToInt(r.Field<object>("sub_font_bold")!)
                                 ,
                                 bg = HelperConvert.ConvertToString(r.Field<object>("bg")!)
                                 ,
                                 stroke = HelperConvert.ConvertToString(r.Field<object>("stroke")!)
                                 ,
                                 stroke_width = HelperConvert.ConvertToInt(r.Field<object>("stroke_width")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             }).FirstOrDefault()!;
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

            return iData;
        }
    }
}
