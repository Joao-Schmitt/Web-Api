using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gear.Domain.Notifications;
using System.Linq;

namespace Gear.WebApi.Plataform.Controllers
{
    public class ApiController : ControllerBase
    {
        private readonly NotificationHandler _notificationHandler;

        protected ApiController(NotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseOK(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseModelStateError()
        {
            var errors = ModelState.Values.SelectMany(x => x.Errors);

            return BadRequest(new
            {
                success = false,
                errors = errors.Select(x => x.ErrorMessage)
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseError(object error)
        {
            return BadRequest(new
            {
                success = false,
                errors = error
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseNotFound(object error)
        {
            return NotFound(new
            {
                success = false,
                errors = error
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseInternalServerError(object error)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                success = false,
                errors = error
            });
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public IActionResult ResponseNotifications()
        {
            var notifications = _notificationHandler.Notifications.Select(x => x.Message);

            return BadRequest(new
            {
                success = false,
                errors = notifications
            });
        }
    }
}