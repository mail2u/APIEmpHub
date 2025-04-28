using APIEmpHub.iBase;
using APIEmpHub.Models;
using APIEmpHub.Models;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace APIEmpHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : baseController<FileModels>
    {
        public FileController(IConfiguration configuration
           , IWebHostEnvironment hostingEnvironment
            , ILogger<FileModels> logger)
        {
            this._configuration = configuration;
            model.connection = this._configuration.GetSection("Connection").Get<ConnectionModels>();
            model.connectionString = model.connection.GetConnectionString();
            this._webhost = hostingEnvironment;
            model.webRoot = this._webhost.WebRootPath ?? this._webhost.ContentRootPath;
            this._logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(FileModels iProp)
        {
            try
            {
                model.Create(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var vData = new
            {
                refId = iProp.refId
            };

            return Ok(vData);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(FileModels iProp)
        {
            try
            {
                model.Delete(iProp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("DataList")]
        public IActionResult DataList(FileModels iProp)
        {
            lData = model.DataList(iProp);

            var vData = lData.Select(x => new
            {
                x.id
                ,
                x.refId
                ,
                x.attachCode
                ,
                x.outputname
                ,
                x.imageBase64
                ,
                x.filename
                ,
                x.filetype
                ,
                x.filesize
                ,
                x.base64
            }).ToList();

            return Ok(vData);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("DownloadFile")]
        public ActionResult DownloadFile(string refId, int id, string filename, string password)
        {
            FileModels iProp = new FileModels() { refId = refId, id = id };
            lData = model.DataList(iProp);

            return CreateDownload(lData, filename, password);
        }

        private ActionResult CreateDownload(List<FileModels> lData, String filename, String password)
        {
            if (lData.Count == 1)
            {
                if (String.IsNullOrEmpty(password))
                {
                    IFileProvider provider = new PhysicalFileProvider(lData[0].location);
                    IFileInfo fileInfo = provider.GetFileInfo(lData[0].filename);
                    var readStream = fileInfo.CreateReadStream();

                    return File(readStream, lData[0].filetype, filename ?? lData[0].outputname);
                }
                else
                {
                    return CreateZip(lData, filename, password);
                }
            }
            else
            {
                return CreateZip(lData, filename, password);
            }
        }

        private ActionResult CreateZip(List<FileModels> lData, String filename, String password)
        {
            try
            {
                string fileZip = model.webRoot + String.Format("\\{0}.zip", filename ?? DateTime.Now.ToString("yyyyMMddHHmmss")); // in production, would probably want to use a GUID as the file name so that it is unique
                FileStream fs = System.IO.File.Create(fileZip);

                using (ZipOutputStream zip = new ZipOutputStream(fs))
                {
                    byte[] data;
                    if (!String.IsNullOrEmpty(password)) { zip.Password = password; }
                    zip.SetLevel(9);

                    foreach (FileModels iFile in lData)
                    {
                        IFileProvider provider = new PhysicalFileProvider(iFile.location);
                        IFileInfo fileInfo = provider.GetFileInfo(iFile.filename);
                        Stream s = fileInfo.CreateReadStream();
                        BinaryReader br = new BinaryReader(s);
                        data = br.ReadBytes((int)s.Length);

                        var entry = new ZipEntry(iFile.outputname);
                        zip.PutNextEntry(entry);
                        zip.Write(data, 0, data.Length);
                    }

                    zip.Finish();
                    zip.Close();
                    fs.Dispose(); // must dispose of it
                    fs = System.IO.File.OpenRead(fileZip); // must re-open the zip file
                    data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    fs.Close();
                    System.IO.File.Delete(fileZip);

                    return File(data, "application/x-zip-compressed", String.Format("Download_{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"))); // recommend specifying the download file name for zips
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
    }
}
