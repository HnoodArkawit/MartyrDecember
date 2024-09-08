using MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList;
using MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureList;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoDetail
{
    public class GetMartyrVideoDetailViewModel
    {
        public Guid MarVidId { get; set; }
        [Display(Name = "اسم الشهيد")]
        public string MartyrName { get; set; }
        [Display(Name = "فيديو الشهيد")]
        public byte[] VideoUrl { get; set; }
        public CategoryDtoVid CategoryVideo { get; set; }
        public string UserId { get; set; }

    }
}
