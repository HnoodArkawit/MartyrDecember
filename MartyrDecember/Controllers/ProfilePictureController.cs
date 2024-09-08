using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Application.Features.Profile.Commands.CreateProfile;
using MartyrDecember.Application.Features.Profile.Commands.UpdateProfile;
using MartyrDecember.Damain;
using MartyrDecember.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MartyrDecember.UI.Controllers
{

    public class ProfilePictureController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProfileRepository _ProfileService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public ProfilePictureController(UserManager<ApplicationUser> userManager, IProfileRepository ProfileService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _ProfileService = ProfileService;
           _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
        }

        // GET: ProfilePictureController
        public async Task<ActionResult> Index()
        {
            var model = await _ProfileService.ListAllAsync();
            return View(model);
        }


        // GET: ProfilePictureController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ProfilePictureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateProfileCommand profileImage, List<IFormFile> Image)
        {
            try
            {
                ProfilePicture model = new ProfilePicture
                {
                    ImageUrl = profileImage.ImageUrl,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();

                    //check file size and extension

                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        model.ImageUrl = dataStream.ToArray();
                    }

                    await _ProfileService.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(profileImage);
        }

        // GET: ProfilePictureController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _ProfileService.GetByIdAsync(id);
            UpdateProfileCommand UpdateMarPic = new UpdateProfileCommand
            {
                ProfileId = model.ProfileId,
                ImageUrl = model.ImageUrl,
                UserId=model.UserId

            };

            return View(UpdateMarPic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateProfileCommand updateProfileCommand)
        {
            try
            {

                    var files = Request.Form.Files;

                if (files.Any())
                {
                    var file = files.FirstOrDefault();

                    using var dataStream = new MemoryStream();

                    await file.CopyToAsync(dataStream);

                    updateProfileCommand.ImageUrl = dataStream.ToArray();
                }

                ProfilePicture Updateprofile = new ProfilePicture
                    {
                        ProfileId = updateProfileCommand.ProfileId,
                        ImageUrl = updateProfileCommand.ImageUrl,
                        UserId=updateProfileCommand.UserId
                    };

                    await _ProfileService.UpdateAsync(Updateprofile);
                TempData["success"] = "تم تعديل البيانات";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateProfileCommand);
        }

        // GET: ProfilePictureController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfilePictureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid ProfileId)
        {
            try
            {
                var deleteProfilePictureCommand = new ProfilePicture() { ProfileId = ProfileId };

                await _ProfileService.DeleteAsync(deleteProfilePictureCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
    }
}
