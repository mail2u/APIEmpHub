using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceEducationModels : baseModels<ServiceEducationModels>
    {
        public string refId { get; set; }
        public string educationId { get; set; }
        public string mode { get; set; }
        public string levelCode { get; set; }
        public string levelName { get; set; }
        public string institution { get; set; }
        public int year { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Save(ServiceEducationModels iProp)
        {
            String query = "up_service_education_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@educationId", HelperConvert.ConvertToString(iProp.educationId))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
                    , iSql.SqlCom_Parameter("@levelName", HelperConvert.ConvertToString(iProp.levelName))
                    , iSql.SqlCom_Parameter("@institution", HelperConvert.ConvertToString(iProp.institution))
                    , iSql.SqlCom_Parameter("@year", iProp.year)
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

        public void Clone(ServiceEducationModels iProp)
        {
            String query = "up_service_education_clone";

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

        public void Cancel(ServiceEducationModels iProp)
        {
            String query = "up_service_education_cancel";

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

        public void Delete(ServiceEducationModels iProp)
        {
            String query = "up_service_education_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@educationId", HelperConvert.ConvertToString(iProp.educationId))
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

        public List<ServiceEducationModels> DataList(ServiceEducationModels iProp)
        {
            String query = "up_service_education_sel";
            lData = new List<ServiceEducationModels>();

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
                             select new ServiceEducationModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 educationId = HelperConvert.ConvertToString(r.Field<object>("educationId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 levelName = HelperConvert.ConvertToString(r.Field<object>("levelName")!)
                                 ,
                                 institution = HelperConvert.ConvertToString(r.Field<object>("institution")!)
                                 ,
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
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

        public List<ServiceEducationModels> DataListByRef(ServiceEducationModels iProp)
        {
            String query = "up_service_education_sel_by_ref";
            lData = new List<ServiceEducationModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceEducationModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 educationId = HelperConvert.ConvertToString(r.Field<object>("educationId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 levelName = HelperConvert.ConvertToString(r.Field<object>("levelName")!)
                                 ,
                                 institution = HelperConvert.ConvertToString(r.Field<object>("institution")!)
                                 ,
                                 year = HelperConvert.ConvertToInt(r.Field<object>("year")!)
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
