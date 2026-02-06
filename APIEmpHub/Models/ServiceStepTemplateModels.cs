using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceStepTemplateModels : baseModels<ServiceStepTemplateModels>
    {
        public string stepId { get; set; }
        public string cateId { get; set; }
        public int stepIndex { get; set; }
        public string status { get; set; }
        public string statusDesc { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Create(ServiceStepTemplateModels iProp)
        {
            String query = "up_service_step_template_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@statusDesc", HelperConvert.ConvertToString(iProp.statusDesc))
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

        public void Update(ServiceStepTemplateModels iProp)
        {
            String query = "up_service_step_template_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@stepId", HelperConvert.ConvertToString(iProp.stepId))
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@statusDesc", HelperConvert.ConvertToString(iProp.statusDesc))
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

        public void Sort(ServiceStepTemplateModels iProp)
        {
            String query = "up_service_step_template_sort";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@stepId ", HelperConvert.ConvertToString(iProp.stepId))
                    , iSql.SqlCom_Parameter("@stepIndex", iProp.stepIndex)
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

        public void Delete(ServiceStepTemplateModels iProp)
        {
            String query = "up_service_step_template_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
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

        public List<ServiceStepTemplateModels> DataList(ServiceStepTemplateModels iProp)
        {
            String query = "up_service_step_template_sel";
            List<ServiceStepTemplateModels> lData = new List<ServiceStepTemplateModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@cateId", HelperConvert.ConvertToString(iProp.cateId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceStepTemplateModels
                             {
                                 stepId = HelperConvert.ConvertToString(r.Field<object>("stepId")!)
                                 ,
                                 cateId = HelperConvert.ConvertToString(r.Field<object>("cateId")!)
                                 ,
                                 stepIndex = HelperConvert.ConvertToInt(r.Field<object>("stepIndex")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 statusDesc = HelperConvert.ConvertToString(r.Field<object>("statusDesc")!)
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
