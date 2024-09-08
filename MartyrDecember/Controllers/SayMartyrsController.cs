using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Application.Features.SayMartyr.Commands.CreateSay;
using MartyrDecember.Application.Features.SayMartyr.Commands.UpdateSay;
using MartyrDecember.Damain;
using MartyrDecember.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MartyrDecember.UI.Controllers
{

    public class SayMartyrsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private Task<AuthorizationResult> result;
        private string UserId;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISayRepository _SayService;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public SayMartyrsController(IAuthorizationService authorizationService, UserManager<ApplicationUser> userManager, ISayRepository SayService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            _SayService = SayService;
            _mapper = mapper;
            _hosting = hosting;
            _userManager = userManager;
            _authorizationService = authorizationService;

        }

        // GET: SayMartyrsController
        public async Task<ActionResult> Index()
        {
            SetUser();

            if (User.IsInRole("Admin"))
            {
                // Admin
                var model = await _SayService.ListAllAsync();
                return View(model);
            }
            else
                {
                    var model = _SayService.GetSayDataByUser(UserId).Where(x => x.UserId == UserId);
                    return View(model);

                }

            }

        // GET: MarPicController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: MarPicController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSayMartyCommand sayMarty, List<IFormFile> Image)
        {
            try
            {
                SayMartyrs model = new SayMartyrs
                {
                    MartyrName = sayMarty.MartyrName,
                    Description = sayMarty.Description,
                    ImageUrl = sayMarty.ImageUrl,
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

                    await _SayService.AddAsync(model);
                    TempData["success"] = "تم الحفظ بنجاح عظم الله اجرك يا وطن";
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(sayMarty);
        }

        // GET: MarPicController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _SayService.GetByIdAsync(id);
            UpdateSayCommand UpdateSay = new UpdateSayCommand
            {
                SayId = model.SayId,
                MartyrName = model.MartyrName,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = model.UserId
            };

            return View(UpdateSay);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, UpdateSayCommand updateSayCommand, List<IFormFile> Image)
        {
            try
            {
                var files = Request.Form.Files;

                if (files.Any())
                {
                    var file = files.FirstOrDefault();

                    using var dataStream = new MemoryStream();
                    await file.CopyToAsync(dataStream);

                    updateSayCommand.ImageUrl = dataStream.ToArray();
                }

                SayMartyrs UpdateMarPic = new SayMartyrs
                    {
                        SayId = updateSayCommand.SayId,
                        MartyrName = updateSayCommand.MartyrName,
                        Description = updateSayCommand.Description,
                        ImageUrl = updateSayCommand.ImageUrl,
                    UserId = updateSayCommand.UserId
                };

                        await _SayService.UpdateAsync(UpdateMarPic);
                TempData["success"] = " تم تعديل البيانات بنجاح له الرحمة والمغفرة ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(updateSayCommand);
        }

        // POST: MarPicController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid SayId)
        {
            try
            {

                var deleteSayMartyrsCommand = new SayMartyrs() { SayId = SayId };

                await _SayService.DeleteAsync(deleteSayMartyrsCommand);
                TempData["success"] = " تمت عملية الحذف بنجاح ";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }
        private async void SetUser()
        {
            result = _authorizationService.AuthorizeAsync(User, "Admin");
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

    }
}
