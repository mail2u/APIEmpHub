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

        #region FormEmployeeCertificate
        public void FormEmployeeCertificateCreate(FormEmployeeCertificateModels iProp)
        {
            String query = "up_form_employee_certificate_ins";

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

        public FormEmployeeCertificateModels FormEmployeeCertificateDetail(FormEmployeeCertificateModels iProp)
        {
            String query = "up_form_employee_certificate_detail";
            FormEmployeeCertificateModels iData = new FormEmployeeCertificateModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormEmployeeCertificateModels
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

        #region FormRequestTraining
        public void FormRequestTrainingCreate(FormRequestTrainingModels iProp)
        {
            String query = "up_form_request_training_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@license", HelperConvert.ConvertToString(iProp.license))
                    , iSql.SqlCom_Parameter("@objectives", HelperConvert.ConvertToString(iProp.objectives))
                    , iSql.SqlCom_Parameter("@organization", HelperConvert.ConvertToString(iProp.organization))
                    , iSql.SqlCom_Parameter("@location", HelperConvert.ConvertToString(iProp.location))
                    , iSql.SqlCom_Parameter("@dt", HelperConvert.ConvertToString(iProp.dt))
                    , iSql.SqlCom_Parameter("@price", iProp.price)
                    , iSql.SqlCom_Parameter("@net", iProp.net)
                    , iSql.SqlCom_Parameter("@option1", iProp.option1)
                    , iSql.SqlCom_Parameter("@option2", iProp.option2)
                    , iSql.SqlCom_Parameter("@option3", iProp.option3)
                    , iSql.SqlCom_Parameter("@option4", iProp.option4)
                    , iSql.SqlCom_Parameter("@option4_desc", HelperConvert.ConvertToString(iProp.option4_desc))
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

        public FormRequestTrainingModels FormRequestTrainingDetail(FormRequestTrainingModels iProp)
        {
            String query = "up_form_request_training_detail";
            FormRequestTrainingModels iData = new FormRequestTrainingModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormRequestTrainingModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 objectives = HelperConvert.ConvertToString(r.Field<object>("objectives")!)
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 location = HelperConvert.ConvertToString(r.Field<object>("location")!)
                                 ,
                                 dt = HelperConvert.ConvertToString(r.Field<object>("dt")!)
                                 ,
                                 price = HelperConvert.ConvertToDecimal(r.Field<object>("price")!)
                                 ,
                                 net = HelperConvert.ConvertToDecimal(r.Field<object>("net")!)
                                 ,
                                 option1 = HelperConvert.ConvertToInt(r.Field<object>("option1")!)
                                 ,
                                 option2 = HelperConvert.ConvertToInt(r.Field<object>("option2")!)
                                 ,
                                 option3 = HelperConvert.ConvertToInt(r.Field<object>("option3")!)
                                 ,
                                 option4 = HelperConvert.ConvertToInt(r.Field<object>("option4")!)
                                 ,
                                 option4_desc = HelperConvert.ConvertToString(r.Field<object>("option4_desc")!)
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

        #region FormManpower
        public void FormManpowerCreate(FormManpowerModels iProp)
        {
            String query = "up_form_manpower_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@required_date", HelperConvert.ConvertToString(iProp.required_date))
                    , iSql.SqlCom_Parameter("@num_employee", iProp.num_employee)
                    , iSql.SqlCom_Parameter("@type_employment", HelperConvert.ConvertToString(iProp.type_employment))
                    , iSql.SqlCom_Parameter("@type_employment_desc", HelperConvert.ConvertToString(iProp.type_employment_desc))
                    , iSql.SqlCom_Parameter("@type_requirement", HelperConvert.ConvertToString(iProp.type_requirement))
                    , iSql.SqlCom_Parameter("@type_reason", HelperConvert.ConvertToString(iProp.type_reason))
                    , iSql.SqlCom_Parameter("@type_reason_additional_hire_desc", HelperConvert.ConvertToString(iProp.type_reason_additional_hire_desc))
                    , iSql.SqlCom_Parameter("@type_reason_replacement_desc", HelperConvert.ConvertToString(iProp.type_reason_replacement_desc))
                    , iSql.SqlCom_Parameter("@description_work", HelperConvert.ConvertToString(iProp.description_work))
                    , iSql.SqlCom_Parameter("@sex", HelperConvert.ConvertToString(iProp.sex))
                    , iSql.SqlCom_Parameter("@age", iProp.age)
                    , iSql.SqlCom_Parameter("@education", HelperConvert.ConvertToString(iProp.education))
                    , iSql.SqlCom_Parameter("@major", HelperConvert.ConvertToString(iProp.major))
                    , iSql.SqlCom_Parameter("@knowledge", HelperConvert.ConvertToString(iProp.knowledge))
                    , iSql.SqlCom_Parameter("@skill_language", iProp.skill_language)
                    , iSql.SqlCom_Parameter("@skill_language_desc", HelperConvert.ConvertToString(iProp.skill_language_desc))
                    , iSql.SqlCom_Parameter("@skill_computer", iProp.skill_computer)
                    , iSql.SqlCom_Parameter("@skill_computer_desc", HelperConvert.ConvertToString(iProp.skill_computer_desc))
                    , iSql.SqlCom_Parameter("@skill_other", iProp.skill_other)
                    , iSql.SqlCom_Parameter("@skill_other_desc", HelperConvert.ConvertToString(iProp.skill_other_desc))
                    , iSql.SqlCom_Parameter("@type_experience", HelperConvert.ConvertToString(iProp.type_experience))
                    , iSql.SqlCom_Parameter("@type_experience_yes_desc", HelperConvert.ConvertToString(iProp.type_experience_yes_desc))
                    , iSql.SqlCom_Parameter("@type_experience_other_desc", HelperConvert.ConvertToString(iProp.type_experience_other_desc))
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

        public FormManpowerModels FormManpowerDetail(FormManpowerModels iProp)
        {
            String query = "up_form_manpower_detail";
            FormManpowerModels iData = new FormManpowerModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormManpowerModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 required_date = HelperConvert.ConvertToString(r.Field<object>("required_date")!)
                                 ,
                                 num_employee = HelperConvert.ConvertToInt(r.Field<object>("num_employee")!)
                                 ,
                                 type_employment = HelperConvert.ConvertToString(r.Field<object>("type_employment")!)
                                 ,
                                 type_employment_desc = HelperConvert.ConvertToString(r.Field<object>("type_employment_desc")!)
                                 ,
                                 type_requirement = HelperConvert.ConvertToString(r.Field<object>("type_requirement")!)
                                 ,
                                 type_reason = HelperConvert.ConvertToString(r.Field<object>("type_reason")!)
                                 ,
                                 type_reason_additional_hire_desc = HelperConvert.ConvertToString(r.Field<object>("type_reason_additional_hire_desc")!)
                                 ,
                                 type_reason_replacement_desc = HelperConvert.ConvertToString(r.Field<object>("type_reason_replacement_desc")!)
                                 ,
                                 description_work = HelperConvert.ConvertToString(r.Field<object>("description_work")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 age = HelperConvert.ConvertToInt(r.Field<object>("age")!)
                                 ,
                                 education = HelperConvert.ConvertToString(r.Field<object>("education")!)
                                 ,
                                 major = HelperConvert.ConvertToString(r.Field<object>("major")!)
                                 ,
                                 knowledge = HelperConvert.ConvertToString(r.Field<object>("knowledge")!)
                                 ,
                                 skill_language = HelperConvert.ConvertToInt(r.Field<object>("skill_language")!)
                                 ,
                                 skill_language_desc = HelperConvert.ConvertToString(r.Field<object>("skill_language_desc")!)
                                 ,
                                 skill_computer = HelperConvert.ConvertToInt(r.Field<object>("skill_computer")!)
                                 ,
                                 skill_computer_desc = HelperConvert.ConvertToString(r.Field<object>("skill_computer_desc")!)
                                 ,
                                 skill_other = HelperConvert.ConvertToInt(r.Field<object>("skill_other")!)
                                 ,
                                 skill_other_desc = HelperConvert.ConvertToString(r.Field<object>("skill_other_desc")!)
                                 ,
                                 type_experience = HelperConvert.ConvertToString(r.Field<object>("type_experience")!)
                                 ,
                                 type_experience_yes_desc = HelperConvert.ConvertToString(r.Field<object>("type_experience_yes_desc")!)
                                 ,
                                 type_experience_other_desc = HelperConvert.ConvertToString(r.Field<object>("type_experience_other_desc")!)
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

        #region FormBenefitFund
        public void FormBenefitFundCreate(FormBenefitFundModels iProp)
        {
            String query = "up_form_benefit_fund_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@idcard", HelperConvert.ConvertToString(iProp.idcard))
                    , iSql.SqlCom_Parameter("@mode", HelperConvert.ConvertToString(iProp.mode))
                    , iSql.SqlCom_Parameter("@total", iProp.total)
                    , iSql.SqlCom_Parameter("@benefitname1", HelperConvert.ConvertToString(iProp.benefitname1))
                    , iSql.SqlCom_Parameter("@benefitrelation1", HelperConvert.ConvertToString(iProp.benefitrelation1))
                    , iSql.SqlCom_Parameter("@benefitpercent1", iProp.benefitpercent1)
                    , iSql.SqlCom_Parameter("@benefitname2", HelperConvert.ConvertToString(iProp.benefitname2))
                    , iSql.SqlCom_Parameter("@benefitrelation2", HelperConvert.ConvertToString(iProp.benefitrelation2))
                    , iSql.SqlCom_Parameter("@benefitpercent2", iProp.benefitpercent2)
                    , iSql.SqlCom_Parameter("@benefitname3", HelperConvert.ConvertToString(iProp.benefitname3))
                    , iSql.SqlCom_Parameter("@benefitrelation3", HelperConvert.ConvertToString(iProp.benefitrelation3))
                    , iSql.SqlCom_Parameter("@benefitpercent3", iProp.benefitpercent3)
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

        public FormBenefitFundModels FormBenefitFundDetail(FormBenefitFundModels iProp)
        {
            String query = "up_form_benefit_fund_detail";
            FormBenefitFundModels iData = new FormBenefitFundModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormBenefitFundModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 idcard = HelperConvert.ConvertToString(r.Field<object>("idcard")!)
                                 ,
                                 mode = HelperConvert.ConvertToString(r.Field<object>("mode")!)
                                 ,
                                 total = HelperConvert.ConvertToInt(r.Field<object>("total")!)
                                 ,
                                 benefitname1 = HelperConvert.ConvertToString(r.Field<object>("benefitname1")!)
                                 ,
                                 benefitrelation1 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation1")!)
                                 ,
                                 benefitpercent1 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent1")!)
                                 ,
                                 benefitname2 = HelperConvert.ConvertToString(r.Field<object>("benefitname2")!)
                                 ,
                                 benefitrelation2 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation2")!)
                                 ,
                                 benefitpercent2 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent2")!)
                                 ,
                                 benefitname3 = HelperConvert.ConvertToString(r.Field<object>("benefitname3")!)
                                 ,
                                 benefitrelation3 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation3")!)
                                 ,
                                 benefitpercent3 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent3")!)
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
        #endregion\

        #region FormBenefitInsurance
        public void FormBenefitInsuranceCreate(FormBenefitInsuranceModels iProp)
        {
            String query = "up_form_benefit_insurance_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@policyNo", HelperConvert.ConvertToString(iProp.policyNo))
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@birth_date", HelperConvert.ConvertToDate112(iProp.birth_date))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@benefitname1", HelperConvert.ConvertToString(iProp.benefitname1))
                    , iSql.SqlCom_Parameter("@benefitage1", iProp.benefitage1)
                    , iSql.SqlCom_Parameter("@benefitrelation1", HelperConvert.ConvertToString(iProp.benefitrelation1))
                    , iSql.SqlCom_Parameter("@benefitpercent1", iProp.benefitpercent1)
                    , iSql.SqlCom_Parameter("@benefitname2", HelperConvert.ConvertToString(iProp.benefitname2))
                    , iSql.SqlCom_Parameter("@benefitage2", iProp.benefitage2)
                    , iSql.SqlCom_Parameter("@benefitrelation2", HelperConvert.ConvertToString(iProp.benefitrelation2))
                    , iSql.SqlCom_Parameter("@benefitpercent2", iProp.benefitpercent2)
                    , iSql.SqlCom_Parameter("@benefitname3", HelperConvert.ConvertToString(iProp.benefitname3))
                    , iSql.SqlCom_Parameter("@benefitage3", iProp.benefitage3)
                    , iSql.SqlCom_Parameter("@benefitrelation3", HelperConvert.ConvertToString(iProp.benefitrelation3))
                    , iSql.SqlCom_Parameter("@benefitpercent3", iProp.benefitpercent3)
                    , iSql.SqlCom_Parameter("@benefitname4", HelperConvert.ConvertToString(iProp.benefitname4))
                    , iSql.SqlCom_Parameter("@benefitage4", iProp.benefitage4)
                    , iSql.SqlCom_Parameter("@benefitrelation4", HelperConvert.ConvertToString(iProp.benefitrelation4))
                    , iSql.SqlCom_Parameter("@benefitpercent4", iProp.benefitpercent4)
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

        public FormBenefitInsuranceModels FormBenefitInsuranceDetail(FormBenefitInsuranceModels iProp)
        {
            String query = "up_form_benefit_insurance_detail";
            FormBenefitInsuranceModels iData = new FormBenefitInsuranceModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormBenefitInsuranceModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 policyNo = HelperConvert.ConvertToString(r.Field<object>("policyNo")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 birth_date = HelperConvert.ConvertToString(r.Field<object>("birth_date")!)
                                 ,
                                 age = HelperConvert.ConvertToInt(r.Field<object>("age")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 benefitname1 = HelperConvert.ConvertToString(r.Field<object>("benefitname1")!)
                                 ,
                                 benefitage1 = HelperConvert.ConvertToInt(r.Field<object>("benefitage1")!)
                                 ,
                                 benefitrelation1 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation1")!)
                                 ,
                                 benefitpercent1 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent1")!)
                                 ,
                                 benefitname2 = HelperConvert.ConvertToString(r.Field<object>("benefitname2")!)
                                 ,
                                 benefitage2 = HelperConvert.ConvertToInt(r.Field<object>("benefitage2")!)
                                 ,
                                 benefitrelation2 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation2")!)
                                 ,
                                 benefitpercent2 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent2")!)
                                 ,
                                 benefitname3 = HelperConvert.ConvertToString(r.Field<object>("benefitname3")!)
                                 ,
                                 benefitage3 = HelperConvert.ConvertToInt(r.Field<object>("benefitage3")!)
                                 ,
                                 benefitrelation3 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation3")!)
                                 ,
                                 benefitpercent3 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent3")!)
                                 ,
                                 benefitname4 = HelperConvert.ConvertToString(r.Field<object>("benefitname4")!)
                                 ,
                                 benefitage4 = HelperConvert.ConvertToInt(r.Field<object>("benefitage4")!)
                                 ,
                                 benefitrelation4 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation4")!)
                                 ,
                                 benefitpercent4 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent4")!)
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

        #region FormPerformanceLv2
        public void FormPerformanceLv2Create(FormPerformanceLv2Models iProp)
        {
            String query = "up_form_performance_lv2_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@section", HelperConvert.ConvertToString(iProp.section))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@probation_start_date", HelperConvert.ConvertToDate112(iProp.probation_start_date))
                    , iSql.SqlCom_Parameter("@probation_end_date", HelperConvert.ConvertToDate112(iProp.probation_end_date))
                    , iSql.SqlCom_Parameter("@late", iProp.late)
                    , iSql.SqlCom_Parameter("@personal_leave", iProp.personal_leave)
                    , iSql.SqlCom_Parameter("@sick_leave", iProp.sick_leave)
                    , iSql.SqlCom_Parameter("@absence", iProp.absence)
                    , iSql.SqlCom_Parameter("@warning", iProp.warning)
                    , iSql.SqlCom_Parameter("@answer1", iProp.answer1)
                    , iSql.SqlCom_Parameter("@answer2", iProp.answer2)
                    , iSql.SqlCom_Parameter("@answer3", iProp.answer3)
                    , iSql.SqlCom_Parameter("@answer4", iProp.answer4)
                    , iSql.SqlCom_Parameter("@answer5", iProp.answer5)
                    , iSql.SqlCom_Parameter("@answer6", iProp.answer6)
                    , iSql.SqlCom_Parameter("@answer7", iProp.answer7)
                    , iSql.SqlCom_Parameter("@answer8", iProp.answer8)
                    , iSql.SqlCom_Parameter("@answer9", iProp.answer9)
                    , iSql.SqlCom_Parameter("@answer10", iProp.answer10)
                    , iSql.SqlCom_Parameter("@total", iProp.total)
                    , iSql.SqlCom_Parameter("@grade", HelperConvert.ConvertToString(iProp.grade))
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

        public void FormPerformanceLv2Approve1(FormPerformanceLv2Models iProp)
        {
            String query = "up_form_performance_lv2_upd_approve1";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@suitability_mode", HelperConvert.ConvertToString(iProp.suitability_mode))
                    , iSql.SqlCom_Parameter("@suitability_desc", HelperConvert.ConvertToString(iProp.suitability_desc))
                    , iSql.SqlCom_Parameter("@strengths_desc", HelperConvert.ConvertToString(iProp.strengths_desc))
                    , iSql.SqlCom_Parameter("@improvement_desc", HelperConvert.ConvertToString(iProp.improvement_desc))
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

        public void FormPerformanceLv2Approve2(FormPerformanceLv2Models iProp)
        {
            String query = "up_form_performance_lv2_upd_approve2";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@top_supervisor_comment", HelperConvert.ConvertToString(iProp.top_supervisor_comment))
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

        public FormPerformanceLv2Models FormPerformanceLv2Detail(FormPerformanceLv2Models iProp)
        {
            String query = "up_form_performance_lv2_detail";
            FormPerformanceLv2Models iData = new FormPerformanceLv2Models();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormPerformanceLv2Models
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 section = HelperConvert.ConvertToString(r.Field<object>("section")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 probation_start_date = HelperConvert.ConvertToString(r.Field<object>("probation_start_date")!)
                                 ,
                                 probation_end_date = HelperConvert.ConvertToString(r.Field<object>("probation_end_date")!)
                                 ,
                                 late = HelperConvert.ConvertToInt(r.Field<object>("late")!)
                                 ,
                                 personal_leave = HelperConvert.ConvertToInt(r.Field<object>("personal_leave")!)
                                 ,
                                 sick_leave = HelperConvert.ConvertToInt(r.Field<object>("sick_leave")!)
                                 ,
                                 absence = HelperConvert.ConvertToInt(r.Field<object>("absence")!)
                                 ,
                                 warning = HelperConvert.ConvertToInt(r.Field<object>("warning")!)
                                 ,
                                 answer1 = HelperConvert.ConvertToInt(r.Field<object>("answer1")!)
                                 ,
                                 answer2 = HelperConvert.ConvertToInt(r.Field<object>("answer2")!)
                                 ,
                                 answer3 = HelperConvert.ConvertToInt(r.Field<object>("answer3")!)
                                 ,
                                 answer4 = HelperConvert.ConvertToInt(r.Field<object>("answer4")!)
                                 ,
                                 answer5 = HelperConvert.ConvertToInt(r.Field<object>("answer5")!)
                                 ,
                                 answer6 = HelperConvert.ConvertToInt(r.Field<object>("answer6")!)
                                 ,
                                 answer7 = HelperConvert.ConvertToInt(r.Field<object>("answer7")!)
                                 ,
                                 answer8 = HelperConvert.ConvertToInt(r.Field<object>("answer8")!)
                                 ,
                                 answer9 = HelperConvert.ConvertToInt(r.Field<object>("answer9")!)
                                 ,
                                 answer10 = HelperConvert.ConvertToInt(r.Field<object>("answer10")!)
                                 ,
                                 total = HelperConvert.ConvertToInt(r.Field<object>("total")!)
                                 ,
                                 grade = HelperConvert.ConvertToString(r.Field<object>("grade")!)
                                 ,
                                 suitability_mode = HelperConvert.ConvertToString(r.Field<object>("suitability_mode")!)
                                 ,
                                 suitability_desc = HelperConvert.ConvertToString(r.Field<object>("suitability_desc")!)
                                 ,
                                 strengths_desc = HelperConvert.ConvertToString(r.Field<object>("strengths_desc")!)
                                 ,
                                 improvement_desc = HelperConvert.ConvertToString(r.Field<object>("improvement_desc")!)
                                 ,
                                 top_supervisor_comment = HelperConvert.ConvertToString(r.Field<object>("top_supervisor_comment")!)
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

        #region FormMoveEmployee
        public void FormMoveEmployeeCreate(FormMoveEmployeeModels iProp)
        {
            String query = "up_form_move_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@section", HelperConvert.ConvertToString(iProp.section))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@age", iProp.age)
                    , iSql.SqlCom_Parameter("@job_description", HelperConvert.ConvertToString(iProp.job_description))
                    , iSql.SqlCom_Parameter("@new_department", HelperConvert.ConvertToString(iProp.new_department))
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

        public FormMoveEmployeeModels FormMoveEmployeeDetail(FormMoveEmployeeModels iProp)
        {
            String query = "up_form_move_employee_detail";
            FormMoveEmployeeModels iData = new FormMoveEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormMoveEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 section = HelperConvert.ConvertToString(r.Field<object>("section")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 age = HelperConvert.ConvertToInt(r.Field<object>("age")!)
                                 ,
                                 job_description = HelperConvert.ConvertToString(r.Field<object>("job_description")!)
                                 ,
                                 new_department = HelperConvert.ConvertToString(r.Field<object>("new_department")!)
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

        #region FormHiringEmployee
        public void FormHiringEmployeeCreate(FormHiringEmployeeModels iProp)
        {
            String query = "up_form_hiring_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@section", HelperConvert.ConvertToString(iProp.section))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@probation_salary", iProp.probation_salary)
                    , iSql.SqlCom_Parameter("@probation_period", HelperConvert.ConvertToString(iProp.probation_period))
                    , iSql.SqlCom_Parameter("@salary", iProp.salary)
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

        public FormHiringEmployeeModels FormHiringEmployeeDetail(FormHiringEmployeeModels iProp)
        {
            String query = "up_form_hiring_employee_detail";
            FormHiringEmployeeModels iData = new FormHiringEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormHiringEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 section = HelperConvert.ConvertToString(r.Field<object>("section")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 probation_salary = HelperConvert.ConvertToDecimal(r.Field<object>("probation_salary")!)
                                 ,
                                 probation_period = HelperConvert.ConvertToString(r.Field<object>("probation_period")!)
                                 ,
                                 salary = HelperConvert.ConvertToDecimal(r.Field<object>("salary")!)
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
