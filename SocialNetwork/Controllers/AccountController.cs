using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialNetwork.Providers;
using System.Web.Security;
using BLL.Interfaces;
using SocialNetwork.ViewsModels;
using Entity;
using AutoMapper;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService uS)
        {
            this.userService = uS;
        }

        [HttpGet]
        public ActionResult Editing()
        {
            User user = userService.GetUserByEmail(User.Identity.Name);
            if (user == null)
                return HttpNotFound();
            var viewModel = Mapper.Map<EditingViewModel>(user);
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Editing(EditingViewModel eViewModel)
        {
            User user = Mapper.Map<User>(eViewModel);
            var oldUser = userService.GetUserByEmail(User.Identity.Name);
            if (string.IsNullOrEmpty(eViewModel.NewUserPassword))
            {            
                user.UserPassword = oldUser.UserPassword;
            }
            else
                user.UserPassword = eViewModel.NewUserPassword;
            user.UserPhotoId = oldUser.UserPhotoId;
            userService.UpdateUser(user);
            return RedirectToAction("Index", "Profile");

        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Email, viewModel.Password))
                //Проверяет учетные данные пользователя и управляет параметрами пользователей
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);
                    //Управляет службами проверки подлинности с помощью форм для веб-приложений
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel, HttpPostedFileBase img)
        {

            var anyUser = userService.GetUsers().Any(u => u.UserEmail.Contains(viewModel.Email));

            if (anyUser)
            {
                ModelState.AddModelError("", "User with this address already registered.");
                return View(viewModel);
            }

            if (ModelState.IsValid)
            {              

                var membershipUser = ((SocailNetworkMembershipProvider)Membership.Provider)
                    .CreateUser(viewModel);

                if (membershipUser != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, true);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Error registration.");
                }
            }
            return View(viewModel);
        }



        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}