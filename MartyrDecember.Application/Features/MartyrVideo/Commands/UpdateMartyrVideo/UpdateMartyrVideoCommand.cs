using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.UpdateMartyrVideo
{
    public class UpdateMartyrVideoCommand : IRequest
    {
        public Guid MarVidId { get; set; }
        [Display(Name = "اسم الشهيد"), MaxLength(30), MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "وصف الفيديو"), MaxLength(500), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "فيديو الشهيد")]
        public byte[] VideoUrl { get; set; }
        public string UserId { get; set; }
    }
}
