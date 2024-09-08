using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MartyrDecember.Application.Features.Profile.Queries.GetProfileList
{
    public class GetProfileListViewModel
    {
        public Guid ProfileId { get; set; }
        [Display(Name = "صورة الشهيد")]
        public byte[] ImageUrl { get; set; }
        public CategoryDtoProfile CategoryDtoProfile { get; set; }
        public string UserId { get; set; }

    }
}
