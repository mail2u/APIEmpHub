using APIEmpHub.iBase;
using APIEmpHub.Utility.Helper;
using System.Data;

namespace APIEmpHub.Models
{
    public class FormNewCardModels
    {
        public string refId { get; set; }
        public string cause { get; set; }
        public string description { get; set; }
        public string create_by { get; set; }
    }
}
