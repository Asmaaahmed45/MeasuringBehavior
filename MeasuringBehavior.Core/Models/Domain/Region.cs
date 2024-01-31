using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class Region
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int VillageId { get; set; }
    }
}
