using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.MartyrVideo.Commands.CreateMartyrVideo
{
    public class CreateMartyVideoCommand : IRequest<Guid>
    {
        [Display(Name = "اسم الشهيد"), MaxLength(30), MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "وصف الفيديو"), MaxLength(500), MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "فيديو الشهيد")]
        public byte[] VideoUrl { get; set; }
        public string UserId { get; set; }

    }
}
