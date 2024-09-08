using MartyrDecember.Damain;
using MartyrDecember.Domain;

namespace MartyrDecember.UI.Models
{
    public class HomeViewModel
    {
        public List<SayMartyrs> Say { get; set; }
        public List<ProfilePicture> ProPic { get; set; }
        public List<MarPic> Martyr { get; set; }
        public List<MarVid> MartyrVideo { get; set; }

    }
}
