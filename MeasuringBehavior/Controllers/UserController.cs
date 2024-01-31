using MeasuringBehavior.Core.Models.Domain;
using MeasuringBehavior.Core.Repositories;
using MeasuringBehavior.EF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MeasuringBehaviorMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IBaseRepository<User> _ibaseRepository;
        private readonly IBaseRepository<Governorate> _GbaseRepository;
        private readonly IBaseRepository<Village> _VbaseRepository;
        private readonly IBaseRepository<Region> _RbaseRepository;
        private readonly IUserRepository _userReository;
        public UserController(IBaseRepository<User> ibaseRepository, IBaseRepository<Governorate> GbaseRepository,
          IBaseRepository<Village> VbaseRepository, IBaseRepository<Region> RbaseRepository, IUserRepository userReository)
        {
            _ibaseRepository = ibaseRepository;
            _GbaseRepository = GbaseRepository;
            _VbaseRepository = VbaseRepository;
            _RbaseRepository = RbaseRepository;
            _userReository = userReository;
        }
        public IActionResult GetAllGovernorates()
        {
            return Ok(_GbaseRepository.GetAll());
        }
        public IActionResult GetVillage(int GovernorateId)
        {
            return Ok(_VbaseRepository.GetById(x=>x.GovernorateId==GovernorateId));
        }
        public IActionResult GetRegion(int VillageId)
        {
            return Ok(_RbaseRepository.GetById(x=>x.VillageId==VillageId));
        }
        public IActionResult UserProfile([FromQuery]int id )
        {
            User user=_ibaseRepository.GetById(id);
            if (user.GovernorateId != 0)
            {
                UserVM userVM = _userReository.GetUser(id);
                ViewBag.Governorate = userVM.Governorate;
                ViewBag.Village = userVM.Village;
                ViewBag.Region = userVM.Region;
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult UserProfileAfterUpdate()
        {
            string serializedObject = TempData["UserInfoo"] as string;
            User user = System.Text.Json.JsonSerializer.Deserialize<User>(serializedObject);
            UserVM userVM = _userReository.GetUser(user.Id);
            ViewBag.Governorate = userVM.Governorate;
            ViewBag.Village = userVM.Village;
            ViewBag.Region = userVM.Region;
            return View(user);
        }
        [HttpPost]
        public IActionResult SaveProfile(User user)
        {

            _ibaseRepository.Update(user);
           TempData["Success"] = "..تم حفظ البيانات بنجاح";
           TempData["UserInfoo"] = System.Text.Json.JsonSerializer.Serialize(user);
            return RedirectToAction(nameof(UserProfileAfterUpdate));
        }
    }
}
