using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using System.Web.Hosting;
using System.IO;
using DexCMS.Core.Extensions;
using DexCMS.Base.WebApi.ApiModels;
using DexCMS.Core.Interfaces;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LayoutTypesController : ApiController
    {
		private ILayoutTypeRepository repository;
        private ISettingRepository settings;

		public LayoutTypesController(ILayoutTypeRepository repo, ISettingRepository settings) 
		{
			repository = repo;
            this.settings = settings;
		}

        [ResponseType(typeof(List<LayoutTypeApiModel>))]
        public List<LayoutTypeApiModel> GetLayoutypes()
        {
            return LayoutTypeApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(LayoutTypeApiModel))]
        public async Task<IHttpActionResult> GetLayoutType(int id)
        {
			LayoutType layoutType = await repository.RetrieveAsync(id);
            if (layoutType == null)
            {
                return NotFound();
            }

            return Ok(LayoutTypeApiModel.MapForClient(layoutType));
        }

        public async Task<IHttpActionResult> PutLayoutType(int id, LayoutTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.LayoutTypeID)
            {
                return BadRequest();
            }
            LayoutType layoutType = await repository.RetrieveAsync(id);
            LayoutTypeApiModel.MapForServer(apiModel, layoutType);

            if (!String.IsNullOrEmpty(apiModel.ReplacementFileName))
            {
                SaveFile(layoutType, apiModel);
            }
			await repository.UpdateAsync(layoutType, layoutType.LayoutTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(LayoutTypeApiModel))]
        public async Task<IHttpActionResult> PostLayoutType(LayoutTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LayoutType layoutType = new LayoutType();
            LayoutTypeApiModel.MapForServer(apiModel, layoutType);

            await repository.AddAsync(layoutType);

            if (!string.IsNullOrEmpty(apiModel.ReplacementFileName))
            {
                SaveFile(layoutType, apiModel);
            }
            await repository.UpdateAsync(layoutType, layoutType.LayoutTypeID);

            return CreatedAtRoute("DefaultApi", new { id = layoutType.LayoutTypeID }, LayoutTypeApiModel.MapForClient(layoutType));
        }

        [ResponseType(typeof(LayoutTypeApiModel))]
        public async Task<IHttpActionResult> DeleteLayoutType(int id)
        {
			LayoutType layoutType = await repository.RetrieveAsync(id);
            if (layoutType == null)
            {
                return NotFound();
            }
            if (layoutType.PageContents.Count == 0)
            {
                DeleteLayoutTypeFiles(layoutType);
                await repository.DeleteAsync(layoutType);
                return Ok(LayoutTypeApiModel.MapForClient(layoutType));
            } else
            {
                return BadRequest();
            }
        }

        private void SaveFile(LayoutType item, LayoutTypeApiModel apiModel)
        {
            int id = item.LayoutTypeID;
            string uploadFolderName = "content/layoutTypes/" + id + "/";

            string uploadFolder = HostingEnvironment.MapPath("~/" + uploadFolderName);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string pictureName = item.Name.Clean();
            string extension = apiModel.ReplacementFileName.Substring(apiModel.ReplacementFileName.LastIndexOf('.'));

            if (item.ExampleImage != null)
            {
                DeleteLayoutTypeFiles(item);
            }

            //let's make sure alt is unique
            string newName = item.Name;
            GenerateUniqueName(uploadFolderName, uploadFolder, ref pictureName, extension, ref newName);
            item.Name = newName;

            //Retrieve file
            var file = System.Web.HttpContext.Current.Server.MapPath("~/Tmp/FileUploads/" + apiModel.TemporaryFileName);

            //remove special characters from file name
            string fileName = pictureName + extension;

            string fullfilePath = Path.Combine(uploadFolder, fileName);

            File.Copy(file, fullfilePath);

            File.Delete(file);
            item.ExampleImage = uploadFolderName + fileName;
        }

        private static void GenerateUniqueName(string uploadFolderName, string uploadFolder, ref string pictureName, string extension, ref string newName)
        {
            //layoutType doesn't exist, let's make sure it is unique
            int? appendNumber = null;
            bool foundUnused = false;
            do
            {
                //let's make sure the new layoutType we are about to save doesn't already exist
                string testFile = uploadFolderName + pictureName + appendNumber + extension;

                //save file path
                string testPath = Path.Combine(uploadFolder,
                    Path.GetFileName(testFile));

                //test if file exists, if so, increment the number and repeat the loop
                if (File.Exists(testPath))
                {
                    if (appendNumber != null)
                    {
                        appendNumber++;
                    }
                    else
                    {
                        appendNumber = 1;
                    }
                }
                else
                {
                    //file does not exist, so we have a unique name to use
                    pictureName += appendNumber;
                    foundUnused = true;
                    newName += appendNumber;
                }
            } while (!foundUnused);
        }

        private void DeleteLayoutTypeFiles(LayoutType item)
        {
            DeleteFile(item.ExampleImage);
        }

        private void DeleteFile(string file)
        {
            if (!String.IsNullOrEmpty(file))
            {
                string oldFile = HostingEnvironment.MapPath("~/" + file);
                if (File.Exists(oldFile))
                {
                    File.Delete(oldFile);
                }
            }
        }

    }


}