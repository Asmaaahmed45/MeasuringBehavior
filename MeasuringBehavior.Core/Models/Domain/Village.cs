﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Models.Domain
{
    public class Village
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GovernorateId { get; set; }
    }
}
