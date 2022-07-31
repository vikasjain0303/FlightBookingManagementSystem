using FlightManagementMicroService.BusinessLayerInterfaces;
using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using FlightManagementMicroService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementMicroService.BusinessLogic
{
    public class FlightScheduleBusinessLayerService : IFlightScheduleBusinessLayerService
    {

        private readonly IFlightScheduleDataAccessLayerService IflightScheduleDataAccessLayerService;

        public FlightScheduleBusinessLayerService(IFlightScheduleDataAccessLayerService _IFlightScheduleDataAccessLayerService)
        {
            this.IflightScheduleDataAccessLayerService = _IFlightScheduleDataAccessLayerService;
        }

        public List<FlightSchedule> getAllFlightSchedule()
        {
            List<FlightSchedule> userlist = new List<FlightSchedule>();

            userlist = IflightScheduleDataAccessLayerService.getAllFlightSchedule();
            return userlist;
        }
        public bool AddFlightSchedule(FlightScheduleViewModelcs userMasterViewModel)
        {
            try
            {
                FlightSchedule flightSchedule = new FlightSchedule();
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var weekdayid = Array.ConvertAll(userMasterViewModel.WeekdaysIds.Split(","), int.Parse);


                if (userMasterViewModel.StartDate.HasValue && userMasterViewModel.EndDate.HasValue)
                {

                    flightSchedule.FlightId = userMasterViewModel.FlightId;
                    flightSchedule.DestinationId = userMasterViewModel.DestinationId;
                    flightSchedule.SourceId = userMasterViewModel.SourceId;
                    flightSchedule.EndDate = userMasterViewModel.EndDate;
                    flightSchedule.StartDate = userMasterViewModel.StartDate;
                    flightSchedule.WeekdaysIds = userMasterViewModel.WeekdaysIds;

                    //var totalday = (userMasterViewModel.EndDate.Value - userMasterViewModel.StartDate.Value).TotalDays;
                    //for (int i = 0; i < totalday; i++)
                    //{
                    for (DateTime date = userMasterViewModel.StartDate.Value; userMasterViewModel.EndDate.Value.CompareTo(date) > 0; date = date.AddDays(1.0))
                    {
                        // logic here

                        for (int j = 0; j < weekdayid.Length; j++)
                        {
                            if ((int)date.DayOfWeek == weekdayid[j])
                            {

                                FlightScheduleDay flightScheduleday = new FlightScheduleDay();
                                flightScheduleday.ArivalDate = date.Date;//.Value.ToString("HH:mm");
                                flightScheduleday.DepartureTime = userMasterViewModel.DepartureTime;//.Value.ToString("HH:mm");
                                flightScheduleday.ArrivalTime = userMasterViewModel.ArrivalTime;
                                flightScheduleday.DepartureDate = date.Date;
                                flightScheduleday.TotalSeatBusinessClass = userMasterViewModel.TotalSeatBusinessClass;
                                flightScheduleday.TotalSeatRegularClass = userMasterViewModel.TotalSeatRegularClass;
                                flightScheduleday.VacantSeatBusinessClass = userMasterViewModel.VacantSeatBusinessClass;
                                flightScheduleday.VacantSeatRegularClass = userMasterViewModel.VacantSeatRegularClass;
                                flightScheduleday.TicketCost = userMasterViewModel.TicketCost;
                                flightScheduleday.RowNo = userMasterViewModel.RowNo;
                                flightScheduleday.WeekdayId = weekdayid[j];
                                flightScheduleday.MealTypeId = userMasterViewModel.MealTypeId;

                                flightSchedule.FlightScheduleDays.Add(flightScheduleday);
                            }
                        }
                        //userMasterViewModel.StartDate.Value.AddDays(1);
                        // if()
                    }
                }

                var result = IflightScheduleDataAccessLayerService.AddFlightSchedule(flightSchedule);

                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateFlightSchedule(FlightScheduleViewModelcs userMasterViewModel)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                var result = IflightScheduleDataAccessLayerService.UpdateFlightSchedule(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteFlightSchedule(int FlightScheduleId)
        {
            try
            {
                // UserMaster usermaster = new UserMaster();
                // usermaster = userMasterViewModel;
                FlightScheduleViewModelcs userMasterViewModel = new FlightScheduleViewModelcs();
                userMasterViewModel.FlightScheduleId = FlightScheduleId;
                userMasterViewModel.IsActive = false;
                var result = IflightScheduleDataAccessLayerService.UpdateFlightSchedule(userMasterViewModel);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FindFlightsScheduleViewModel> FindFlightSchedule(FindFlightsScheduleViewModel findFlightsScheduleViewModel)
        {
            try { 
            List<FindFlightsScheduleViewModel> userlist = new List<FindFlightsScheduleViewModel>();

            userlist = IflightScheduleDataAccessLayerService.FindFlightSchedule(findFlightsScheduleViewModel);
            return userlist;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
