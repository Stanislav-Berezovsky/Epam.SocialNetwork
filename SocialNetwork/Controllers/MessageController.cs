using AutoMapper;
using BLL.Interfaces;
using Entity;
using SocialNetwork.ViewsModels;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using SocialNetwork.Hubs;

namespace SocialNetwork.Controllers
{
    [System.Web.Mvc.Authorize]
    public class MessageController : Controller
    {
        private IMessageService messageService;
        private IUserService userService;
        public MessageController(IMessageService ms, IUserService us)
        {
            this.messageService = ms;
            this.userService = us;
        }

        [HttpGet]
        public ActionResult SendMessage(int id = 0)
        {
            User user;
            user = userService.GetUser(id);
            if (user == null)
                return HttpNotFound();
            var companion = Mapper.Map<ProfileViewModel>(user);
            var me = Mapper.Map<ProfileViewModel>(userService.GetUserByEmail(User.Identity.Name));
            var messages = messageService.GetMessages(me.UserId, companion.UserId);
            var view = new SendMessageViewModel()
            {
                Messages = messages,
                I = me,
                Companion = companion
            };
            return View(view);
        }

        [HttpPost]
        public ActionResult SendMessage(int from, int to, string text)
        {
            var u_from = userService.GetUser(from);
            var u_to = userService.GetUser(to);
            var message = new Message()
            {
                UserTo = u_to,
                UserFrom = u_from,
                Text = text
            };

            messageService.AddMessage(message);
            var hub = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
            hub.Clients.Group(u_to.UserEmail).sendMessage(u_from.UserName,message.Text,u_from.UserPhotoId);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_messPartial", message);
            }
            return RedirectToAction("SendMessage", new { id = to });
        }
    }
}