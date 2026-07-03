namespace APIEmpHub.Models
{
    public class FormPermanentEmployeeModels
    {
        public string refId { get; set; }
        public string letter_date { get; set; }
        public string fullname { get; set; }
        public string start_date { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public int include_salary { get; set; }
        public decimal salary { get; set; }
        public string salary_text { get; set; }
        public string effective_date { get; set; }
        public string description { get; set; }
        public string create_by { get; set; }
        public string create_date { get; set; }
    }
}
