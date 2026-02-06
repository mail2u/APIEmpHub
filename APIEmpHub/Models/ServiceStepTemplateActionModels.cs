using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceStepTemplateActionModels : baseModels<ServiceStepTemplateActionModels>
    {
        public int rn { get; set; }
        public string stepId { get; set; }
        public string actionBy { get; set; }
        public string actionName { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(ServiceStepTemplateActionModels iProp)
        {
            String query = "up_service_step_template_action_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@stepId", HelperConvert.ConvertToString(iProp.stepId))
                    , iSql.SqlCom_Parameter("@actionBy", HelperConvert.ConvertToString(iProp.actionBy))
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

        public void Delete(ServiceStepTemplateActionModels iProp)
        {
            String query = "up_service_step_template_action_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@rn", iProp.rn)
                    , iSql.SqlCom_Parameter("@stepId", HelperConvert.ConvertToString(iProp.stepId))
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

        public List<ServiceStepTemplateActionModels> DataList(ServiceStepTemplateActionModels iProp)
        {
            String query = "up_service_step_template_action_sel";
            List<ServiceStepTemplateActionModels> lData = new List<ServiceStepTemplateActionModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@stepId", HelperConvert.ConvertToString(iProp.stepId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceStepTemplateActionModels
                             {
                                 rn = HelperConvert.ConvertToInt(r.Field<object>("rn")!)
                                 ,
                                 stepId = HelperConvert.ConvertToString(r.Field<object>("stepId")!)
                                 ,
                                 actionBy = HelperConvert.ConvertToString(r.Field<object>("actionBy")!)
                                 ,
                                 actionName = HelperConvert.ConvertToString(r.Field<object>("actionName")!)
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
