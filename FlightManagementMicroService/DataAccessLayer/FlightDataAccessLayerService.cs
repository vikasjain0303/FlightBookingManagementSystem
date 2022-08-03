using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class FlightDataAccessLayerService: IFlightDataAccessLayerService
    {
        private readonly FlightBookingDBContext db;
        public FlightDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }
        public List<FlightMasterViewModel> getAllFlight()
        {
            try
            {
                List<FlightMasterViewModel> flightmasterList = new List<FlightMasterViewModel>();
                var flights = db.FlightMasters.Where(x => x.IsActive == true).ToList();

                foreach (var flight in flights)
                {
                    FlightMasterViewModel flightMaster = new FlightMasterViewModel();
                    flightMaster.FlightId = flight.FlightId;
                    flightMaster.FlightCode = flight.FlightCode;
                    flightMaster.AirlineId = flight.AirlineId;
                    flightMaster.AirLineName = db.AirLineMasters.Where(z => z.AirlineId == flight.AirlineId).Select(z => z.AirlineName).FirstOrDefault();
                    flightMaster.InstrumentId = flight.InstrumentId;
                    flightMaster.InstrumentTypeName = db.InstrumentTypeMasters.Where(z => z.InstrumentId == flight.InstrumentId).Select(z => z.InstrumentName).FirstOrDefault();
                    flightmasterList.Add(flightMaster);
                }
                // userlist= db.UserMasters.ToList();
                return flightmasterList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool AddFlight(FlightMasterViewModel userMasterViewModel)
        {

            try
            {
                FlightMaster airportmaster = new FlightMaster();
                airportmaster.FlightCode = userMasterViewModel.FlightCode;
                airportmaster.AirlineId = userMasterViewModel.AirlineId;
                airportmaster.InstrumentId = userMasterViewModel.InstrumentId;
               
                db.FlightMasters.Add(airportmaster);
                var result = db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateFlight(FlightMasterViewModel userMasterViewModel)
        {

            try
            {
                if (db.FlightMasters.Any(x => x.FlightId == userMasterViewModel.FlightId))
                {
                    var airportmaster = db.FlightMasters.Where(x => x.FlightId == userMasterViewModel.FlightId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    airportmaster.FlightCode = userMasterViewModel.FlightCode?? airportmaster.FlightCode;
                    airportmaster.AirlineId = userMasterViewModel.AirlineId?? airportmaster.AirlineId;
                    airportmaster.InstrumentId = userMasterViewModel.InstrumentId?? airportmaster.InstrumentId;
                    airportmaster.IsActive = userMasterViewModel.IsActive ?? airportmaster.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.FlightMasters.Update(airportmaster);
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
    }
}
