using System.Numerics;
using System.Reflection;

namespace APIEmpHub.Models
{
    public class FormUpdateContactModels
    {
        public string refId { get; set; }
        public string userId { get; set; }
        public string registered_home { get; set; }
        public string registered_road { get; set; }
        public string registered_subDistrictCode { get; set; }
        public string registered_subDistrictName { get; set; }
        public string registered_districtCode { get; set; }
        public string registered_districtName { get; set; }
        public string registered_provinceCode { get; set; }
        public string registered_provinceName { get; set; }
        public string registered_postcode { get; set; }
        public string card_home { get; set; }
        public string card_road { get; set; }
        public string card_subDistrictCode { get; set; }
        public string card_subDistrictName { get; set; }
        public string card_districtCode { get; set; }
        public string card_districtName { get; set; }
        public string card_provinceCode { get; set; }
        public string card_provinceName { get; set; }
        public string card_postcode { get; set; }
        public string live_home { get; set; }
        public string live_road { get; set; }
        public string live_subDistrictCode { get; set; }
        public string live_subDistrictName { get; set; }
        public string live_districtCode { get; set; }
        public string live_districtName { get; set; }
        public string live_provinceCode { get; set; }
        public string live_provinceName { get; set; }
        public string live_postcode { get; set; }
        public string mobile { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string phone_office { get; set; }
        public string email_office{ get; set; }
        public string emergency_fullname { get; set; }
        public string emergency_relation { get; set; }
        public string emergency_phone { get; set; }
        public string emergency_email { get; set; }
        public string emergency_address { get; set; }
        public string create_by { get; set; }
    }
}
