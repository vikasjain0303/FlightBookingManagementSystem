using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.ViewModels
{
    public class FindFlightsScheduleViewModel
    {
       public DateTime Journeydate { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ArivalDate { get; set; }
        public string AirlineName { get; set; }
        public int? SourceId { get; set; }
        public int? DestinationId { get; set; }

        public string SourceName { get; set; }
        public string DestinationName { get; set; }
        public int? FlightId { get; set; }
        public string FlightCode { get; set; }

    }
}
