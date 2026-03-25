using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class FormModels : baseModels<FormModels>
    {
        #region FormNewCard
        public void FormNewCardCreate(FormNewCardModels iProp)
        {
            String query = "up_form_new_card_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@cause", HelperConvert.ConvertToString(iProp.cause))
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

        public FormNewCardModels FormNewCardDetail(FormNewCardModels iProp)
        {
            String query = "up_form_new_card_detail";
            FormNewCardModels iData = new FormNewCardModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormNewCardModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 cause = HelperConvert.ConvertToString(r.Field<object>("cause")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion

        #region FormParkingSticker
        public void FormParkingStickerCreate(FormParkingStickerModels iProp)
        {
            String query = "up_form_parking_sticker_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@cause", HelperConvert.ConvertToString(iProp.cause))
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

        public FormParkingStickerModels FormParkingStickerDetail(FormParkingStickerModels iProp)
        {
            String query = "up_form_parking_sticker_detail";
            FormParkingStickerModels iData = new FormParkingStickerModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormParkingStickerModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 cause = HelperConvert.ConvertToString(r.Field<object>("cause")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion

        #region FormBuyUniform
        public void FormBuyUniformCreate(FormBuyUniformModels iProp)
        {
            String query = "up_form_buy_uniform_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@style", HelperConvert.ConvertToString(iProp.style))
                    , iSql.SqlCom_Parameter("@quantity", iProp.quantity)
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

        public FormBuyUniformModels FormBuyUniformDetail(FormBuyUniformModels iProp)
        {
            String query = "up_form_buy_uniform_detail";
            FormBuyUniformModels iData = new FormBuyUniformModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormBuyUniformModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 style = HelperConvert.ConvertToString(r.Field<object>("style")!)
                                 ,
                                 quantity = HelperConvert.ConvertToInt(r.Field<object>("quantity")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion

        #region FormResetPassword
        public void FormResetPasswordCreate(FormResetPasswordModels iProp)
        {
            String query = "up_form_reset_password_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@system", HelperConvert.ConvertToString(iProp.system))
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

        public FormResetPasswordModels FormResetPasswordDetail(FormResetPasswordModels iProp)
        {
            String query = "up_form_reset_password_detail";
            FormResetPasswordModels iData = new FormResetPasswordModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormResetPasswordModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 system = HelperConvert.ConvertToString(r.Field<object>("system")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion

        #region FormSalaryCertificate
        public void FormSalaryCertificateCreate(FormSalaryCertificateModels iProp)
        {
            String query = "up_form_salary_certificate_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@lang_th", iProp.lang_th)
                    , iSql.SqlCom_Parameter("@lang_en", iProp.lang_en)
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

        public FormSalaryCertificateModels FormSalaryCertificateDetail(FormSalaryCertificateModels iProp)
        {
            String query = "up_form_salary_certificate_detail";
            FormSalaryCertificateModels iData = new FormSalaryCertificateModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormSalaryCertificateModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 lang_th = HelperConvert.ConvertToInt(r.Field<object>("lang_th")!)
                                 ,
                                 lang_en = HelperConvert.ConvertToInt(r.Field<object>("lang_en")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion
    }
}
