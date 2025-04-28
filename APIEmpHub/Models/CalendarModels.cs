using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class CalendarModels : baseModels<CalendarModels>
    {
        public int rn { get; set; }
        public string refId { get; set; }
        public string type { get; set; }
        public string dt { get; set; }
        public string time_start { get; set; }
        public string time_end { get; set; }
        public string note { get; set; }
        public int day_of_week { get; set; }
        public int week_of_year { get; set; }
        public int day { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int is_now { get; set; }
        public string eventName { get; set; }
        public string status { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string userBy { get; set; }

        public List<EventModels> lEvent { get; set; }

        public void Create(CalendarModels iProp)
        {
            String query = "up_calendar_ins";
            lData = new List<CalendarModels>();

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@dt", HelperConvert.ConvertToDate112(iProp.dt))
                , iSql.SqlCom_Parameter("@time_start", HelperConvert.ConvertToString(iProp.time_start))
                , iSql.SqlCom_Parameter("@time_end", HelperConvert.ConvertToString(iProp.time_end))
                , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                , iSql.SqlCom_Parameter("@type", HelperConvert.ConvertToString(iProp.type))
                , iSql.SqlCom_Parameter("@note", HelperConvert.ConvertToString(iProp.note))
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

        public void Update(CalendarModels iProp)
        {
            String query = "up_calendar_upd";
            lData = new List<CalendarModels>();

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@rn", iProp.rn)
                , iSql.SqlCom_Parameter("@dt", HelperConvert.ConvertToDate112(iProp.dt))
                , iSql.SqlCom_Parameter("@time_start", HelperConvert.ConvertToString(iProp.time_start))
                , iSql.SqlCom_Parameter("@time_end", HelperConvert.ConvertToString(iProp.time_end))
                , iSql.SqlCom_Parameter("@type", HelperConvert.ConvertToString(iProp.type))
                , iSql.SqlCom_Parameter("@note", HelperConvert.ConvertToString(iProp.note))
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

        public void Delete(CalendarModels iProp)
        {
            String query = "up_calendar_del";
            lData = new List<CalendarModels>();

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@refId", iProp.refId)
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

        public List<CalendarModels> EventList(CalendarModels iProp)
        {

            String query = "up_calendar_sel_by_date";
            lData = new List<CalendarModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@dt", HelperConvert.ConvertToDate103(iProp.dt))
                );

                if (dsData != null)
                {
                    lData = (from r in dsData.Tables[0].AsEnumerable()
                             select new CalendarModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 dt = HelperConvert.ConvertToString(r.Field<object>("dt")!)
                                 ,
                                 time_start = HelperConvert.ConvertToString(r.Field<object>("time_start")!)
                                 ,
                                 time_end = HelperConvert.ConvertToString(r.Field<object>("time_end")!)
                                 ,
                                 type = HelperConvert.ConvertToString(r.Field<object>("type")!)
                                 ,
                                 note = HelperConvert.ConvertToString(r.Field<object>("note")!)
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

        public List<CalendarModels> DataList(CalendarModels iProp)
        {

            String query = "up_calendar_sel";
            lData = new List<CalendarModels>();

            try
            {
                iSql.Open(connectionString);
                dsData = iSql.SqlCom_DataAdapterWithDataSet(query, CommandType.StoredProcedure
                , iSql.SqlCom_Parameter("@year", iProp.year)
                , iSql.SqlCom_Parameter("@month", iProp.month)
                , iSql.SqlCom_Parameter("@userBy", HelperConvert.ConvertToString(iProp.userBy))
                );

                if (dsData != null)
                {
                    lData = (from r in dsData.Tables[0].AsEnumerable()
                             select new CalendarModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 dt = HelperConvert.ConvertToString(r.Field<object>("dt")!)
                                 ,
                                 day_of_week = HelperConvert.ConvertToInt(r.Field<object>("day_of_week")!)
                                 ,
                                 week_of_year = HelperConvert.ConvertToInt(r.Field<object>("week_of_year")!)
                                 ,
                                 day = HelperConvert.ConvertToInt(r.Field<object>("day")!)
                                 ,
                                 month = HelperConvert.ConvertToInt(r.Field<object>("month")!)
                                 ,
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
                                 ,
                                 is_now = HelperConvert.ConvertToInt(r.Field<object>("is_now")!)
                             }).ToList();

                    List<EventModels> lEvent = (from r in dsData.Tables[1].AsEnumerable()
                                                select new EventModels
                                                {
                                                    dt = HelperConvert.ConvertToString(r.Field<object>("dt")!)
                                                    ,
                                                    time_start = HelperConvert.ConvertToString(r.Field<object>("time_start")!)
                                                    ,
                                                    time_end = HelperConvert.ConvertToString(r.Field<object>("time_end")!)
                                                    ,
                                                    eventId = HelperConvert.ConvertToString(r.Field<object>("eventId")!)
                                                    ,
                                                    eventType = HelperConvert.ConvertToString(r.Field<object>("eventType")!)
                                                    ,
                                                    eventName = HelperConvert.ConvertToString(r.Field<object>("eventName")!)
                                                    ,
                                                    status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                                }).ToList();

                    lData = lData.Select(x =>
                    {
                        x.lEvent = lEvent.Where(e => e.dt == x.dt).ToList();
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
