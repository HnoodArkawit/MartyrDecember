using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Application.Features.MartyrVideo.Commands.CreateMartyrVideo;
using MartyrDecember.Application.Features.MartyrVideo.Commands.UpdateMartyrVideo;
using MartyrDecember.Domain;
using MartyrDecember.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MartyrDecember.UI.Controllers
{

    public class MarVidController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMarVidRepository _MarVidVMService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private Task<AuthorizationResult> result;
        private string UserId;

        public MarVidController(IAuthorizationService authorizationService,
            UserManager<ApplicationUser> userManager, 
            IMarVidRepository MarVidVMService,
            IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _MarVidVMService = MarVidVMService;
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
                var model = await _MarVidVMService.ListAllAsync();
                return View(model);
            }
            else
            {
                var model = _MarVidVMService.GetVidDataByUser(UserId).Where(x => x.UserId == UserId);
                return View(model);

            }

        }

        // GET: MarPicController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _MarVidVMService.GetByIdAsync(id);
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
        public async Task<ActionResult> Create(CreateMartyVideoCommand marPicVM, List<IFormFile> Video)
        {
            try
            {

                MarVid model = new MarVid
                {
                    MartyrName = marPicVM.MartyrName,
                    Description = marPicVM.Description,
                    VideoUrl = marPicVM.VideoUrl,
                    UserId = _userManager.GetUserAsync(User).Result.Id
                };

                if (Request.Form.Files.Count > 0)
                {
                    var file = Request.Form.Files.FirstOrDefault();

                    //check file size and extension

                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        model.VideoUrl = dataStream.ToArray();
                    }

                    await _MarVidVMService.AddAsync(model);
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
            var model = await _MarVidVMService.GetByIdAsync(id);
            UpdateMartyrVideoCommand UpdateMarPic = new UpdateMartyrVideoCommand
            {
                MarVidId = model.MarVidId,
                MartyrName = model.MartyrName,
                Description = model.Description,
                VideoUrl = model.VideoUrl,
                UserId = model.UserId
            };

            return View(UpdateMarPic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateMartyrVideoCommand updateMartyrVideoCommand, List<IFormFile> Image)
        {
            try
            {
                var files = Request.Form.Files;

                if (files.Any())
                {
                    var file = files.FirstOrDefault();

                    using var dataStream = new MemoryStream();

                    await file.CopyToAsync(dataStream);

                    updateMartyrVideoCommand.VideoUrl = dataStream.ToArray();
                }
                MarVid UpdateMarVid = new MarVid
                {
                    MarVidId = updateMartyrVideoCommand.MarVidId,
                    MartyrName = updateMartyrVideoCommand.MartyrName,
                    Description = updateMartyrVideoCommand.Description,
                    VideoUrl = updateMartyrVideoCommand.VideoUrl,
                    UserId = updateMartyrVideoCommand.UserId

                };

                await _MarVidVMService.UpdateAsync(UpdateMarVid);
                TempData["success"] = " تم تعديل البيانات بنجاح له الرحمة والمغفرة ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateMartyrVideoCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid MarVidId)
        {
            try
            {
                //string uploads = Path.Combine(_hosting.WebRootPath, @"model.ImageUrl");
                //string oldFileName = await _MarPicVMService.GetByIdAsync(id).ImageUrl;
                //string fullOldPath = Path.Combine(uploads, oldFileName);
                //System.IO.File.Delete(fullOldPath);

                var deleteMarVidCommand = new MarVid() { MarVidId = MarVidId };

                await _MarVidVMService.DeleteAsync(deleteMarVidCommand);
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
            var result = _MarVidVMService.Search().Where(a => a.MartyrName.Contains(ShearchName)).ToList();
            return View("Search", result);
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
