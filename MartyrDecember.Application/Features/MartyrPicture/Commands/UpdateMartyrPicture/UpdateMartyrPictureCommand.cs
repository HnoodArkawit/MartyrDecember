using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.UpdateMartyrPicture
{
    public class UpdateMartyrPictureCommand : IRequest
    {
        public Guid MarPicId { get; set; }
        [Display(Name = "اسم الشهيد"), MaxLength(30), MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "تفاصيل الاستشهاد"),MinLength(3)]
        public string Description { get; set; }
        [Display(Name = "تاريخ الاستشهاد")]
        public DateTime DateMartyr { get; set; }
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
