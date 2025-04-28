using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class AddressModels : baseModels<AddressModels>
    {
        public string subDistrictCode { get; set; }
        public string subDistrictName { get; set; }
        public string districtCode { get; set; }
        public string districtName { get; set; }
        public string provinceCode { get; set; }
        public string provinceName { get; set; }
        public string postcode { get; set; }

        public List<AddressModels> DataList()
        {
            String query = "up_address_sel";
            List<AddressModels>  lData = new List<AddressModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new AddressModels
                             {
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
