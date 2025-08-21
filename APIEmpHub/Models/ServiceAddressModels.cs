using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceAddressModels : baseModels<ServiceAddressModels>
    {
        public string refId { get; set; }
        public string addressId { get; set; }
        public string mode { get; set; }
        public string home { get; set; }
        public string road { get; set; }
        public string subDistrictCode { get; set; }
        public string subDistrictName { get; set; }
        public string districtCode { get; set; }
        public string districtName { get; set; }
        public string provinceCode { get; set; }
        public string provinceName { get; set; }
        public string postcode { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }

        public void Save(ServiceAddressModels iProp)
        {
            String query = "up_service_address_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@home", HelperConvert.ConvertToString(iProp.home))
                    , iSql.SqlCom_Parameter("@road", HelperConvert.ConvertToString(iProp.road))
                    , iSql.SqlCom_Parameter("@subDistrictCode", HelperConvert.ConvertToString(iProp.subDistrictCode))
                    , iSql.SqlCom_Parameter("@subDistrictName", HelperConvert.ConvertToString(iProp.subDistrictName))
                    , iSql.SqlCom_Parameter("@districtCode", HelperConvert.ConvertToString(iProp.districtCode))
                    , iSql.SqlCom_Parameter("@districtName", HelperConvert.ConvertToString(iProp.districtName))
                    , iSql.SqlCom_Parameter("@provinceCode", HelperConvert.ConvertToString(iProp.provinceCode))
                    , iSql.SqlCom_Parameter("@provinceName", HelperConvert.ConvertToString(iProp.provinceName))
                    , iSql.SqlCom_Parameter("@postcode", HelperConvert.ConvertToString(iProp.postcode))
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

        public void Cancel(ServiceAddressModels iProp)
        {
            String query = "up_service_address_cancel";

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

        public ServiceAddressModels Detail(ServiceAddressModels iProp)
        {
            String query = "up_service_address_detail";
            iData = new ServiceAddressModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServiceAddressModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 addressId = HelperConvert.ConvertToString(r.Field<object>("addressId")!)
                                 ,
                                 home = HelperConvert.ConvertToString(r.Field<object>("home")!)
                                 ,
                                 road = HelperConvert.ConvertToString(r.Field<object>("road")!)
                                 ,
                                 subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("subDistrictCode")!)
                                 ,
                                 subDistrictName = HelperConvert.ConvertToString(r.Field<object>("subDistrictName")!)
                                 ,
                                 districtCode = HelperConvert.ConvertToString(r.Field<object>("districtCode")!)
                                 ,
                                 districtName = HelperConvert.ConvertToString(r.Field<object>("districtName")!)
                                 ,
                                 provinceCode = HelperConvert.ConvertToString(r.Field<object>("provinceCode")!)
                                 ,
                                 provinceName = HelperConvert.ConvertToString(r.Field<object>("provinceName")!)
                                 ,
                                 postcode = HelperConvert.ConvertToString(r.Field<object>("postcode")!)
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

        public List<ServiceAddressModels> DetailByRef(ServiceAddressModels iProp)
        {
            String query = "up_service_address_detail_by_ref";
            lData = new List<ServiceAddressModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new ServiceAddressModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 addressId = HelperConvert.ConvertToString(r.Field<object>("addressId")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 home = HelperConvert.ConvertToString(r.Field<object>("home")!)
                                 ,
                                 road = HelperConvert.ConvertToString(r.Field<object>("road")!)
                                 ,
                                 subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("subDistrictCode")!)
                                 ,
                                 subDistrictName = HelperConvert.ConvertToString(r.Field<object>("subDistrictName")!)
                                 ,
                                 districtCode = HelperConvert.ConvertToString(r.Field<object>("districtCode")!)
                                 ,
                                 districtName = HelperConvert.ConvertToString(r.Field<object>("districtName")!)
                                 ,
                                 provinceCode = HelperConvert.ConvertToString(r.Field<object>("provinceCode")!)
                                 ,
                                 provinceName = HelperConvert.ConvertToString(r.Field<object>("provinceName")!)
                                 ,
                                 postcode = HelperConvert.ConvertToString(r.Field<object>("postcode")!)
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
