using MediatR;

namespace MartyrDecember_Application.Features.MartyrPicture.Commands.DeleteMartyrPicture
{
    public class DeleteMartyrPictureCommand : IRequest
    {
        public Guid MarPicId { get; set; }

    }
}
