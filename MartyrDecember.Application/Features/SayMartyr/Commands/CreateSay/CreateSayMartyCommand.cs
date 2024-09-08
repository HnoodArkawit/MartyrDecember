using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.SayMartyr.Commands.CreateSay
{
    public class CreateSayMartyCommand : IRequest<Guid>
    {
        [Display(Name = "اسم الشهيد"), MaxLength(30), MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "قول الشهيد"),MinLength(10)]
        public string Description { get; set; }
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
