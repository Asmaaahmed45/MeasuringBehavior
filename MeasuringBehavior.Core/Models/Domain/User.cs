using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(30)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int Score { get; set; }
        [StringLength(14, ErrorMessage = "SSN must be 14 number")]
        [RegularExpression(@"^[2-3]\d{13}$", ErrorMessage = "SSN must start with 2 or 3 and be 14 digits long")]
        public string? SSN { get; set; }
        public int GovernorateId { get; set; }
        public int VillageId { get; set; }
        public int RegionId { get; set; }
    }
}
