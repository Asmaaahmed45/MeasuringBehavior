using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SSN { get; set; }
        public string Governorate { get; set; }
        public string Village { get; set; }
        public string Region { get; set; }
    }
}
