using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.DataAccessLayerInterfaces
{
    public interface ICommonDataAccessLayer
    {

        List<InstrumentTypeMasterViewModel> getAllInstrument();
        List<MealTypeMasterViewModel> getAllmeal();
        List<GenderTypeMasterViewModel> getAllGender();
        List<SeatTypeMasterViewModel> getAllSeat();
        List<WeekDayTypeMasterViewModel> getAllWeekday();

    }
}
