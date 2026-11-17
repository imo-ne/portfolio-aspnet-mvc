using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_IB.Models;
using Web_IB.Services;

namespace Web_IB.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly MessageService _messageService;

        public MessagesController(MessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            int me = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var inbox = _messageService.GetInbox(me);
            return View(inbox);
        }

        [HttpGet]
        public IActionResult Send(int toId)
        {
            var vm = _messageService.BuildSendVm(toId);
            if (vm == null) return NotFound();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Send(SendMessageViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            int me = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _messageService.Send(me, model);

            return RedirectToAction("Index");
        }
    }
}
