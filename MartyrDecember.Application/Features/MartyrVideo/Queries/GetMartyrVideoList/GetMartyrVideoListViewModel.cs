
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList
{
    public class GetMartyrVideoListViewModel
    {
        public Guid MarVidId { get; set; }
        [Display(Name = "اسم الشهيد")]
        public string MartyrName { get; set; }
        [Display(Name = "وصف الفيديو")]
        public string Description { get; set; }
        [Display(Name = "فيديو الشهيد")]
        public byte[] VideoUrl { get; set; }
        public CategoryDtoVid CategoryVideo { get; set; }
        public string UserId { get; set; }

    }
}
