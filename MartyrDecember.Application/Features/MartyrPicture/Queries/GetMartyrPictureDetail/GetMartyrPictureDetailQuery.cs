using MediatR;

namespace MartyrDecember_Application.Features.MartyrPicture.Queries.GetMartyrPictureDetail
{
    public class GetMartyrPictureDetailQuery : IRequest<GetMartyrPictureDetailViewModel>
    {
        public Guid MarPicId { get; set; }
    }
}
