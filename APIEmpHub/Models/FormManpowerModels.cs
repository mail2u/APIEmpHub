namespace APIEmpHub.Models
{
    public class FormManpowerModels
    {
        public string refId { get; set; }
        public string position { get; set; }
        public string department { get; set; }
        public string required_date { get; set; }
        public int num_employee { get; set; }
        public string type_employment { get; set; }
        public string type_employment_desc { get; set; }
        public string type_requirement { get; set; }
        public string type_reason { get; set; }
        public string type_reason_additional_hire_desc { get; set; }
        public string type_reason_replacement_desc { get; set; }
        public string description_work { get; set; }
        public string sex { get; set; }
        public int age { get; set; }
        public string education { get; set; }
        public string major { get; set; }
        public string knowledge { get; set; }
        public int skill_language { get; set; }
        public string skill_language_desc { get; set; }
        public int skill_computer { get; set; }
        public string skill_computer_desc { get; set; }
        public int skill_other { get; set; }
        public string skill_other_desc { get; set; }
        public string type_experience { get; set; }
        public string type_experience_yes_desc { get; set; }
        public string type_experience_other_desc { get; set; }
        public string userId { get; set; } = "";
        public string create_by { get; set; } = "";
    }
}
