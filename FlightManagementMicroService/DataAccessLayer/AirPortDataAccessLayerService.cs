using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class AirPortDataAccessLayerService: IAirPortDataAccessLayerService
    {
        private readonly FlightBookingDBContext db;
        public AirPortDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }
        public List<AirportMaster> getAllAirPort()
        {
            List<AirportMaster> userlist = new List<AirportMaster>();
            userlist = db.AirportMasters.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public bool AddAirPort(AirportMasterViewModel userMasterViewModel)
        {

            try
            {
                AirportMaster airportmaster = new AirportMaster();
                airportmaster.AirportCode = userMasterViewModel.AirportCode;
                airportmaster.AirportName = userMasterViewModel.AirportName;
                airportmaster.Country = userMasterViewModel.Country;
                airportmaster.State = userMasterViewModel.State;
                airportmaster.City = userMasterViewModel.City;
                db.AirportMasters.Add(airportmaster);
                var result = db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAirPort(AirportMasterViewModel userMasterViewModel)
        {

            try
            {
                if (db.AirportMasters.Any(x => x.AirportId == userMasterViewModel.AirportId))
                {
                    var airportmaster = db.AirportMasters.Where(x => x.AirportId == userMasterViewModel.AirportId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    airportmaster.AirportCode = userMasterViewModel.AirportCode?? airportmaster.AirportCode;
                    airportmaster.AirportName = userMasterViewModel.AirportName?? airportmaster.AirportName;
                    airportmaster.Country = userMasterViewModel.Country?? airportmaster.Country;
                    airportmaster.State = userMasterViewModel.State?? airportmaster.State;
                    airportmaster.City = userMasterViewModel.City?? airportmaster.City;
                    airportmaster.IsActive = userMasterViewModel.IsActive ?? airportmaster.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.AirportMasters.Update(airportmaster);
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
