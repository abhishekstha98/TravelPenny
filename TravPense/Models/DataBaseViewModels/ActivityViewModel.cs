using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models.DataBaseViewModels
{
    public class ActivityViewModel
    { 
        [Key]
        public string Activityid { get; set; }
        public string ActivityName { get; set; }
        public string Duration { get; set; }
        public string LocationType { get; set; }
        public Int64 Price { get; set; }
    }
}
