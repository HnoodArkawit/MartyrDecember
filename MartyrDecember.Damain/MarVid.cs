using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember.Domain
{
    public class MarVid
    {
        [System.ComponentModel.DataAnnotations.Key]
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
