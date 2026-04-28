using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServiceAddressModels : baseModels<ServiceAddressModels>
    {
        public string refId { get; set; } = "";
        public string addressId { get; set; } = "";
        public string mode { get; set; } = "";
        public string registered_home { get; set; } = "";
        public string registered_road { get; set; } = "";
        public string registered_subDistrictCode { get; set; } = "";
        public string registered_subDistrictName { get; set; } = "";
        public string registered_districtCode { get; set; } = "";
        public string registered_districtName { get; set; } = "";
        public string registered_provinceCode { get; set; } = "";
        public string registered_provinceName { get; set; } = "";
        public string registered_postcode { get; set; } = "";
        public string card_home { get; set; } = "";
        public string card_road { get; set; } = "";
        public string card_subDistrictCode { get; set; } = "";
        public string card_subDistrictName { get; set; } = "";
        public string card_districtCode { get; set; } = "";
        public string card_districtName { get; set; } = "";
        public string card_provinceCode { get; set; } = "";
        public string card_provinceName { get; set; } = "";
        public string card_postcode { get; set; } = "";
        public string live_home { get; set; } = "";
        public string live_road { get; set; } = "";
        public string live_subDistrictCode { get; set; } = "";
        public string live_subDistrictName { get; set; } = "";
        public string live_districtCode { get; set; } = "";
        public string live_districtName { get; set; } = "";
        public string live_provinceCode { get; set; } = "";
        public string live_provinceName { get; set; } = "";
        public string live_postcode { get; set; } = "";
        public string status { get; set; } = "";
        public string userId { get; set; } = "";
        public string create_by { get; set; } = "";
        public string update_by { get; set; } = "";
        public string update_date { get; set; }

        public void Save(ServiceAddressModels iProp)
        {
            String query = "up_service_address_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@registered_home", HelperConvert.ConvertToString(iProp.registered_home))
                    , iSql.SqlCom_Parameter("@registered_road", HelperConvert.ConvertToString(iProp.registered_road))
                    , iSql.SqlCom_Parameter("@registered_subDistrictCode", HelperConvert.ConvertToString(iProp.registered_subDistrictCode))
                    , iSql.SqlCom_Parameter("@registered_subDistrictName", HelperConvert.ConvertToString(iProp.registered_subDistrictName))
                    , iSql.SqlCom_Parameter("@registered_districtCode", HelperConvert.ConvertToString(iProp.registered_districtCode))
                    , iSql.SqlCom_Parameter("@registered_districtName", HelperConvert.ConvertToString(iProp.registered_districtName))
                    , iSql.SqlCom_Parameter("@registered_provinceCode", HelperConvert.ConvertToString(iProp.registered_provinceCode))
                    , iSql.SqlCom_Parameter("@registered_provinceName", HelperConvert.ConvertToString(iProp.registered_provinceName))
                    , iSql.SqlCom_Parameter("@registered_postcode", HelperConvert.ConvertToString(iProp.registered_postcode))

                    , iSql.SqlCom_Parameter("@card_home", HelperConvert.ConvertToString(iProp.card_home))
                    , iSql.SqlCom_Parameter("@card_road", HelperConvert.ConvertToString(iProp.card_road))
                    , iSql.SqlCom_Parameter("@card_subDistrictCode", HelperConvert.ConvertToString(iProp.card_subDistrictCode))
                    , iSql.SqlCom_Parameter("@card_subDistrictName", HelperConvert.ConvertToString(iProp.card_subDistrictName))
                    , iSql.SqlCom_Parameter("@card_districtCode", HelperConvert.ConvertToString(iProp.card_districtCode))
                    , iSql.SqlCom_Parameter("@card_districtName", HelperConvert.ConvertToString(iProp.card_districtName))
                    , iSql.SqlCom_Parameter("@card_provinceCode", HelperConvert.ConvertToString(iProp.card_provinceCode))
                    , iSql.SqlCom_Parameter("@card_provinceName", HelperConvert.ConvertToString(iProp.card_provinceName))
                    , iSql.SqlCom_Parameter("@card_postcode", HelperConvert.ConvertToString(iProp.card_postcode))

                    , iSql.SqlCom_Parameter("@live_home", HelperConvert.ConvertToString(iProp.live_home))
                    , iSql.SqlCom_Parameter("@live_road", HelperConvert.ConvertToString(iProp.live_road))
                    , iSql.SqlCom_Parameter("@live_subDistrictCode", HelperConvert.ConvertToString(iProp.live_subDistrictCode))
                    , iSql.SqlCom_Parameter("@live_subDistrictName", HelperConvert.ConvertToString(iProp.live_subDistrictName))
                    , iSql.SqlCom_Parameter("@live_districtCode", HelperConvert.ConvertToString(iProp.live_districtCode))
                    , iSql.SqlCom_Parameter("@live_districtName", HelperConvert.ConvertToString(iProp.live_districtName))
                    , iSql.SqlCom_Parameter("@live_provinceCode", HelperConvert.ConvertToString(iProp.live_provinceCode))
                    , iSql.SqlCom_Parameter("@live_provinceName", HelperConvert.ConvertToString(iProp.live_provinceName))
                    , iSql.SqlCom_Parameter("@live_postcode", HelperConvert.ConvertToString(iProp.live_postcode))
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

        public ServiceAddressModels Detail(ServiceAddressModels iProp)
        {
            String query = "up_service_address_detail";
            iData = new ServiceAddressModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
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
                                 registered_home = HelperConvert.ConvertToString(r.Field<object>("registered_home")!)
                                 ,
                                 registered_road = HelperConvert.ConvertToString(r.Field<object>("registered_road")!)
                                 ,
                                 registered_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("registered_subDistrictCode")!)
                                 ,
                                 registered_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("registered_subDistrictName")!)
                                 ,
                                 registered_districtCode = HelperConvert.ConvertToString(r.Field<object>("registered_districtCode")!)
                                 ,
                                 registered_districtName = HelperConvert.ConvertToString(r.Field<object>("registered_districtName")!)
                                 ,
                                 registered_provinceCode = HelperConvert.ConvertToString(r.Field<object>("registered_provinceCode")!)
                                 ,
                                 registered_provinceName = HelperConvert.ConvertToString(r.Field<object>("registered_provinceName")!)
                                 ,
                                 registered_postcode = HelperConvert.ConvertToString(r.Field<object>("registered_postcode")!)

                                 ,
                                 card_home = HelperConvert.ConvertToString(r.Field<object>("card_home")!)
                                 ,
                                 card_road = HelperConvert.ConvertToString(r.Field<object>("card_road")!)
                                 ,
                                 card_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("card_subDistrictCode")!)
                                 ,
                                 card_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("card_subDistrictName")!)
                                 ,
                                 card_districtCode = HelperConvert.ConvertToString(r.Field<object>("card_districtCode")!)
                                 ,
                                 card_districtName = HelperConvert.ConvertToString(r.Field<object>("card_districtName")!)
                                 ,
                                 card_provinceCode = HelperConvert.ConvertToString(r.Field<object>("card_provinceCode")!)
                                 ,
                                 card_provinceName = HelperConvert.ConvertToString(r.Field<object>("card_provinceName")!)
                                 ,
                                 card_postcode = HelperConvert.ConvertToString(r.Field<object>("card_postcode")!)

                                 ,
                                 live_home = HelperConvert.ConvertToString(r.Field<object>("live_home")!)
                                 ,
                                 live_road = HelperConvert.ConvertToString(r.Field<object>("live_road")!)
                                 ,
                                 live_subDistrictCode = HelperConvert.ConvertToString(r.Field<object>("live_subDistrictCode")!)
                                 ,
                                 live_subDistrictName = HelperConvert.ConvertToString(r.Field<object>("live_subDistrictName")!)
                                 ,
                                 live_districtCode = HelperConvert.ConvertToString(r.Field<object>("live_districtCode")!)
                                 ,
                                 live_districtName = HelperConvert.ConvertToString(r.Field<object>("live_districtName")!)
                                 ,
                                 live_provinceCode = HelperConvert.ConvertToString(r.Field<object>("live_provinceCode")!)
                                 ,
                                 live_provinceName = HelperConvert.ConvertToString(r.Field<object>("live_provinceName")!)
                                 ,
                                 live_postcode = HelperConvert.ConvertToString(r.Field<object>("live_postcode")!)
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
