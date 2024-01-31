using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Choice> Choices { get; set; }
    }
}
