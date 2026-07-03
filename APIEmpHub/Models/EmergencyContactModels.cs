using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class EmergencyContactModels : baseModels<EmergencyContactModels>
    {
        public string id { get; set; }
        public string refId { get; set; }
        public string fullname { get; set; }
        public string relation { get; set; }
        public string phoneNo { get; set; }
        public string address { get; set; }
        public string create_by { get; set; }
        public void Create(EmergencyContactModels iProp)
        {
            String query = "up_emergency_contact_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@id", HelperConvert.ConvertToString(iProp.id))
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@relation", HelperConvert.ConvertToString(iProp.relation))
                    , iSql.SqlCom_Parameter("@phoneNo", HelperConvert.ConvertToString(iProp.phoneNo))
                    , iSql.SqlCom_Parameter("@address", HelperConvert.ConvertToString(iProp.address))
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

        public List<EmergencyContactModels> DataList(EmergencyContactModels iProp)
        {
            String query = "up_emergency_contact_sel";
            lData = new List<EmergencyContactModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    lData = (from r in dtData.AsEnumerable()
                             select new EmergencyContactModels
                             {
                                 id = HelperConvert.ConvertToString(r.Field<object>("id")!)
                                 ,
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 relation = HelperConvert.ConvertToString(r.Field<object>("relation")!)
                                 ,
                                 phoneNo = HelperConvert.ConvertToString(r.Field<object>("phoneNo")!)
                                 ,
                                 address = HelperConvert.ConvertToString(r.Field<object>("address")!)
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
