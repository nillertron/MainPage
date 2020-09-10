using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using DataAcces;
using Model;

namespace MainPage.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        IWebHostEnvironment host;
        IRepository<MS_Picture> pictureRepo;
        public ImageController(IWebHostEnvironment host, IRepository<MS_Picture> pictureRepo)
        {
            this.host = host;
            this.pictureRepo = pictureRepo;
        }
        [HttpPost("Upload")]
        public async Task<IActionResult>UploadToServer([FromForm] IFormFile[] file)
        {
            var list = new List<string>();
            if (file == null)
                list.Add("null");
            try
            {
                foreach(var f in file)
                {
                    var fileName = f.FileName;
                    var extension = Path.GetExtension(fileName);
                    fileName = Guid.NewGuid().ToString();
                    fileName += extension;
                    var path = Path.Combine(host.WebRootPath, "imag", "portfolio/");
                    path += fileName;
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await f.CopyToAsync(fs);
                    }
                    list.Add("http://nillertron.com/imag/portfolio/" + fileName);
                }
              
            }
            catch(Exception ex)
            {
                list.Add(ex.Message);
            }

            return Ok(list);

        }
    }
}
