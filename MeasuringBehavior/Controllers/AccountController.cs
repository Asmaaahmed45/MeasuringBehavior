using MeasuringBehavior.Core.Models;
using MeasuringBehavior.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using MeasuringBehavior.Core.Models.Domain;

namespace MeasuringBehaviorMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IBaseRepository<User> _ibaseRepository;
        public AccountController(IBaseRepository<User> ibaseRepository)
        {
            _ibaseRepository = ibaseRepository;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        public IActionResult Home()
        {
            return View("HomePage");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message = "...حدث خطأ ما. أعد المحاولة من فضلك";
                return View("Login");
            }
            User user1 = _ibaseRepository.GetByEmail(x => x.Email == loginVM.Email);
            if(user1 == null)
            {
                ViewBag.Message = "..هذا المستخدم ليس لديه حساب، يرجى انشاء حساب";
                return View("Login");
            }
            bool verified = BCrypt.Net.BCrypt.Verify(loginVM.Password, user1.Password);
            if (user1 == null || verified == false)
            {
                ViewBag.Message = "..البريد الإلكتروني أو كلمة المرور خاطئة، يرجى المحاولة مرة أخرى";
                return View("Login");
            }
            loginVM.Id = user1.Id;
            HttpContext.Session.SetString("UserId",loginVM.Id.ToString());
            return View("HomePage");
        }
        [HttpPost]
        public IActionResult Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.message= "...حدث خطأ ما. أعد المحاولة من فضلك";
                return View();
            }
            var found=_ibaseRepository.IsExist(x=>x.Name == registerVM.Name&&x.Email==registerVM.Email);
            if (found)
            {
                ViewBag.message = "هذا المستخدم لديه حساب بالفعل";
                return View();
            }
            User user = new User
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password),
               
                Score=0
            };
            _ibaseRepository.Add(user);
            TempData["Success"] = "يمكنك تسجيل الدخول الآن";
            return RedirectToAction(nameof(Register));
        }
    }
}
