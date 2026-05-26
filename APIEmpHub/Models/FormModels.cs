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
                    , iSql.SqlCom_Parameter("@start_date", HelperConvert.ConvertToDate112(iProp.start_date))
                    , iSql.SqlCom_Parameter("@end_date", HelperConvert.ConvertToDate112(iProp.end_date))
                    , iSql.SqlCom_Parameter("@start_time", HelperConvert.ConvertToString(iProp.start_time))
                    , iSql.SqlCom_Parameter("@end_time", HelperConvert.ConvertToString(iProp.end_time))
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
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 level = HelperConvert.ConvertToString(r.Field<object>("level")!)
                                 ,
                                 section = HelperConvert.ConvertToString(r.Field<object>("section")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 division = HelperConvert.ConvertToString(r.Field<object>("division")!)
                                 ,
                                 license = HelperConvert.ConvertToString(r.Field<object>("license")!)
                                 ,
                                 objectives = HelperConvert.ConvertToString(r.Field<object>("objectives")!)
                                 ,
                                 organization = HelperConvert.ConvertToString(r.Field<object>("organization")!)
                                 ,
                                 location = HelperConvert.ConvertToString(r.Field<object>("location")!)
                                 ,
                                 start_date = HelperConvert.ConvertToString(r.Field<object>("start_date")!)
                                 ,
                                 end_date = HelperConvert.ConvertToString(r.Field<object>("end_date")!)
                                 ,
                                 start_time = HelperConvert.ConvertToString(r.Field<object>("start_time")!)
                                 ,
                                 end_time = HelperConvert.ConvertToString(r.Field<object>("end_time")!)
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
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve3_by = HelperConvert.ConvertToString(r.Field<object>("approve3_by")!)
                                 ,
                                 approve4_by = HelperConvert.ConvertToString(r.Field<object>("approve4_by")!)
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
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
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
                    , iSql.SqlCom_Parameter("@benefitname5", HelperConvert.ConvertToString(iProp.benefitname5))
                    , iSql.SqlCom_Parameter("@benefitage5", iProp.benefitage5)
                    , iSql.SqlCom_Parameter("@benefitrelation5", HelperConvert.ConvertToString(iProp.benefitrelation5))
                    , iSql.SqlCom_Parameter("@benefitpercent5", iProp.benefitpercent5)
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
                                 birth_date_day = HelperConvert.ConvertToString(r.Field<object>("birth_date_day")!)
                                 ,
                                 birth_date_month = HelperConvert.ConvertToString(r.Field<object>("birth_date_month")!)
                                 ,
                                 birth_date_year = HelperConvert.ConvertToString(r.Field<object>("birth_date_year")!)
                                 ,
                                 birth_date_age = HelperConvert.ConvertToString(r.Field<object>("birth_date_age")!)
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
                                 ,
                                 benefitname5 = HelperConvert.ConvertToString(r.Field<object>("benefitname5")!)
                                 ,
                                 benefitage5 = HelperConvert.ConvertToInt(r.Field<object>("benefitage5")!)
                                 ,
                                 benefitrelation5 = HelperConvert.ConvertToString(r.Field<object>("benefitrelation5")!)
                                 ,
                                 benefitpercent5 = HelperConvert.ConvertToDecimal(r.Field<object>("benefitpercent5")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
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

        public FormPerformanceLv2Models FormPerformanceLv1Detail(FormPerformanceLv2Models iProp)
        {
            String query = "up_form_performance_lv1_detail";
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
                                 score1 = HelperConvert.ConvertToInt(r.Field<object>("score1")!)
                                 ,
                                 score2 = HelperConvert.ConvertToInt(r.Field<object>("score2")!)
                                 ,
                                 score3 = HelperConvert.ConvertToInt(r.Field<object>("score3")!)
                                 ,
                                 score4 = HelperConvert.ConvertToInt(r.Field<object>("score4")!)
                                 ,
                                 score5 = HelperConvert.ConvertToInt(r.Field<object>("score5")!)
                                 ,
                                 score6 = HelperConvert.ConvertToInt(r.Field<object>("score6")!)
                                 ,
                                 score7 = HelperConvert.ConvertToInt(r.Field<object>("score7")!)
                                 ,
                                 score8 = HelperConvert.ConvertToInt(r.Field<object>("score8")!)
                                 ,
                                 score9 = HelperConvert.ConvertToInt(r.Field<object>("score9")!)
                                 ,
                                 score10 = HelperConvert.ConvertToInt(r.Field<object>("score10")!)
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
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve1_position = HelperConvert.ConvertToString(r.Field<object>("approve1_position")!)
                                 ,
                                 approve1_date = HelperConvert.ConvertToString(r.Field<object>("approve1_date")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve2_date = HelperConvert.ConvertToString(r.Field<object>("approve2_date")!)
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
                                 score1 = HelperConvert.ConvertToInt(r.Field<object>("score1")!)
                                 ,
                                 score2 = HelperConvert.ConvertToInt(r.Field<object>("score2")!)
                                 ,
                                 score3 = HelperConvert.ConvertToInt(r.Field<object>("score3")!)
                                 ,
                                 score4 = HelperConvert.ConvertToInt(r.Field<object>("score4")!)
                                 ,
                                 score5 = HelperConvert.ConvertToInt(r.Field<object>("score5")!)
                                 ,
                                 score6 = HelperConvert.ConvertToInt(r.Field<object>("score6")!)
                                 ,
                                 score7 = HelperConvert.ConvertToInt(r.Field<object>("score7")!)
                                 ,
                                 score8 = HelperConvert.ConvertToInt(r.Field<object>("score8")!)
                                 ,
                                 score9 = HelperConvert.ConvertToInt(r.Field<object>("score9")!)
                                 ,
                                 score10 = HelperConvert.ConvertToInt(r.Field<object>("score10")!)
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
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve1_position = HelperConvert.ConvertToString(r.Field<object>("approve1_position")!)
                                 ,
                                 approve1_date = HelperConvert.ConvertToString(r.Field<object>("approve1_date")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve2_date = HelperConvert.ConvertToString(r.Field<object>("approve2_date")!)
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
                    , iSql.SqlCom_Parameter("@age", HelperConvert.ConvertToString(iProp.age))
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
                                 age = HelperConvert.ConvertToString(r.Field<object>("age")!)
                                 ,
                                 job_description = HelperConvert.ConvertToString(r.Field<object>("job_description")!)
                                 ,
                                 new_department = HelperConvert.ConvertToString(r.Field<object>("new_department")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve1_position = HelperConvert.ConvertToString(r.Field<object>("approve1_position")!)
                                 ,
                                 approve1_date = HelperConvert.ConvertToString(r.Field<object>("approve1_date")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve2_position = HelperConvert.ConvertToString(r.Field<object>("approve2_position")!)
                                 ,
                                 approve2_date = HelperConvert.ConvertToString(r.Field<object>("approve2_date")!)
                                 ,
                                 approve3_by = HelperConvert.ConvertToString(r.Field<object>("approve3_by")!)
                                 ,
                                 approve3_position = HelperConvert.ConvertToString(r.Field<object>("approve3_position")!)
                                 ,
                                 approve3_date = HelperConvert.ConvertToString(r.Field<object>("approve3_date")!)
                                 ,
                                 approve4_by = HelperConvert.ConvertToString(r.Field<object>("approve4_by")!)
                                 ,
                                 approve4_position = HelperConvert.ConvertToString(r.Field<object>("approve4_position")!)
                                 ,
                                 approve4_date = HelperConvert.ConvertToString(r.Field<object>("approve4_date")!)
                                 ,
                                 approve5_by = HelperConvert.ConvertToString(r.Field<object>("approve5_by")!)
                                 ,
                                 approve5_position = HelperConvert.ConvertToString(r.Field<object>("approve5_position")!)
                                 ,
                                 approve5_date = HelperConvert.ConvertToString(r.Field<object>("approve5_date")!)
                                 ,
                                 approve6_by = HelperConvert.ConvertToString(r.Field<object>("approve6_by")!)
                                 ,
                                 approve6_position = HelperConvert.ConvertToString(r.Field<object>("approve6_position")!)
                                 ,
                                 approve6_date = HelperConvert.ConvertToString(r.Field<object>("approve6_date")!)
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
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 create_position = HelperConvert.ConvertToString(r.Field<object>("create_position")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve1_date = HelperConvert.ConvertToString(r.Field<object>("approve1_date")!)
                                 ,
                                 approve1_position = HelperConvert.ConvertToString(r.Field<object>("approve1_position")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve2_date = HelperConvert.ConvertToString(r.Field<object>("approve2_date")!)
                                 ,
                                 approve2_position = HelperConvert.ConvertToString(r.Field<object>("approve2_position")!)
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

        #region FormPdpaEmployee
        public void FormPdpaEmployeeCreate(FormPdpaEmployeeModels iProp)
        {
            String query = "up_form_pdpa_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@firstname", HelperConvert.ConvertToString(iProp.firstname))
                    , iSql.SqlCom_Parameter("@lastname", HelperConvert.ConvertToString(iProp.lastname))
                    , iSql.SqlCom_Parameter("@idcard", HelperConvert.ConvertToString(iProp.idcard))
                    , iSql.SqlCom_Parameter("@answer1", HelperConvert.ConvertToString(iProp.answer1))
                    , iSql.SqlCom_Parameter("@answer2", HelperConvert.ConvertToString(iProp.answer2))
                    , iSql.SqlCom_Parameter("@answer3", HelperConvert.ConvertToString(iProp.answer3))
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

        public FormPdpaEmployeeModels FormPdpaEmployeeDetail(FormPdpaEmployeeModels iProp)
        {
            String query = "up_form_pdpa_employee_detail";
            FormPdpaEmployeeModels iData = new FormPdpaEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormPdpaEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 firstname = HelperConvert.ConvertToString(r.Field<object>("firstname")!)
                                 ,
                                 lastname = HelperConvert.ConvertToString(r.Field<object>("lastname")!)
                                 ,
                                 idcard = HelperConvert.ConvertToString(r.Field<object>("idcard")!)
                                 ,
                                 answer1 = HelperConvert.ConvertToString(r.Field<object>("answer1")!)
                                 ,
                                 answer2 = HelperConvert.ConvertToString(r.Field<object>("answer2")!)
                                 ,
                                 answer3 = HelperConvert.ConvertToString(r.Field<object>("answer3")!)
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
        #endregion

        #region FormWfhEmployee
        public void FormWfhEmployeeCreate(FormWfhEmployeeModels iProp)
        {
            String query = "up_form_wfh_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@address", HelperConvert.ConvertToString(iProp.address))
                    , iSql.SqlCom_Parameter("@start_date", HelperConvert.ConvertToDate112(iProp.start_date))
                    , iSql.SqlCom_Parameter("@answer1", HelperConvert.ConvertToString(iProp.answer1))
                    , iSql.SqlCom_Parameter("@answer2", HelperConvert.ConvertToString(iProp.answer2))
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

        public FormWfhEmployeeModels FormWfhEmployeeDetail(FormWfhEmployeeModels iProp)
        {
            String query = "up_form_wfh_employee_detail";
            FormWfhEmployeeModels iData = new FormWfhEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormWfhEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 address = HelperConvert.ConvertToString(r.Field<object>("address")!)
                                 ,
                                 start_date = HelperConvert.ConvertToString(r.Field<object>("start_date")!)
                                 ,
                                 answer1 = HelperConvert.ConvertToString(r.Field<object>("answer1")!)
                                 ,
                                 answer2 = HelperConvert.ConvertToString(r.Field<object>("answer2")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
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

        #region FormAgreementEmployee
        public void FormAgreementEmployeeCreate(FormAgreementEmployeeModels iProp)
        {
            String query = "up_form_agreement_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
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

        public FormAgreementEmployeeModels FormAgreementEmployeeDetail(FormAgreementEmployeeModels iProp)
        {
            String query = "up_form_agreement_employee_detail";
            FormAgreementEmployeeModels iData = new FormAgreementEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormAgreementEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
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
        #endregion

        #region FormPrepareEmployee
        public void FormPrepareEmployeeCreate(FormPrepareEmployeeModels iProp)
        {
            String query = "up_form_prepare_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@prefix", HelperConvert.ConvertToString(iProp.prefix))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@phoneNo", HelperConvert.ConvertToString(iProp.phoneNo))
                    , iSql.SqlCom_Parameter("@username", HelperConvert.ConvertToString(iProp.username))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@sharedrive", HelperConvert.ConvertToString(iProp.sharedrive))
                    , iSql.SqlCom_Parameter("@speccomputer", HelperConvert.ConvertToString(iProp.speccomputer))
                    , iSql.SqlCom_Parameter("@answer1", HelperConvert.ConvertToString(iProp.answer1))
                    , iSql.SqlCom_Parameter("@answer2", HelperConvert.ConvertToString(iProp.answer2))
                    , iSql.SqlCom_Parameter("@answer3", HelperConvert.ConvertToString(iProp.answer3))
                    , iSql.SqlCom_Parameter("@answer3_desc", HelperConvert.ConvertToString(iProp.answer3_desc))
                    , iSql.SqlCom_Parameter("@answer4", HelperConvert.ConvertToString(iProp.answer4))
                    , iSql.SqlCom_Parameter("@answer4_desc", HelperConvert.ConvertToString(iProp.answer4_desc))
                    , iSql.SqlCom_Parameter("@answer5", HelperConvert.ConvertToString(iProp.answer5))
                    , iSql.SqlCom_Parameter("@answer5_desc", HelperConvert.ConvertToString(iProp.answer5_desc))
                    , iSql.SqlCom_Parameter("@answer6", HelperConvert.ConvertToString(iProp.answer6))
                    , iSql.SqlCom_Parameter("@answer6_desc", HelperConvert.ConvertToString(iProp.answer6_desc))
                    , iSql.SqlCom_Parameter("@answer7", HelperConvert.ConvertToString(iProp.answer7))
                    , iSql.SqlCom_Parameter("@answer7_desc", HelperConvert.ConvertToString(iProp.answer7_desc))
                    , iSql.SqlCom_Parameter("@answer8", HelperConvert.ConvertToString(iProp.answer8))
                    , iSql.SqlCom_Parameter("@answer8_desc", HelperConvert.ConvertToString(iProp.answer8_desc))
                    , iSql.SqlCom_Parameter("@answer9", HelperConvert.ConvertToString(iProp.answer9))
                    , iSql.SqlCom_Parameter("@answer9_desc", HelperConvert.ConvertToString(iProp.answer9_desc))
                    , iSql.SqlCom_Parameter("@gls_system", HelperConvert.ConvertToString(iProp.gls_system))
                    , iSql.SqlCom_Parameter("@gls_desc", HelperConvert.ConvertToString(iProp.gls_desc))
                    , iSql.SqlCom_Parameter("@ls_system", HelperConvert.ConvertToString(iProp.ls_system))
                    , iSql.SqlCom_Parameter("@ls_desc", HelperConvert.ConvertToString(iProp.ls_desc))
                    , iSql.SqlCom_Parameter("@linet_system", HelperConvert.ConvertToString(iProp.linet_system))
                    , iSql.SqlCom_Parameter("@linet_desc", HelperConvert.ConvertToString(iProp.linet_desc))
                    , iSql.SqlCom_Parameter("@sun_system", HelperConvert.ConvertToString(iProp.sun_system))
                    , iSql.SqlCom_Parameter("@sun_desc", HelperConvert.ConvertToString(iProp.sun_desc))
                    , iSql.SqlCom_Parameter("@prophet_system", HelperConvert.ConvertToString(iProp.prophet_system))
                    , iSql.SqlCom_Parameter("@prophet_desc", HelperConvert.ConvertToString(iProp.prophet_desc))
                    , iSql.SqlCom_Parameter("@bonunza_system", HelperConvert.ConvertToString(iProp.bonunza_system))
                    , iSql.SqlCom_Parameter("@bonunza_desc", HelperConvert.ConvertToString(iProp.bonunza_desc))
                    , iSql.SqlCom_Parameter("@other_system", HelperConvert.ConvertToString(iProp.other_system))
                    , iSql.SqlCom_Parameter("@other_desc", HelperConvert.ConvertToString(iProp.other_desc))
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

        public FormPrepareEmployeeModels FormPrepareEmployeeDetail(FormPrepareEmployeeModels iProp)
        {
            String query = "up_form_prepare_employee_detail";
            FormPrepareEmployeeModels iData = new FormPrepareEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormPrepareEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 prefix = HelperConvert.ConvertToString(r.Field<object>("prefix")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 phoneNo = HelperConvert.ConvertToString(r.Field<object>("phoneNo")!)
                                 ,
                                 username = HelperConvert.ConvertToString(r.Field<object>("username")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 sharedrive = HelperConvert.ConvertToString(r.Field<object>("sharedrive")!)
                                 ,
                                 speccomputer = HelperConvert.ConvertToString(r.Field<object>("speccomputer")!)
                                 ,
                                 answer1 = HelperConvert.ConvertToString(r.Field<object>("answer1")!)
                                 ,
                                 answer2 = HelperConvert.ConvertToString(r.Field<object>("answer2")!)
                                 ,
                                 answer3 = HelperConvert.ConvertToString(r.Field<object>("answer3")!)
                                 ,
                                 answer3_desc = HelperConvert.ConvertToString(r.Field<object>("answer3_desc")!)
                                 ,
                                 answer4 = HelperConvert.ConvertToString(r.Field<object>("answer4")!)
                                 ,
                                 answer4_desc = HelperConvert.ConvertToString(r.Field<object>("answer4_desc")!)
                                 ,
                                 answer5 = HelperConvert.ConvertToString(r.Field<object>("answer5")!)
                                 ,
                                 answer5_desc = HelperConvert.ConvertToString(r.Field<object>("answer5_desc")!)
                                 ,
                                 answer6 = HelperConvert.ConvertToString(r.Field<object>("answer6")!)
                                 ,
                                 answer6_desc = HelperConvert.ConvertToString(r.Field<object>("answer6_desc")!)
                                 ,
                                 answer7 = HelperConvert.ConvertToString(r.Field<object>("answer7")!)
                                 ,
                                 answer7_desc = HelperConvert.ConvertToString(r.Field<object>("answer7_desc")!)
                                 ,
                                 answer8 = HelperConvert.ConvertToString(r.Field<object>("answer8")!)
                                 ,
                                 answer8_desc = HelperConvert.ConvertToString(r.Field<object>("answer8_desc")!)
                                 ,
                                 answer9 = HelperConvert.ConvertToString(r.Field<object>("answer9")!)
                                 ,
                                 answer9_desc = HelperConvert.ConvertToString(r.Field<object>("answer9_desc")!)
                                 ,
                                 gls_desc = HelperConvert.ConvertToString(r.Field<object>("gls_desc")!)
                                 ,
                                 gls_system = HelperConvert.ConvertToString(r.Field<object>("gls_system")!)
                                 ,
                                 ls_desc = HelperConvert.ConvertToString(r.Field<object>("ls_desc")!)
                                 ,
                                 ls_system = HelperConvert.ConvertToString(r.Field<object>("ls_system")!)
                                 ,
                                 linet_desc = HelperConvert.ConvertToString(r.Field<object>("linet_desc")!)
                                 ,
                                 linet_system = HelperConvert.ConvertToString(r.Field<object>("linet_system")!)
                                 ,
                                 sun_desc = HelperConvert.ConvertToString(r.Field<object>("sun_desc")!)
                                 ,
                                 sun_system = HelperConvert.ConvertToString(r.Field<object>("sun_system")!)
                                 ,
                                 prophet_desc = HelperConvert.ConvertToString(r.Field<object>("prophet_desc")!)
                                 ,
                                 prophet_system = HelperConvert.ConvertToString(r.Field<object>("prophet_system")!)
                                 ,
                                 bonunza_desc = HelperConvert.ConvertToString(r.Field<object>("bonunza_desc")!)
                                 ,
                                 bonunza_system = HelperConvert.ConvertToString(r.Field<object>("bonunza_system")!)
                                 ,
                                 other_desc = HelperConvert.ConvertToString(r.Field<object>("other_desc")!)
                                 ,
                                 other_system = HelperConvert.ConvertToString(r.Field<object>("other_system")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 create_position = HelperConvert.ConvertToString(r.Field<object>("create_position")!)
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

        #region FormProbationReport
        public void FormProbationReportCreate(FormProbationReportModels iProp)
        {
            String query = "up_form_probation_report_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@period", HelperConvert.ConvertToString(iProp.period))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToString(iProp.join_date))
                    , iSql.SqlCom_Parameter("@answer1", HelperConvert.ConvertToString(iProp.answer1))
                    , iSql.SqlCom_Parameter("@answer2", HelperConvert.ConvertToString(iProp.answer2))
                    , iSql.SqlCom_Parameter("@answer3", HelperConvert.ConvertToString(iProp.answer3))
                    , iSql.SqlCom_Parameter("@answer4", HelperConvert.ConvertToString(iProp.answer4))
                    , iSql.SqlCom_Parameter("@answer5", HelperConvert.ConvertToString(iProp.answer5))
                    , iSql.SqlCom_Parameter("@answer5_fixed", HelperConvert.ConvertToString(iProp.answer5_fixed))
                    , iSql.SqlCom_Parameter("@answer6", HelperConvert.ConvertToString(iProp.answer6))
                    , iSql.SqlCom_Parameter("@answer6_fixed", HelperConvert.ConvertToString(iProp.answer6_fixed))
                    , iSql.SqlCom_Parameter("@answer7", HelperConvert.ConvertToString(iProp.answer7))
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

        public FormProbationReportModels FormProbationReportDetail(FormProbationReportModels iProp)
        {
            String query = "up_form_probation_report_detail";
            FormProbationReportModels iData = new FormProbationReportModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormProbationReportModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 period = HelperConvert.ConvertToString(r.Field<object>("period")!)
                                 ,
                                 answer1 = HelperConvert.ConvertToString(r.Field<object>("answer1")!)
                                 ,
                                 answer2 = HelperConvert.ConvertToString(r.Field<object>("answer2")!)
                                 ,
                                 answer3 = HelperConvert.ConvertToString(r.Field<object>("answer3")!)
                                 ,
                                 answer4 = HelperConvert.ConvertToString(r.Field<object>("answer4")!)
                                 ,
                                 answer5 = HelperConvert.ConvertToString(r.Field<object>("answer5")!)
                                 ,
                                 answer5_fixed = HelperConvert.ConvertToString(r.Field<object>("answer5_fixed")!)
                                 ,
                                 answer6 = HelperConvert.ConvertToString(r.Field<object>("answer6")!)
                                 ,
                                 answer6_fixed = HelperConvert.ConvertToString(r.Field<object>("answer6_fixed")!)
                                 ,
                                 answer7 = HelperConvert.ConvertToString(r.Field<object>("answer7")!)
                                 ,
                                 create_by = HelperConvert.ConvertToString(r.Field<object>("create_by")!)
                                 ,
                                 create_date = HelperConvert.ConvertToString(r.Field<object>("create_date")!)
                                 ,
                                 create_date_day = HelperConvert.ConvertToString(r.Field<object>("create_date_day")!)
                                 ,
                                 create_date_month = HelperConvert.ConvertToString(r.Field<object>("create_date_month")!)
                                 ,
                                 create_date_year = HelperConvert.ConvertToString(r.Field<object>("create_date_year")!)
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

        #region FormPromoteEmployee
        public void FormPromoteEmployeeCreate(FormPromoteEmployeeModels iProp)
        {
            String query = "up_form_promote_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@position", HelperConvert.ConvertToString(iProp.position))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@section", HelperConvert.ConvertToString(iProp.section))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToString(iProp.join_date))
                    , iSql.SqlCom_Parameter("@year", HelperConvert.ConvertToString(iProp.year))
                    , iSql.SqlCom_Parameter("@grade1", HelperConvert.ConvertToString(iProp.grade1))
                    , iSql.SqlCom_Parameter("@grade2", HelperConvert.ConvertToString(iProp.grade2))
                    , iSql.SqlCom_Parameter("@position_current", HelperConvert.ConvertToString(iProp.position_current))
                    , iSql.SqlCom_Parameter("@department_current", HelperConvert.ConvertToString(iProp.department_current))
                    , iSql.SqlCom_Parameter("@position_new", HelperConvert.ConvertToString(iProp.position_new))
                    , iSql.SqlCom_Parameter("@department_new", HelperConvert.ConvertToString(iProp.department_new))
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

        public FormPromoteEmployeeModels FormPromoteEmployeeDetail(FormPromoteEmployeeModels iProp)
        {
            String query = "up_form_promote_employee_detail";
            FormPromoteEmployeeModels iData = new FormPromoteEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormPromoteEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 position = HelperConvert.ConvertToString(r.Field<object>("position")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 section = HelperConvert.ConvertToString(r.Field<object>("section")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 year = HelperConvert.ConvertToString(r.Field<object>("year")!)
                                 ,
                                 grade1 = HelperConvert.ConvertToString(r.Field<object>("grade1")!)
                                 ,
                                 grade2 = HelperConvert.ConvertToString(r.Field<object>("grade2")!)
                                 ,
                                 position_current = HelperConvert.ConvertToString(r.Field<object>("position_current")!)
                                 ,
                                 department_current = HelperConvert.ConvertToString(r.Field<object>("department_current")!)
                                 ,
                                 position_new = HelperConvert.ConvertToString(r.Field<object>("position_new")!)
                                 ,
                                 department_new = HelperConvert.ConvertToString(r.Field<object>("department_new")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
                                 ,
                                 approve1_by = HelperConvert.ConvertToString(r.Field<object>("approve1_by")!)
                                 ,
                                 approve2_by = HelperConvert.ConvertToString(r.Field<object>("approve2_by")!)
                                 ,
                                 approve3_by = HelperConvert.ConvertToString(r.Field<object>("approve3_by")!)
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

        #region FormIDP
        public void FormIDPCreate(FormIDPModels iProp)
        {
            String query = "up_form_idp_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@fullname", HelperConvert.ConvertToString(iProp.fullname))
                    , iSql.SqlCom_Parameter("@department", HelperConvert.ConvertToString(iProp.department))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@objective", HelperConvert.ConvertToString(iProp.objective))
                    , iSql.SqlCom_Parameter("@answer1_desc", HelperConvert.ConvertToString(iProp.answer1_desc))
                    , iSql.SqlCom_Parameter("@answer2_desc", HelperConvert.ConvertToString(iProp.answer2_desc))
                    , iSql.SqlCom_Parameter("@answer2_date", HelperConvert.ConvertToDate112(iProp.answer2_date))
                    , iSql.SqlCom_Parameter("@answer3_desc", HelperConvert.ConvertToString(iProp.answer3_desc))
                    , iSql.SqlCom_Parameter("@answer3_date", HelperConvert.ConvertToDate112(iProp.answer3_date))
                    , iSql.SqlCom_Parameter("@answer4_desc", HelperConvert.ConvertToString(iProp.answer4_desc))
                    , iSql.SqlCom_Parameter("@answer4_date", HelperConvert.ConvertToDate112(iProp.answer4_date))
                    , iSql.SqlCom_Parameter("@answer5_desc", HelperConvert.ConvertToString(iProp.answer5_desc))
                    , iSql.SqlCom_Parameter("@answer6_desc", HelperConvert.ConvertToString(iProp.answer6_desc))
                    , iSql.SqlCom_Parameter("@answer6_date", HelperConvert.ConvertToDate112(iProp.answer6_date))
                    , iSql.SqlCom_Parameter("@answer7_a_desc", HelperConvert.ConvertToString(iProp.answer7_a_desc))
                    , iSql.SqlCom_Parameter("@answer7_b_desc", HelperConvert.ConvertToString(iProp.answer7_b_desc))
                    , iSql.SqlCom_Parameter("@answer8_desc", HelperConvert.ConvertToString(iProp.answer8_desc))
                    , iSql.SqlCom_Parameter("@answer9_desc", HelperConvert.ConvertToString(iProp.answer9_desc))
                    , iSql.SqlCom_Parameter("@answer9_date", HelperConvert.ConvertToDate112(iProp.answer9_date))
                    , iSql.SqlCom_Parameter("@answer10_a_desc", HelperConvert.ConvertToString(iProp.answer10_a_desc))
                    , iSql.SqlCom_Parameter("@answer10_b_desc", HelperConvert.ConvertToString(iProp.answer10_b_desc))
                    , iSql.SqlCom_Parameter("@answer11_desc", HelperConvert.ConvertToString(iProp.answer11_desc))
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

        public FormIDPModels FormIDPDetail(FormIDPModels iProp)
        {
            String query = "up_form_idp_detail";
            FormIDPModels iData = new FormIDPModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormIDPModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 fullname = HelperConvert.ConvertToString(r.Field<object>("fullname")!)
                                 ,
                                 department = HelperConvert.ConvertToString(r.Field<object>("department")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 objective = HelperConvert.ConvertToString(r.Field<object>("objective")!)
                                 ,
                                 answer1_desc = HelperConvert.ConvertToString(r.Field<object>("answer1_desc")!)
                                 ,
                                 answer2_desc = HelperConvert.ConvertToString(r.Field<object>("answer2_desc")!)
                                 ,
                                 answer2_date = HelperConvert.ConvertToString(r.Field<object>("answer2_date")!)
                                 ,
                                 answer3_desc = HelperConvert.ConvertToString(r.Field<object>("answer3_desc")!)
                                 ,
                                 answer3_date = HelperConvert.ConvertToString(r.Field<object>("answer3_date")!)
                                 ,
                                 answer4_desc = HelperConvert.ConvertToString(r.Field<object>("answer4_desc")!)
                                 ,
                                 answer4_date = HelperConvert.ConvertToString(r.Field<object>("answer4_date")!)
                                 ,
                                 answer5_desc = HelperConvert.ConvertToString(r.Field<object>("answer5_desc")!)
                                 ,
                                 answer6_desc = HelperConvert.ConvertToString(r.Field<object>("answer6_desc")!)
                                 ,
                                 answer6_date = HelperConvert.ConvertToString(r.Field<object>("answer6_date")!)
                                 ,
                                 answer7_a_desc = HelperConvert.ConvertToString(r.Field<object>("answer7_a_desc")!)
                                 ,
                                 answer7_b_desc = HelperConvert.ConvertToString(r.Field<object>("answer7_b_desc")!)
                                 ,
                                 answer8_desc = HelperConvert.ConvertToString(r.Field<object>("answer8_desc")!)
                                 ,
                                 answer9_desc = HelperConvert.ConvertToString(r.Field<object>("answer9_desc")!)
                                 ,
                                 answer9_date = HelperConvert.ConvertToString(r.Field<object>("answer9_date")!)
                                 ,
                                 answer10_a_desc = HelperConvert.ConvertToString(r.Field<object>("answer10_a_desc")!)
                                 ,
                                 answer10_b_desc = HelperConvert.ConvertToString(r.Field<object>("answer10_b_desc")!)
                                 ,
                                 answer11_desc = HelperConvert.ConvertToString(r.Field<object>("answer11_desc")!)
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

        #region FormUpdatePersonal
        public void FormUpdatePersonalCreate(FormUpdatePersonalModels iProp)
        {
            String query = "up_form_update_personal_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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
                    , iSql.SqlCom_Parameter("@weight", iProp.weight)
                    , iSql.SqlCom_Parameter("@height", iProp.height)
                    , iSql.SqlCom_Parameter("@blood", HelperConvert.ConvertToString(iProp.blood))
                    , iSql.SqlCom_Parameter("@nationality", HelperConvert.ConvertToString(iProp.nationality))
                    , iSql.SqlCom_Parameter("@ethnicity", HelperConvert.ConvertToString(iProp.ethnicity))
                    , iSql.SqlCom_Parameter("@religion", HelperConvert.ConvertToString(iProp.religion))
                    , iSql.SqlCom_Parameter("@maritalStatus", HelperConvert.ConvertToString(iProp.maritalStatus))
                    , iSql.SqlCom_Parameter("@militaryStatus", HelperConvert.ConvertToString(iProp.militaryStatus))
                    , iSql.SqlCom_Parameter("@disabilityStatus", HelperConvert.ConvertToString(iProp.disabilityStatus))
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

        public FormUpdatePersonalModels FormUpdatePersonalDetail(FormUpdatePersonalModels iProp)
        {
            String query = "up_form_update_personal_detail";
            FormUpdatePersonalModels iData = new FormUpdatePersonalModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormUpdatePersonalModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 prefix_th = HelperConvert.ConvertToString(r.Field<object>("prefix_th")!)
                                 ,
                                 firstname_th = HelperConvert.ConvertToString(r.Field<object>("firstname_th")!)
                                 ,
                                 lastname_th = HelperConvert.ConvertToString(r.Field<object>("lastname_th")!)
                                 ,
                                 prefix_en = HelperConvert.ConvertToString(r.Field<object>("prefix_en")!)
                                 ,
                                 firstname_en = HelperConvert.ConvertToString(r.Field<object>("firstname_en")!)
                                 ,
                                 lastname_en = HelperConvert.ConvertToString(r.Field<object>("lastname_en")!)
                                 ,
                                 nickname = HelperConvert.ConvertToString(r.Field<object>("nickname")!)
                                 ,
                                 sex = HelperConvert.ConvertToString(r.Field<object>("sex")!)
                                 ,
                                 birth_date = HelperConvert.ConvertToString(r.Field<object>("birth_date")!)
                                 ,
                                 age = HelperConvert.ConvertToString(r.Field<object>("age")!)
                                 ,
                                 weight = HelperConvert.ConvertToInt(r.Field<object>("weight")!)
                                 ,
                                 height = HelperConvert.ConvertToInt(r.Field<object>("height")!)
                                 ,
                                 blood = HelperConvert.ConvertToString(r.Field<object>("blood")!)
                                 ,
                                 nationality = HelperConvert.ConvertToString(r.Field<object>("nationality")!)
                                 ,
                                 ethnicity = HelperConvert.ConvertToString(r.Field<object>("ethnicity")!)
                                 ,
                                 religion = HelperConvert.ConvertToString(r.Field<object>("religion")!)
                                 ,
                                 maritalStatus = HelperConvert.ConvertToString(r.Field<object>("maritalStatus")!)
                                 ,
                                 militaryStatus = HelperConvert.ConvertToString(r.Field<object>("militaryStatus")!)
                                 ,
                                 disabilityStatus = HelperConvert.ConvertToString(r.Field<object>("disabilityStatus")!)
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

        #region FormUpdateEmployee
        public void FormUpdateEmployeeCreate(FormUpdateEmployeeModels iProp)
        {
            String query = "up_form_update_employee_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@join_date", HelperConvert.ConvertToDate112(iProp.join_date))
                    , iSql.SqlCom_Parameter("@probation_end_date", HelperConvert.ConvertToDate112(iProp.probation_end_date))
                    , iSql.SqlCom_Parameter("@employeeType", HelperConvert.ConvertToString(iProp.employeeType))
                    , iSql.SqlCom_Parameter("@divisionCode", HelperConvert.ConvertToString(iProp.divisionCode))
                    , iSql.SqlCom_Parameter("@departmentCode", HelperConvert.ConvertToString(iProp.departmentCode))
                    , iSql.SqlCom_Parameter("@sectionCode", HelperConvert.ConvertToString(iProp.sectionCode))
                    , iSql.SqlCom_Parameter("@positionCode", HelperConvert.ConvertToString(iProp.positionCode))
                    , iSql.SqlCom_Parameter("@levelCode", HelperConvert.ConvertToString(iProp.levelCode))
                    , iSql.SqlCom_Parameter("@grade", HelperConvert.ConvertToString(iProp.grade))
                    , iSql.SqlCom_Parameter("@supervisorId", HelperConvert.ConvertToString(iProp.supervisorId))
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

        public FormUpdateEmployeeModels FormUpdateEmployeeDetail(FormUpdateEmployeeModels iProp)
        {
            String query = "up_form_update_employee_detail";
            FormUpdateEmployeeModels iData = new FormUpdateEmployeeModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormUpdateEmployeeModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 join_date = HelperConvert.ConvertToString(r.Field<object>("join_date")!)
                                 ,
                                 probation_end_date = HelperConvert.ConvertToString(r.Field<object>("probation_end_date")!)
                                 ,
                                 employeeType = HelperConvert.ConvertToString(r.Field<object>("employeeType")!)
                                 ,
                                 divisionCode = HelperConvert.ConvertToString(r.Field<object>("divisionCode")!)
                                 ,
                                 departmentCode = HelperConvert.ConvertToString(r.Field<object>("departmentCode")!)
                                 ,
                                 sectionCode = HelperConvert.ConvertToString(r.Field<object>("sectionCode")!)
                                 ,
                                 positionCode = HelperConvert.ConvertToString(r.Field<object>("positionCode")!)
                                 ,
                                 levelCode = HelperConvert.ConvertToString(r.Field<object>("levelCode")!)
                                 ,
                                 grade = HelperConvert.ConvertToString(r.Field<object>("grade")!)
                                 ,
                                 supervisorId = HelperConvert.ConvertToString(r.Field<object>("supervisorId")!)
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

        #region FormUpdateCard
        public void FormUpdateCardCreate(FormUpdateCardModels iProp)
        {
            String query = "up_form_update_card_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@employeeCode", HelperConvert.ConvertToString(iProp.employeeCode))
                    , iSql.SqlCom_Parameter("@idcard", HelperConvert.ConvertToString(iProp.idcard))
                    , iSql.SqlCom_Parameter("@passport", HelperConvert.ConvertToString(iProp.passport))
                    , iSql.SqlCom_Parameter("@workPermitNo", HelperConvert.ConvertToString(iProp.workPermitNo))
                    , iSql.SqlCom_Parameter("@bookNo", HelperConvert.ConvertToString(iProp.bookNo))
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

        public FormUpdateCardModels FormUpdateCardDetail(FormUpdateCardModels iProp)
        {
            String query = "up_form_update_card_detail";
            FormUpdateCardModels iData = new FormUpdateCardModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormUpdateCardModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 employeeCode = HelperConvert.ConvertToString(r.Field<object>("employeeCode")!)
                                 ,
                                 idcard = HelperConvert.ConvertToString(r.Field<object>("idcard")!)
                                 ,
                                 passport = HelperConvert.ConvertToString(r.Field<object>("passport")!)
                                 ,
                                 workPermitNo = HelperConvert.ConvertToString(r.Field<object>("workPermitNo")!)
                                 ,
                                 bookNo = HelperConvert.ConvertToString(r.Field<object>("bookNo")!)
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

        #region FormUpdateContact
        public void FormUpdateContactCreate(FormUpdateContactModels iProp)
        {
            String query = "up_form_update_contact_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
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

                    , iSql.SqlCom_Parameter("@mobile", HelperConvert.ConvertToString(iProp.mobile))
                    , iSql.SqlCom_Parameter("@phone", HelperConvert.ConvertToString(iProp.phone))
                    , iSql.SqlCom_Parameter("@email", HelperConvert.ConvertToString(iProp.email))
                    , iSql.SqlCom_Parameter("@phone_office", HelperConvert.ConvertToString(iProp.phone_office))
                    , iSql.SqlCom_Parameter("@email_office", HelperConvert.ConvertToString(iProp.email_office))
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

        public FormUpdateContactModels FormUpdateContactDetail(FormUpdateContactModels iProp)
        {
            String query = "up_form_update_contact_detail";
            FormUpdateContactModels iData = new FormUpdateContactModels();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    iData = (from r in dtData.AsEnumerable()
                             select new FormUpdateContactModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
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
                                 ,
                                 mobile = HelperConvert.ConvertToString(r.Field<object>("mobile")!)
                                 ,
                                 phone = HelperConvert.ConvertToString(r.Field<object>("phone")!)
                                 ,
                                 email = HelperConvert.ConvertToString(r.Field<object>("email")!)
                                 ,
                                 phone_office = HelperConvert.ConvertToString(r.Field<object>("phone_office")!)
                                 ,
                                 email_office = HelperConvert.ConvertToString(r.Field<object>("email_office")!)
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

        #region FormUpdateTalent
        public void FormUpdateTalentCreate(FormUpdateTalentModels iProp)
        {
            String query = "up_form_update_talent_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@talentId", HelperConvert.ConvertToString(iProp.talentId))
                    , iSql.SqlCom_Parameter("@language", HelperConvert.ConvertToString(iProp.language))
                    , iSql.SqlCom_Parameter("@level", HelperConvert.ConvertToString(iProp.level))
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

        public List<FormUpdateTalentModels> FormUpdateTalentDetail(FormUpdateTalentModels iProp)
        {
            String query = "up_form_update_talent_detail";
            List<FormUpdateTalentModels> lData = new List<FormUpdateTalentModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new FormUpdateTalentModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 talentId = HelperConvert.ConvertToString(r.Field<object>("talentId")!)
                                 ,
                                 language = HelperConvert.ConvertToString(r.Field<object>("language")!)
                                 ,
                                 level = HelperConvert.ConvertToString(r.Field<object>("level")!)
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
        #endregion

        #region FormUpdateDocument
        public void FormUpdateDocumentCreate(FormUpdateDocumentModels iProp)
        {
            String query = "up_form_update_document_ins";

            try
            {
                iSql.Open(connectionString);
                iSql.SqlCom_ExecuteNonQuery(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                    , iSql.SqlCom_Parameter("@userId", HelperConvert.ConvertToString(iProp.userId))
                    , iSql.SqlCom_Parameter("@documentId", SqlDbType.NVarChar, 50, ParameterDirection.Output)
                    , iSql.SqlCom_Parameter("@documentType", HelperConvert.ConvertToString(iProp.documentType))
                    , iSql.SqlCom_Parameter("@description", HelperConvert.ConvertToString(iProp.description))
                    , iSql.SqlCom_Parameter("@create_by", HelperConvert.ConvertToString(iProp.create_by))
                    );

                iProp.documentId = HelperConvert.ConvertToString(iSql.sqlCom.Parameters["@documentId"].Value);
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

        public List<FormUpdateDocumentModels> FormUpdateDocumentDetail(FormUpdateDocumentModels iProp)
        {
            String query = "up_form_update_document_detail";
            List<FormUpdateDocumentModels> lData = new List<FormUpdateDocumentModels>();

            try
            {
                iSql.Open(connectionString);
                dtData = iSql.SqlCom_DataAdapterWithDataTable(query, CommandType.StoredProcedure
                    , iSql.SqlCom_Parameter("@refId", HelperConvert.ConvertToString(iProp.refId))
                );

                if (dtData != null && dtData.Rows.Count > 0)
                {
                    lData = (from r in dtData.AsEnumerable()
                             select new FormUpdateDocumentModels
                             {
                                 refId = HelperConvert.ConvertToString(r.Field<object>("refId")!)
                                 ,
                                 userId = HelperConvert.ConvertToString(r.Field<object>("userId")!)
                                 ,
                                 documentId = HelperConvert.ConvertToString(r.Field<object>("documentId")!)
                                 ,
                                 documentType = HelperConvert.ConvertToString(r.Field<object>("documentType")!)
                                 ,
                                 description = HelperConvert.ConvertToString(r.Field<object>("description")!)
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
        #endregion
    }
}
