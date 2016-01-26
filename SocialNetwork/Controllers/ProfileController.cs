using AutoMapper;
using BLL.Interfaces;
using Entity;
using SocialNetwork.ViewsModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IPhotoService photoService;
        public ProfileController(IUserService uS, IPhotoService photoService)
        {
            this.userService = uS;
            this.photoService = photoService;
        }


        public ActionResult Index(int id = 0)
        {
            User user;
            if (id == 0)
                user = userService.GetUserByEmail(User.Identity.Name);
            else
            {
                var MyProfile = userService.GetUserByEmail(User.Identity.Name);
                user = userService.GetUser(id);
                ViewBag.IsFriend = userService.IsFriend(MyProfile.UserId, user.UserId);
            }
            if (user == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<ProfileViewModel>(user);
            return View(viewModel);
        }

        public ActionResult AddToFriend(int id = 0)
        {
            var user = userService.GetUserByEmail(User.Identity.Name);
            var added = userService.AddFriend(user, id);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_P");
            }
            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult Friends(int id = 0)
        {
            User user;
            user = userService.GetUser(id);
            if (user == null)
                user = userService.GetUserByEmail(User.Identity.Name);
            var friends = userService.GetFriends(user.UserId);
            var mapped = Mapper.Map<IEnumerable<ProfileViewModel>>(friends);
            var viewModel = new FriendsViewModel()
            {
                Users = mapped,
                IsFriends = true
            };
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            var users = userService.Search(search);
            var searched = Mapper.Map<IEnumerable<ProfileViewModel>>(users);

            var me = userService.GetUserByEmail(User.Identity.Name);
            var friends = userService.GetFriends(me.UserId).ToList();
            friends.Add(me);

            foreach (var s in searched)
                for (int i = 0; i < friends.Count; i++)
                    if (friends[i].UserId == s.UserId)
                    {
                        s.IsFriend = true;
                        friends.Remove(friends[i]);
                        break;
                    }

            var viewModel = new FriendsViewModel()
            {
                Users = searched,
                IsFriends = false
            };
            ViewBag.Title = "Search";

            return View("Friends", viewModel);
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase image)
        {
            if (image != null && (image.ContentType == "image/jpg" || image.ContentType == "image/png" || image.ContentType == "image/jpeg"))
            {
                var img = new Photo()
                {
                    MimeType = image.ContentType,
                    Data = new byte[image.ContentLength]
                };
                image.InputStream.Read(img.Data, 0, image.ContentLength);
                photoService.AddAvatarToUser(img, User.Identity.Name);

                if (Request.IsAjaxRequest())
                { }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public FileContentResult GetImage(int PhotoId)
        {
            var img = photoService.GetPhoto(PhotoId);
            if (img != null)
            {
                return File(img.Data, img.MimeType);
            }
            else
            {
                return null;
            }
        }
    }
}