using AutoMapper;
using MartyrDecember.Application.Contracts;
using MartyrDecember.Models;
using MartyrDecember.UI.Models;
using MartyrDecember_Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using MartyrDecember.Domain;
using MartyrDecember.Damain;

namespace MartyrDecember.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMarPicRepository _MarPicVMService;
        private readonly IProfileRepository _ProfileRepository;
        private readonly IMarVidRepository _MarVidVMService;
        private readonly ISayRepository _SayRepository;

        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;

        public HomeController(ISayRepository SayRepository, IProfileRepository ProfileRepository, IMarVidRepository MarVidVMService, IMarPicRepository MarPicVMService, IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting, ILogger<HomeController> logger)
        {
            _logger = logger;
            this._MarPicVMService = MarPicVMService;
            this._mapper = mapper;
            _hosting = hosting;
            this._MarVidVMService = MarVidVMService;
            this._ProfileRepository = ProfileRepository;
            this._SayRepository = SayRepository;

        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Martyr = _MarPicVMService.GetAll().ToList(),
                Say = _SayRepository.GetAll().ToList()

            };

            return View(homeViewModel);
        }

        public IActionResult ViewVideo()
        {
            var ViewVideo = new HomeViewModel
            {
                MartyrVideo = _MarVidVMService.GetAll().ToList(),
                ProPic = _ProfileRepository.GetAll().ToList()

            };

            return View(ViewVideo);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> Details(Guid id)
        {
            var model = await _MarPicVMService.GetByIdAsync(id);
            return View(model);
        }

    }
}