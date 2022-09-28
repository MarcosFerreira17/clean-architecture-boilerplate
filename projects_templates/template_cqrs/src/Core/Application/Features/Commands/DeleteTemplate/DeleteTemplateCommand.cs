using MediatR;

namespace Application.Features.Commands.DeleteTemplate;

public class DeleteTemplateCommand : IRequest
{
    public long Id { get; set; }
}
