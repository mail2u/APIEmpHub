namespace APIEmpHub.Models
{
    public class FormRequestTrainingModels
    {
        public string refId { get; set; }
        public string userId { get; set; }
        public string fullname { get; set; }
        public string position { get; set; }
        public string section { get; set; }
        public string department { get; set; }
        public string division { get; set; }
        public string license { get; set; }
        public string objectives { get; set; }
        public string organization { get; set; }
        public string location { get; set; }
        public string dt { get; set; }
        public decimal price { get; set; } = 0;
        public decimal net { get; set; } = 0;
        public int option1 { get; set; } = 0;
        public int option2 { get; set; } = 0;
        public int option3 { get; set; } = 0;
        public int option4 { get; set; } = 0;
        public string option4_desc { get; set; }
        public string create_by { get; set; }
    }
}
