namespace APIEmpHub.Models
{
    public class FormBenefitFundModels
    {
        public string refId { get; set; }
        public string fullname { get; set; }
        public string idcard { get; set; }
        public string mode { get; set; }
        public int total { get; set; }
        public string benefitname1 { get; set; }
        public string benefitrelation1 { get; set; }
        public decimal benefitpercent1 { get; set; }
        public string benefitname2 { get; set; }
        public string benefitrelation2 { get; set; }
        public decimal benefitpercent2 { get; set; }
        public string benefitname3 { get; set; }
        public string benefitrelation3 { get; set; }
        public decimal benefitpercent3 { get; set; }
        public string create_by { get; set; }
    }
}
