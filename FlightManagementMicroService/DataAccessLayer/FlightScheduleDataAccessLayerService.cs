using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class FlightScheduleDataAccessLayerService: IFlightScheduleDataAccessLayerService
    {
        private readonly FlightBookingDBContext db;
        public FlightScheduleDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }

        public List<FlightSchedule> getAllFlightSchedule()
        {
            List<FlightSchedule> userlist = new List<FlightSchedule>();
            userlist = db.FlightSchedules.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public bool AddFlightSchedule(FlightSchedule userMasterViewModel)
        {

            try
            {
                FlightSchedule airportmaster = new FlightSchedule();
                airportmaster.FlightId = userMasterViewModel.FlightId;
                airportmaster.DestinationId = userMasterViewModel.DestinationId;
                airportmaster.SourceId = userMasterViewModel.SourceId;
                airportmaster.EndDate = userMasterViewModel.EndDate;
                airportmaster.StartDate = userMasterViewModel.StartDate;
                airportmaster.WeekdaysIds = userMasterViewModel.WeekdaysIds;
                airportmaster.FlightScheduleDays = userMasterViewModel.FlightScheduleDays;

                db.FlightSchedules.Add(airportmaster);
                var result = db.SaveChanges();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //private FlightScheduleDay addflightschuldeday(FlightScheduleViewModelcs userMasterViewModel)
        //{ 
        //}

        public bool UpdateFlightSchedule(FlightScheduleViewModelcs userMasterViewModel)
        {

            try
            {
                if (db.FlightSchedules.Any(x => x.FlightId == userMasterViewModel.FlightId))
                {
                    var airportmaster = db.FlightSchedules.Where(x => x.FlightId == userMasterViewModel.FlightId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    airportmaster.FlightId = userMasterViewModel.FlightId;
                    airportmaster.DestinationId = userMasterViewModel.DestinationId;
                    airportmaster.SourceId = userMasterViewModel.SourceId?? airportmaster.SourceId;
                    airportmaster.IsActive = userMasterViewModel.IsActive ?? airportmaster.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.FlightSchedules.Update(airportmaster);
                    var result = db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<FindFlightsScheduleViewModel> FindFlightSchedule(FindFlightsScheduleViewModel findFlightsScheduleViewModel)
        {
            try {
                List<FindFlightsScheduleViewModel> findFlightsScheduleViewModelsList = new List<FindFlightsScheduleViewModel>();


                    var scheduledata = db.FlightSchedules.Where(x=> x.SourceId == findFlightsScheduleViewModel.SourceId && x.DestinationId == findFlightsScheduleViewModel.DestinationId && x.IsActive==true );
                // var data = db.FlightSchedules.Where(x => x.SourceId == findFlightsScheduleViewModel.SourceId && x.DestinationId == findFlightsScheduleViewModel.DestinationId -)).ToList();
                 
                var updateddata = db.FlightScheduleDays.Where(x => scheduledata.Any( y=>y.FlightScheduleId == (x.FlightScheduleId ?? default(int))) && x.IsActive==true && x.DepartureDate.Value.Date == findFlightsScheduleViewModel.Journeydate.Date).ToList();
              // var updateddata= data.Where(x => x.IsActive==true && x.FlightScheduleDays.Any(z => z.IsActive == true)).ToList();

                foreach (var item in updateddata)
                {
                    FindFlightsScheduleViewModel findFlightsScheduleView = new FindFlightsScheduleViewModel();
                    findFlightsScheduleView.FlightId = scheduledata.Where(x => x.FlightScheduleId == (item.FlightScheduleId ?? default(int))).Select(x => x.FlightId).FirstOrDefault(); ;
                    findFlightsScheduleView.SourceName = db.AirportMasters.Where(x=> scheduledata.Any(y=>(y.SourceId ?? default(int)) == x.AirportId && y.FlightScheduleId== (item.FlightScheduleId ?? default(int)))).Select(x=>x.AirportName).FirstOrDefault();
                    findFlightsScheduleView.DestinationName = db.AirportMasters.Where(x => scheduledata.Any(y => (y.DestinationId ?? default(int)) == x.AirportId && y.FlightScheduleId == (item.FlightScheduleId ?? default(int)))).Select(x => x.AirportName).FirstOrDefault(); ;
                    findFlightsScheduleView.DepartureDate = item.DepartureDate;
                    findFlightsScheduleView.ArivalDate = item.ArivalDate;
                    findFlightsScheduleView.ArrivalTime = item.ArrivalTime;
                    findFlightsScheduleView.DepartureTime = item.DepartureTime;
                    findFlightsScheduleView.FlightCode = db.FlightMasters.Where(x => scheduledata.Any(y => (y.FlightId ?? default(int)) == x.FlightId && y.FlightScheduleId == (item.FlightScheduleId ?? default(int)))).Select(x => x.FlightCode).FirstOrDefault();
                    findFlightsScheduleView.AirlineName = db.AirLineMasters.Where(x => db.FlightMasters.Any(y => (y.AirlineId ?? default(int)) == x.AirlineId && scheduledata.Any(z =>( z.FlightId ?? default(int)) == y.FlightId && z.FlightScheduleId == (item.FlightScheduleId ?? default(int))))).Select(x => x.AirlineName).FirstOrDefault();

                    findFlightsScheduleViewModelsList.Add(findFlightsScheduleView);
                }

                    return findFlightsScheduleViewModelsList;
            }
            catch (Exception ex)
            { return null; }
        }

    }
}
