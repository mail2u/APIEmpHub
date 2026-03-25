using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;
using System.Xml.Linq;

namespace APIEmpHub.Models
{
    public class OfferModels : baseModels<OfferModels>
    {
        public string candidateId { get; set; }
        public string offerId { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public decimal offeredSalary { get; set; } = 0;
        public string status { get; set; }
        public string create_by { get; set; }
        public string create_date { get; set; }
        public string update_by { get; set; }

        public void Create(OfferModels iProp)
        {
            String query = "up_offer_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@candidateId", HelperConvert.ConvertToString(iProp.candidateId))
                    , iSql.SqlCom_Parameter("@offeredSalary", iProp.offeredSalary)
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    , iSql.SqlCom_Parameter("@offerId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    );

                iProp.offerId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@offerId"].Value);
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

        public void Update(OfferModels iProp)
        {
            String query = "up_offer_upd";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@offerId", HelperConvert.ConvertToString(iProp.offerId))
                    , iSql.SqlCom_Parameter("@offeredSalary", iProp.offeredSalary)
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
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

        public void Delete(OfferModels iProp)
        {
            String query = "up_offer_del";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@offerId", HelperConvert.ConvertToString(iProp.offerId))
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

        public List<OfferModels> DataList(OfferModels iProp)
        {
            String query = "up_offer_sel";
            lData = new List<OfferModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@firstname", HelperConvert.ConvertToString(iProp.firstname))
                    , iSql.SqlCom_Parameter("@lastname", HelperConvert.ConvertToString(iProp.lastname))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@sortBy", HelperConvert.ConvertToString(iProp.sortBy))
                    , iSql.SqlCom_Parameter("@page", iProp.page)
                    , iSql.SqlCom_Parameter("@row", iProp.row)
                    , iSql.SqlCom_Parameter("@status", HelperConvert.ConvertToString(iProp.status))
                    , iSql.SqlCom_Parameter("@total", SqlDbType.Int, ParameterDirection.Output)
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new OfferModels
                             {
                                 candidateId = HelperConvert.ConvertToString(r.Field<object>("candidateId")!)
                                 ,
                                 firstname = HelperConvert.ConvertToString(r.Field<object>("firstname")!)
                                 ,
                                 lastname = HelperConvert.ConvertToString(r.Field<object>("lastname")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 offeredSalary = HelperConvert.ConvertToDecimal(r.Field<object>("offeredSalary")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
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

        public OfferModels Detail(OfferModels iProp)
        {
            String query = "up_offer_detail";
            iData = new OfferModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@offerId", HelperConvert.ConvertToString(iProp.offerId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new OfferModels
                             {
                                 candidateId = HelperConvert.ConvertToString(r.Field<object>("candidateId")!)
                                 ,
                                 firstname = HelperConvert.ConvertToString(r.Field<object>("firstname")!)
                                 ,
                                 lastname = HelperConvert.ConvertToString(r.Field<object>("lastname")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 offeredSalary = HelperConvert.ConvertToDecimal(r.Field<object>("offeredSalary")!)
                                 ,
                                 status = HelperConvert.ConvertToString(r.Field<object>("status")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
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
