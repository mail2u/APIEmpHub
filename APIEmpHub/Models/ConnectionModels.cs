using APIEmpHub.Utility.Helper;

namespace APIEmpHub.Models
{
    public class ConnectionModels
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Encrypt { get; set; }

        public string GetConnectionString()
        {
            if(this.Encrypt.ToLower() == "true")
            {
                this.UserId = HelperEncrypt.Decrypt(this.UserId);
                this.Password = HelperEncrypt.Decrypt(this.Password);
            }

            return String.Format("Server={0};Database={1};User Id={2};Password={3};", this.Server, this.Database, this.UserId, this.Password);
        }
    }
}
