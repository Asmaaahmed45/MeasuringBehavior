using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeasuringBehavior.Core.Models.Domain;

namespace MeasuringBehavior.Core.Models
{
    public class QuestionVM
    {
        public List<Question> Questions { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
