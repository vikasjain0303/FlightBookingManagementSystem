using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class DiscountMasterDataAccessLayerService: IDiscountMasterDataAccessLayerServiceInterface
    {
        private readonly FlightBookingDBContext db;
        public DiscountMasterDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }
        public List<DiscountMaster> getAllDiscountdetails()
        {
            List<DiscountMaster> userlist = new List<DiscountMaster>();
            userlist = db.DiscountMasters.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public bool AddDiscountDetails(DiscountMasterViewModel userMasterViewModel)
        {

            try
            {
                DiscountMaster discountmaster = new DiscountMaster();
                discountmaster.DiscountCode = userMasterViewModel.DiscountCode;
                discountmaster.MaximumDiscount = userMasterViewModel.MaximumDiscount;
                
                db.DiscountMasters.Add(discountmaster);
                var result = db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateDiscounDetailst(DiscountMasterViewModel userMasterViewModel)
        {

            try
            {
                if (db.DiscountMasters.Any(x => x.DiscountId == userMasterViewModel.DiscountId))
                {
                    var discountmaster = db.DiscountMasters.Where(x => x.DiscountId == userMasterViewModel.DiscountId).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    //DiscountMaster discountmaster = new DiscountMaster();
                    discountmaster.DiscountCode = userMasterViewModel.DiscountCode?? discountmaster.DiscountCode;
                    discountmaster.MaximumDiscount = userMasterViewModel.MaximumDiscount ?? discountmaster.MaximumDiscount;

                    discountmaster.IsActive = userMasterViewModel.IsActive ?? discountmaster.IsActive;
                    //userMaster. = userMasterViewModel.FullName;
                    db.DiscountMasters.Update(discountmaster);
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
