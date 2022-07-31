using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class AirLineMasterDataAccessLayer : IAirLineMasterDataAccessLayerService
    {

        private readonly FlightBookingDBContext db;
        public AirLineMasterDataAccessLayer(FlightBookingDBContext _db)
        {
            this.db = _db;
        }
        public List<AirLineMaster> getAllAirLine()
        {
            List<AirLineMaster> userlist = new List<AirLineMaster>();
            userlist = db.AirLineMasters.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public bool AddAirLine(AirLineMasterViewModel userMasterViewModel)
        {

            try
            {
                AirLineMaster airlinemaster = new AirLineMaster();
                airlinemaster.AirlineName = userMasterViewModel.AirlineName;
                airlinemaster.AirlineCode = userMasterViewModel.AirlineCode;
                airlinemaster.ContactNo = userMasterViewModel.ContactNo;
                airlinemaster.EmailId = userMasterViewModel.EmailId;
                airlinemaster.Address = userMasterViewModel.Address;
                db.AirLineMasters.Add(airlinemaster);
                var result = db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAirLine(AirLineMasterViewModel userMasterViewModel)
        {

            try
            {
                if (db.AirLineMasters.Any(x => x.AirlineId == userMasterViewModel.AirlineId))
                {
                    var airlinemaster = db.AirLineMasters.Where(x => x.AirlineId == userMasterViewModel.AirlineId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    airlinemaster.AirlineName = userMasterViewModel.AirlineName ?? airlinemaster.AirlineName;
                    airlinemaster.AirlineCode = userMasterViewModel.AirlineCode ?? airlinemaster.AirlineCode;
                    airlinemaster.ContactNo = userMasterViewModel.ContactNo ?? airlinemaster.ContactNo;
                    airlinemaster.EmailId = userMasterViewModel.EmailId ?? airlinemaster.EmailId;
                    airlinemaster.Address = userMasterViewModel.Address ?? airlinemaster.Address;
                    airlinemaster.IsActive = userMasterViewModel.IsActive ?? airlinemaster.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.AirLineMasters.Update(airlinemaster);
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
