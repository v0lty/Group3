using Group3.Data;
using Group3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // PICTURE RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpPost]
        [Route("GetUserPictures")]
        public JsonResult GetUserPictures(string userId)
        {
            var currentUser = dbContext.Users
                  .Where(x => x.UserName == User.Identity.Name)
                  .FirstOrDefault();
            if (currentUser != null)
            {
                var pictures = this.dbContext.Pictures
                    .Where(x => x.UserId == currentUser.Id)
                    .ToArray();

                return new JsonResult(pictures);
            }

            return new JsonResult(null);
        }

        [HttpPost("UploadFile")]
        public async Task<JsonResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null)
                return new JsonResult(null);

            string rootPath = Path.Combine(hostEnvironment.ContentRootPath, "ClientApp\\public\\Pictures\\");
            string filePath = Path.Combine(rootPath, file.FileName);

            // Create Folder
            Directory.CreateDirectory(filePath.Split('/')[0] + "\\");
         
            try
            {
                // Create File
                using (Stream fileStream = new FileStream(filePath, FileMode.CreateNew))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch(Exception) {
                // Possible File already Exist due to FileMode.CreateNew
            }

            // TODO: this should now work when user is created and then directly set profile picture?
            string userName = file.FileName.Split("/").FirstOrDefault();

            var currentUser = dbContext.Users
                .Where(x => x.UserName == userName)
                .FirstOrDefault();

            Picture picture = new Picture() { Path = file.FileName, UserId = currentUser.Id };

            await dbContext.Pictures.AddAsync(picture);
            await dbContext.SaveChangesAsync();

            return new JsonResult(picture);
        }

        [HttpPost("RemovePicture")]
        public async Task<JsonResult> RemovePicture(string pictureId)
        {
            var picture = dbContext.Pictures.Where(x => x.Id == int.Parse(pictureId)).FirstOrDefault();
            if (picture != null) {

                string rootPath = Path.Combine(hostEnvironment.ContentRootPath, "ClientApp\\public\\Pictures\\");
                string filePath = Path.Combine(rootPath, picture.Path);

                dbContext.Pictures.Remove(picture);
                await dbContext.SaveChangesAsync();

                System.IO.File.Delete(filePath);
            }

            return new JsonResult(null);
        }
    }


}