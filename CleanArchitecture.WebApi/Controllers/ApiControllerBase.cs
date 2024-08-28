using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase(ISender mediatr) : ControllerBase
    {
        protected readonly ISender Mediatr = mediatr;
    }
}
