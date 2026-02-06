using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceStepModels : baseModels<ServiceStepModels>
    {
        public string refId { get; set; }
        public int stepIndex { get; set; }
        public string stepId { get; set; }
        public string status { get; set; }
        public string statusDesc { get; set; }
        public string actionBy { get; set; }
        public string actionName { get; set; }
        public string actionDate { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string description { get; set; }
        public int can_delete { get; set; }

        public int is_action { get; set; }
        public string userId { get; set; }
        public string update_by { get; set; }

        public List<ServiceStepModels> DataList(ServiceStepModels iProp)
        {
            String query = "up_service_step_sel";
            List<ServiceStepModels> lData = new List<ServiceStepModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceStepModels
                             {
                                 stepIndex = HelperConvert.ConvertToInt(r.Field<object>("stepIndex")!)
                                 ,
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
                                 ,
                                 actionBy = HelperConvert.ConvertToString(r.Field<object>("actionBy")!)
                                 ,
                                 actionName = HelperConvert.ConvertToString(r.Field<object>("actionName")!)
                                 ,
                                 actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 is_action = HelperConvert.ConvertToInt(r.Field<object>("is_action")!)
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

        public List<ServiceStepModels> ActionList(ServiceStepModels iProp)
        {
            String query = "up_service_step_action_sel";
            List<ServiceStepModels> lData = new List<ServiceStepModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceStepModels
                             {
                                 actionBy = HelperConvert.ConvertToString(r.Field<object>("actionBy")!)
                                 ,
                                 actionName = HelperConvert.ConvertToString(r.Field<object>("actionName")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
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

        public List<ServiceStepModels> WorkList(ServiceStepModels iProp)
        {
            String query = "up_service_step_work_sel";

            lData = new List<ServiceStepModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                );

                lData = (from r in dtData.AsEnumerable()
                         select new ServiceStepModels
                         {
                             stepIndex = HelperConvert.ConvertToInt(r.Field<object>("stepIndex")!)
                             ,
                             refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                             ,
                             stepId = HelperConvert.ConvertToString(r.Field<object>("stepId")!)
                             ,
                             actionBy = HelperConvert.ConvertToString(r.Field<object>("actionBy")!)
                             ,
                             actionName = HelperConvert.ConvertToString(r.Field<object>("actionName")!)
                             ,
                             actionDate = HelperConvert.ConvertToString(r.Field<object>("actionDate")!)
                             ,
                             position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                             ,
                             department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                             ,
                             can_delete = HelperConvert.ConvertToInt(r.Field<object>("can_delete")!)
                         }).ToList();
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

        public void WorkDelete(ServiceStepModels iProp)
        {
            String query = "up_service_step_work_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@stepId", HelperConvert.ConvertToString(iProp.stepId))
                    , iSql.SqlCom_Parameter("@stepIndex", iProp.stepIndex)
                    , iSql.SqlCom_Parameter("@actionBy", HelperConvert.ConvertToString(iProp.actionBy))
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
    }
}
