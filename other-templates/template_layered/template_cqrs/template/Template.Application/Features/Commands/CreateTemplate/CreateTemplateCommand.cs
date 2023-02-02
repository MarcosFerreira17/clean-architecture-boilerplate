using MediatR;

namespace Template.Application.Features.Commands.CreateTemplate;

public class CreateTemplateCommand : IRequest<long>
{
    public string Example { get; set; }
}
