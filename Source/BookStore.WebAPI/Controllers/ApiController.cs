using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        // sending commands and queries using ISender
        protected ISender Sender { get; }

        protected ApiController(ISender sender)
        {
            Sender = sender;
        }
    }
}
