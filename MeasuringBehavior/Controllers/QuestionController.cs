using MeasuringBehavior.Core.Models;
using MeasuringBehavior.Core.Models.Domain;
using MeasuringBehavior.Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

namespace MeasuringBehaviorMVC.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IBaseRepository<Choice> _choiceRepositoryBase;
        private readonly IBaseRepository<User> _userRepositoryBase;
        public QuestionController(IQuestionRepository questionRepository, 
            IBaseRepository<Choice> choiceRepositoryBase,IBaseRepository<User> userRepositoryBase)
        {
            _questionRepository = questionRepository;
            _choiceRepositoryBase = choiceRepositoryBase;
            _userRepositoryBase = userRepositoryBase;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StartQuestions()
        {
            return View();
        }
        public IActionResult GetQuestions(int currentPage)
        {
            var Questions =_questionRepository.GetAllQuestions();
            int TotalQuestions=Questions.Count();
            int PageSize = 1;
            int TotalPages = (int)Math.Ceiling(TotalQuestions / (double)PageSize);
            Questions=Questions.Skip((currentPage-1)*PageSize).Take(PageSize).ToList();
            QuestionVM questionVM = new QuestionVM();
            questionVM.Questions = Questions;
            questionVM.CurrentPage = currentPage;
            questionVM.TotalPages = 11;
            questionVM.PageSize= PageSize;
            return View("Questions",questionVM);
        }
        public IActionResult ScoreView()
        {
            ViewBag.Score = TempData["Score"] as int? ?? 0;
            int id = int.Parse(HttpContext.Session.GetString("UserId"));
            User user=_userRepositoryBase.GetById(id);
            user.Score= ViewBag.Score;
            _userRepositoryBase.Update(user);
            return View(user);
        }
       [HttpPost]
        public IActionResult CalculateScore([FromBody] List<int> ChoiceId)
        {
            int score = 0;
            for(int i = 0; i < ChoiceId.Count(); i++)
            {
              Choice choice= _choiceRepositoryBase.GetById(ChoiceId[i]);
                score += choice.point;
            }
            TempData["Score"] = score; 

            return Json(new { success = true });
        }
    }
}
