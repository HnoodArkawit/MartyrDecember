using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileDetail
{
    public class GetProfileDetailViewModel
    {
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public string UserId { get; set; }

    }
}
