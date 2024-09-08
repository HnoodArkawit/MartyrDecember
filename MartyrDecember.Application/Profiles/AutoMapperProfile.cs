using AutoMapper;
using MartyrDecember.Application.Features.MartyrVideo.Commands.CreateMartyrVideo;
using MartyrDecember.Application.Features.MartyrVideo.Commands.DeleteMartyrVideo;
using MartyrDecember.Application.Features.MartyrVideo.Commands.UpdateMartyrVideo;
using MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoDetail;
using MartyrDecember.Application.Features.MartyrVideo.Queries.GetMartyrVideoList;
using MartyrDecember.Application.Features.Profile.Commands.CreateProfile;
using MartyrDecember.Application.Features.Profile.Commands.DeleteProfile;
using MartyrDecember.Application.Features.Profile.Commands.UpdateProfile;
using MartyrDecember.Application.Features.Profile.Queries.GetProfileList;
using MartyrDecember.Application.Features.SayMartyr.Commands.CreateSay;
using MartyrDecember.Application.Features.SayMartyr.Commands.DeleteSay;
using MartyrDecember.Application.Features.SayMartyr.Commands.UpdateSay;
using MartyrDecember.Application.Features.SayMartyr.Queries.GetSayList;
using MartyrDecember.Damain;
using MartyrDecember.Domain;
using MartyrDecember_Application.Features.MartyrPicture.Commands.CreateMartyrPicture;
using MartyrDecember_Application.Features.MartyrPicture.Commands.DeleteMartyrPicture;
using MartyrDecember_Application.Features.MartyrPicture.Commands.UpdateMartyrPicture;
using MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureDetail;
using MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureList;

namespace MartyrDecember_Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MarPic, GetMartyrPictureListViewModel>().ReverseMap();
            CreateMap<MarPic, GetMartyrPictureDetailViewModel>().ReverseMap();
            CreateMap<MarPic, CategoryDto>().ReverseMap();
            CreateMap<MarPic, CreateMartyrPictureCommand>().ReverseMap();
            CreateMap<MarPic, UpdateMartyrPictureCommand>().ReverseMap();
            CreateMap<MarPic, DeleteMartyrPictureCommand>().ReverseMap();

            CreateMap<MarVid, GetMartyrVideoListViewModel>().ReverseMap();
            CreateMap<MarVid, GetMartyrVideoDetailViewModel>().ReverseMap();
            CreateMap<MarVid, CategoryDtoVid>().ReverseMap();
            CreateMap<MarVid, CreateMartyVideoCommand>().ReverseMap();
            CreateMap<MarVid, UpdateMartyrVideoCommand>().ReverseMap();
            CreateMap<MarVid, DeleteMartyrVideoCommand>().ReverseMap();

            CreateMap<SayMartyrs, GetSayListViewModel>().ReverseMap();
            //CreateMap<SayMartyrs, GetSayDetailViewModel>().ReverseMap();
            CreateMap<SayMartyrs, CategorySayMartyr>().ReverseMap();
            CreateMap<SayMartyrs, CreateSayMartyCommand>().ReverseMap();
            CreateMap<SayMartyrs, UpdateSayCommand>().ReverseMap();
            CreateMap<SayMartyrs, DeleteSayCommand>().ReverseMap();

            CreateMap<ProfilePicture, GetProfileListViewModel>().ReverseMap();
            //CreateMap<SayMartyrs, GetSayDetailViewModel>().ReverseMap();
            CreateMap<ProfilePicture, CategoryDtoProfile>().ReverseMap();
            CreateMap<ProfilePicture, CreateProfileCommand>().ReverseMap();
            CreateMap<ProfilePicture, UpdateProfileCommand>().ReverseMap();
            CreateMap<ProfilePicture, DeleteProfileCommand>().ReverseMap();
        }
    }
}
