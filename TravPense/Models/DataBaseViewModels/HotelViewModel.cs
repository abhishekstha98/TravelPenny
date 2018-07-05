using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravPense.Models.DataBaseViewModels
{
    public class HotelViewModel
    {
        public string HotelId { get; set; }
        public string HotelName { get; set; }
        public string Destinatino { get; set; }
        public string Contact { get; set; }
        public Int64 MinPPP { get; set; }
        public Int64 MaxPPP { get; set; }
    }
}
