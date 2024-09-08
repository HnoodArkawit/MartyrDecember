using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.CreateMartyrPicture
{
    public class CreateMartyrPictureCommand : IRequest<Guid>
    {
        [Display(Name = "اسم الشهيد"), MaxLength(30), MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "تفاصيل الاستشهاد"),MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "تاريخ الاستشهاد")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}", ApplyFormatInEditMode = true)]
        public DateTime DateMartyr { get; set; }
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
