using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceJobExperienceModels : baseModels<ServiceJobExperienceModels>
    {
        public string refId { get; set; }
        public string jobId { get; set; }
        public string company { get; set; }
        public string position { get; set; }
        public string fromDate { get; set; }
        public string endDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Save(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@jobId", HelperConvert.ConvertToString(iProp.jobId))
                    , iSql.SqlCom_Parameter("@company", HelperConvert.ConvertToString(iProp.company))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@fromDate", HelperConvert.ConvertToDate112(iProp.fromDate))
                    , iSql.SqlCom_Parameter("@endDate", HelperConvert.ConvertToDate112(iProp.endDate))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
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

        public void Clone(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_clone";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

        public void Cancel(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_cancel";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

        public void Delete(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@jobId", HelperConvert.ConvertToString(iProp.jobId))
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

        public List<ServiceJobExperienceModels> DataList(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_sel";
            lData = new List<ServiceJobExperienceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceJobExperienceModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 jobId = HelperConvert.ConvertToString(r.Field<object>("jobId")!)
                                 ,
                                 company = HelperConvert.ConvertToString(r.Field<object>("company")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 fromDate = HelperConvert.ConvertToString(r.Field<object>("fromDate")!)
                                 ,
                                 endDate = HelperConvert.ConvertToString(r.Field<object>("endDate")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             }).ToList()!;
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

        public List<ServiceJobExperienceModels> DataListByRef(ServiceJobExperienceModels iProp)
        {
            String query = "up_service_job_experience_sel_by_ref";
            lData = new List<ServiceJobExperienceModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceJobExperienceModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 jobId = HelperConvert.ConvertToString(r.Field<object>("jobId")!)
                                 ,
                                 company = HelperConvert.ConvertToString(r.Field<object>("company")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 fromDate = HelperConvert.ConvertToString(r.Field<object>("fromDate")!)
                                 ,
                                 endDate = HelperConvert.ConvertToString(r.Field<object>("endDate")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                             }).ToList()!;
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
