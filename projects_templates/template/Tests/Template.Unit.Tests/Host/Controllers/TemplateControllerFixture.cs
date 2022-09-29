using Moq;
using Template.Application.Exceptions;
using Template.Domain.Dtos;
using Template.Application.Interfaces;
using Template.Presentation.Controllers;
using Template.Tests.Helpers.MockData;

namespace Template.Tests.Host.Controllers;

public static class TemplateControllerFixture
{
    public static Mock<TemplateController> TemplateControllerMock()
    {
        var service = new Mock<ITemplateService>();
        service.Setup(s => s.GetAll()).Throws(new Exception());
        service.Setup(s => s.GetById(It.IsAny<long>())).Throws(new NotFoundException());
        service.Setup(s => s.Create(It.IsAny<TemplateDto>())).Throws(new BadRequestException());
        service.Setup(s => s.Update(It.IsAny<long>(), It.IsAny<TemplateDto>())).Throws(new NotFoundException());
        service.Setup(s => s.Delete(It.IsAny<long>())).Throws(new NotFoundException());

        return new Mock<TemplateController>(service.Object)
        {
            CallBase = true,
        };
    }
}
