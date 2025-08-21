using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceTraningModels : baseModels<ServiceTraningModels>
    {
        public string refId { get; set; }
        public string traningId { get; set; }
        public string mode { get; set; }
        public string license { get; set; }
        public string organization { get; set; }
        public string issueDate { get; set; }
        public string expireDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Save(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@traningId", HelperConvert.ConvertToString(iProp.traningId))
                    , iSql.SqlCom_Parameter("@license", HelperConvert.ConvertToString(iProp.license))
                    , iSql.SqlCom_Parameter("@organization", HelperConvert.ConvertToString(iProp.organization))
                    , iSql.SqlCom_Parameter("@issueDate", HelperConvert.ConvertToDate112(iProp.issueDate))
                    , iSql.SqlCom_Parameter("@expireDate", HelperConvert.ConvertToDate112(iProp.expireDate))
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

        public void Clone(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_clone";

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

        public void Cancel(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_cancel";

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

        public void Delete(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@traningId", HelperConvert.ConvertToString(iProp.traningId))
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

        public List<ServiceTraningModels> DataList(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_sel";
            lData = new List<ServiceTraningModels>();

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
                             select new ServiceTraningModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 traningId = HelperConvert.ConvertToString(r.Field<object>("traningId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 issueDate = HelperConvert.ConvertToString(r.Field<object>("issueDate")!)
                                 ,
                                 expireDate = HelperConvert.ConvertToString(r.Field<object>("expireDate")!)
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

        public List<ServiceTraningModels> DataListByRef(ServiceTraningModels iProp)
        {
            String query = "up_service_traning_sel_by_ref";
            lData = new List<ServiceTraningModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceTraningModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 traningId = HelperConvert.ConvertToString(r.Field<object>("traningId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 issueDate = HelperConvert.ConvertToString(r.Field<object>("issueDate")!)
                                 ,
                                 expireDate = HelperConvert.ConvertToString(r.Field<object>("expireDate")!)
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
