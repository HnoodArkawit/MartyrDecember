using AutoMapper;
using MartyrDecember.Domain;
using MartyrDecember.Persistence;
using MartyrDecember_Application.Contracts;
using MartyrDecember_Application.Features.MartyrPicture.Commands.CreateMartyrPicture;
using MartyrDecember_Application.Features.MartyrPicture.Commands.UpdateMartyrPicture;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace MartyrDecember.UI.Controllers
{
    public class MarPicController : Controller
    {

        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMarPicRepository _MarPicVMService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;

        public MarPicController(UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService,
            IMarPicRepository MarPicVMService, IMapper mapper,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _MarPicVMService = MarPicVMService;
            _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: MarPicController
        public async Task<ActionResult> Index()
        {
            SetUser();
            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _MarPicVMService.ListAllAsync();
            return View(model);
            }
            else
            {
                var model =  _MarPicVMService.GetDataByUser(UserId).Where(x => x.UserId == UserId);
                return View(model);

            }
        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _MarPicVMService.GetByIdAsync(id);
            return View(model);
        }

        // GET: MarPicController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: MarPicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMartyrPictureCommand marPicVM, List<IFormFile> Image)
        {
            try
            {

                MarPic model = new MarPic
                {
                    MartyrName = marPicVM.MartyrName,
                    Description = marPicVM.Description,
                    ImageUrl = marPicVM.ImageUrl,
                    DateMartyr = marPicVM.DateMartyr,
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

                    await _MarPicVMService.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح عظم الله اجرك يا وطن";
                    return RedirectToAction(nameof(Index));

                }


            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(marPicVM);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _MarPicVMService.GetByIdAsync(id);
            UpdateMartyrPictureCommand UpdateMarPic = new UpdateMartyrPictureCommand
            {
                MarPicId = model.MarPicId,
                MartyrName = model.MartyrName,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                DateMartyr = model.DateMartyr,
                UserId = model.UserId
            };

            return View(UpdateMarPic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateMartyrPictureCommand updateMartyrPictureCommand, List<IFormFile> Image)
        {
            try
            {
                    var files = Request.Form.Files;

                if (files.Any())
                {
                    var file = files.FirstOrDefault();

                    using var dataStream = new MemoryStream();

                    await file.CopyToAsync(dataStream);

                    updateMartyrPictureCommand.ImageUrl = dataStream.ToArray();
                }
                    MarPic UpdateMarPic = new MarPic
                    {
                        MarPicId = updateMartyrPictureCommand.MarPicId,
                        MartyrName = updateMartyrPictureCommand.MartyrName,
                        Description = updateMartyrPictureCommand.Description,
                        ImageUrl = updateMartyrPictureCommand.ImageUrl,
                        DateMartyr = updateMartyrPictureCommand.DateMartyr,
                        UserId = updateMartyrPictureCommand.UserId
                    };

                    await _MarPicVMService.UpdateAsync(UpdateMarPic);
                TempData["success"] = " تم تعديل بيانات الشهيد بنجاح له الرحمة والمغفرة ";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateMartyrPictureCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid MarPicId)
        {
            try
            {

                var deleteMarPicCommand = new MarPic() { MarPicId = MarPicId };

                await _MarPicVMService.DeleteAsync(deleteMarPicCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        public IActionResult Search(string ShearchName)
        {
            var result = _MarPicVMService.Search().Where(a => a.MartyrName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
