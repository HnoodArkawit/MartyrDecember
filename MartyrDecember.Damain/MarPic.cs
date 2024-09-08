using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MartyrDecember.Domain
{
    public class MarPic
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid MarPicId { get; set; }
        [Display(Name = "اسم الشهيد"), MaxLength(30),MinLength(3)]
        public string MartyrName { get; set; }
        [Display(Name = "تفاصيل الاستشهاد")]
        public string Description { get; set; }
        [Display(Name = "تاريخ الاستشهاد")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}",ApplyFormatInEditMode =true)]
        public DateTime DateMartyr { get; set; }
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
