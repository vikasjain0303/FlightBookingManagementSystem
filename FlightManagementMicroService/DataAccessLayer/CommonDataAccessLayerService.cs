using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayer
{
    public class CommonDataAccessLayerService: ICommonDataAccessLayer
    {
        private readonly FlightBookingDBContext db;
        public CommonDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }
        public List<InstrumentTypeMasterViewModel> getAllInstrument()
        {
            List<InstrumentTypeMasterViewModel> instrumentList = new List<InstrumentTypeMasterViewModel>();
            var userlist = db.InstrumentTypeMasters.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            foreach (var instument in userlist)
            {
                InstrumentTypeMasterViewModel instrumentType = new InstrumentTypeMasterViewModel();
                instrumentType.InstrumentId = instument.InstrumentId;
                instrumentType.InstrumentName = instument.InstrumentName;
                instrumentList.Add(instrumentType);
            }
            return instrumentList;
        }
        
        public List<MealTypeMasterViewModel> getAllmeal()
        {
            List<MealTypeMasterViewModel> mealtypelist = new List<MealTypeMasterViewModel>();
            var userlist = db.MealTypeMasters.Where(x => x.IsActive == true).ToList();

            // userlist= db.UserMasters.ToList();
            foreach (var meal in userlist)
            {
                MealTypeMasterViewModel mealtype = new MealTypeMasterViewModel();
                mealtype.MealTypeId = meal.MealTypeId;
                mealtype.MealTypeName = meal.MealTypeName;
                mealtypelist.Add(mealtype);
            }
            return mealtypelist;
        }
        public List<GenderTypeMasterViewModel> getAllGender()
        {
            List<GenderTypeMasterViewModel> gendertypelist = new List<GenderTypeMasterViewModel>();
           var userlist = db.GenderTypeMasters.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            foreach (var gender in userlist)
            {
                GenderTypeMasterViewModel gendertype = new GenderTypeMasterViewModel();
                gendertype.GenderId = gender.GenderId;
                gendertype.GenderType = gender.GenderType;
                gendertypelist.Add(gendertype);
            }
            return gendertypelist;
        }
        public List<SeatTypeMasterViewModel> getAllSeat()
        {
            List<SeatTypeMasterViewModel> seattypelist = new List<SeatTypeMasterViewModel>();
           var userlist = db.SeatTypeMasters.ToList();
            // userlist= db.UserMasters.ToList();

            foreach(var seat in userlist)
            {
                SeatTypeMasterViewModel seattype = new SeatTypeMasterViewModel();
                seattype.SeatTypeId = seat.SeatTypeId;
                seattype.SeatTypeName = seat.SeatTypeName;
                seattypelist.Add(seattype);
            }
            return seattypelist;
        }
        public List<WeekDayTypeMasterViewModel> getAllWeekday()
        {
            List<WeekDayTypeMasterViewModel> weekdaylist = new List<WeekDayTypeMasterViewModel>();
            var userlist = db.WeekDayMasters.Where(x => x.IsActive == true).ToList();

            foreach (var week in userlist)
            {
                WeekDayTypeMasterViewModel weekday = new WeekDayTypeMasterViewModel();
                weekday.WeekDayId = week.WeekDayId;
                weekday.WeekdayName = week.WeekdayName;
                weekdaylist.Add(weekday);
            }
            // userlist= db.UserMasters.ToList();
            return weekdaylist;
        }
    }
}
