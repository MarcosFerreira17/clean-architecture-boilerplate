using MediatR;

namespace Template.Application.Features.Commands.DeleteTemplate;

public class DeleteTemplateCommand : IRequest
{
    public long Id { get; set; }
}
