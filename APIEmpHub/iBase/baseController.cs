using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace APIEmpHub.iBase
{
    public class baseController<TModels> : Controller
    {
        public ILogger _logger;
        public IWebHostEnvironment _webhost { get; set; }
        public IConfiguration _configuration;

        public TModels model;
        public DataSet dsData { get; set; }
        public DataTable dtData { get; set; }
        public TModels iData { get; set; }
        public List<TModels> lData { get; set; }

        public baseController()
        { 
            model = Activator.CreateInstance<TModels>();
        }
    }
}
