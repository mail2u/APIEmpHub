using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class ServicePersonalModels : baseModels<ServicePersonalModels>
    {
        public string refId { get; set; }
        public string personalId { get; set; }
        public string mode { get; set; }
        public string prefix_th { get; set; }
        public string prefix_th_desc { get; set; }
        public string firstname_th { get; set; }
        public string lastname_th { get; set; }
        public string prefix_en { get; set; }
        public string prefix_en_desc { get; set; }
        public string firstname_en { get; set; }
        public string lastname_en { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string sex_desc { get; set; }
        public string birth_date { get; set; }
        public string age { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string blood { get; set; }
        public string idcard { get; set; }
        public string passport { get; set; }
        public string workPermitNo { get; set; }
        public string bankName { get; set; }
        public string bookNo { get; set; }
        public string maritalStatus { get; set; }
        public string maritalStatusDesc { get; set; }
        public string militaryStatus { get; set; }
        public string militaryStatusDesc { get; set; }
        public string disabilityStatus { get; set; }
        public string disabilityStatusDesc { get; set; }
        public string email { get; set; }
        public string phoneNo { get; set; }
        public string mobile { get; set; }
        public string nationality { get; set; }
        public string nationalityDesc { get; set; }
        public string ethnicity { get; set; }
        public string ethnicityDesc { get; set; }
        public string religion { get; set; }
        public string religionDesc { get; set; }
        public string status { get; set; }
        public string userId { get; set; }
        public string create_by { get; set; }
        public string update_by { get; set; }
        public string update_date { get; set; }

        public void Save(ServicePersonalModels iProp)
        {
            String query = "up_service_personal_save";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@prefix_th", HelperConvert.ConvertToString(iProp.prefix_th))
                    , iSql.SqlCom_Parameter("@firstname_th", HelperConvert.ConvertToString(iProp.firstname_th))
                    , iSql.SqlCom_Parameter("@lastname_th", HelperConvert.ConvertToString(iProp.lastname_th))
                    , iSql.SqlCom_Parameter("@prefix_en", HelperConvert.ConvertToString(iProp.prefix_en))
                    , iSql.SqlCom_Parameter("@firstname_en", HelperConvert.ConvertToString(iProp.firstname_en))
                    , iSql.SqlCom_Parameter("@lastname_en", HelperConvert.ConvertToString(iProp.lastname_en))
                    , iSql.SqlCom_Parameter("@nickname", HelperConvert.ConvertToString(iProp.nickname))
                    , iSql.SqlCom_Parameter("@sex", HelperConvert.ConvertToString(iProp.sex))
                    , iSql.SqlCom_Parameter("@birth_date", HelperConvert.ConvertToString(iProp.birth_date))
                    , iSql.SqlCom_Parameter("@age", HelperConvert.ConvertToString(iProp.age))
                    , iSql.SqlCom_Parameter("@maritalStatus", HelperConvert.ConvertToString(iProp.maritalStatus))
                    , iSql.SqlCom_Parameter("@militaryStatus", HelperConvert.ConvertToString(iProp.militaryStatus))
                    , iSql.SqlCom_Parameter("@disabilityStatus", HelperConvert.ConvertToString(iProp.disabilityStatus))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@phoneNo", HelperConvert.ConvertToString(iProp.phoneNo))
                    , iSql.SqlCom_Parameter("@mobile", HelperConvert.ConvertToString(iProp.mobile))
                    , iSql.SqlCom_Parameter("@nationality", HelperConvert.ConvertToString(iProp.nationality))
                    , iSql.SqlCom_Parameter("@ethnicity", HelperConvert.ConvertToString(iProp.ethnicity))
                    , iSql.SqlCom_Parameter("@religion", HelperConvert.ConvertToString(iProp.religion))
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

        public ServicePersonalModels Detail(ServicePersonalModels iProp)
        {
            String query = "up_service_personal_detail";
            iData = new ServicePersonalModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {

                    iData = (from r in dtData.AsEnumerable()
                             select new ServicePersonalModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 personalId = HelperConvert.ConvertToString(r.Field<object>("personalId")!)
                                 ,
                                 prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
                                 ,
                                 prefix_th_desc = HelperConvert.ConvertToString(r.Field<object>("prefix_th_desc")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 prefix_en = HelperConvert.ConvertToString(r.Field<object>("prefix_en")!)
                                 ,
                                 prefix_en_desc = HelperConvert.ConvertToString(r.Field<object>("prefix_en_desc")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 nickname = HelperConvert.ConvertToString(r.Field<object>("nickname")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 sex_desc = HelperConvert.ConvertToString(r.Field<object>("sex_desc")!)
                                 ,
                                 birth_date = HelperConvert.ConvertToString(r.Field<object>("birth_date")!)
                                 ,
                                 age = HelperConvert.ConvertToString(r.Field<object>("age")!)
                                 ,
                                 maritalStatus = HelperConvert.ConvertToString(r.Field<object>("maritalStatus")!)
                                 ,
                                 militaryStatus = HelperConvert.ConvertToString(r.Field<object>("militaryStatus")!)
                                 ,
                                 disabilityStatus = HelperConvert.ConvertToString(r.Field<object>("disabilityStatus")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 phoneNo = HelperConvert.ConvertToString(r.Field<object>("phoneNo")!)
                                 ,
                                 mobile = HelperConvert.ConvertToString(r.Field<object>("mobile")!)
                                 ,
                                 nationality = HelperConvert.ConvertToString(r.Field<object>("nationality")!)
                                 ,
                                 ethnicity = HelperConvert.ConvertToString(r.Field<object>("ethnicity")!)
                                 ,
                                 religion = HelperConvert.ConvertToString(r.Field<object>("religion")!)
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
