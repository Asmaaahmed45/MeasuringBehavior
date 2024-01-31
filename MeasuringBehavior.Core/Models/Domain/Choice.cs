using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class Choice
    {
        [Key]
        public int ChoiceId { get; set; }
        [Required]
        public string choice { get; set; }
        [Required]
        public int point { get; set; }
        [Required, ForeignKey("Question")]
        public int QuestionId { get; set; }
    }
}
