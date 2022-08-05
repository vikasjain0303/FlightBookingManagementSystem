using BookingManagementMicroservice.DataAccessLayerInterfaces;
using BookingManagementMicroservice.Models;
using BookingManagementMicroservice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementMicroservice.DataAccessLayer
{
    public class BookingDataAccessLayerService : IBookingDataAccessLayerSerivce
    {
        private readonly FlightBookingDBContext db;
        public BookingDataAccessLayerService(FlightBookingDBContext _db)
        {
            this.db = _db;
        }

        public List<BookingDetail> getAllBookingDetail()
        {
            List<BookingDetail> userlist = new List<BookingDetail>();
            userlist = db.BookingDetails.Where(x => x.IsActive == true).ToList();
            // userlist= db.UserMasters.ToList();
            return userlist;
        }
        public bool AddBookingDetail(BookingDetailsViewModel userMasterViewModel)
        {

            try
            {
                BookingDetail airportmaster = new BookingDetail();
                //var flightschedule = db.FlightSchedules.Where(x => x.FlightId == userMasterViewModel.FlightId).Select(x => x.FlightScheduleId).ToList();
               //var scheduledayid= db.FlightScheduleDays.Where(x => x.DepartureDate.Value.Date == userMasterViewModel.BookingDatetime.Value.Date && flightschedule.Any(y=>y==x.FlightScheduleId)).Select(x => x.FlightScheduleDayId).FirstOrDefault();
                airportmaster.FlightId = userMasterViewModel.FlightId;
                airportmaster.DestinationId = userMasterViewModel.DestinationId;
                airportmaster.SourceId = userMasterViewModel.SourceId;
                airportmaster.Address = userMasterViewModel.Address;
                airportmaster.AirLineId = userMasterViewModel.AirLineId;
                airportmaster.ContactNo = userMasterViewModel.ContactNo;
                airportmaster.FlightScheduleDayId = userMasterViewModel.FlightScheduleDayId;
                airportmaster.NoOfSeatsBook = userMasterViewModel.NoOfSeatsBook;
                airportmaster.BookingDatetime = userMasterViewModel.BookingDatetime;
                // airportmaster.PnrNumber = userMasterViewModel.PnrNumber;
                airportmaster.TotalPrice = userMasterViewModel.TotalPrice;
                airportmaster.SeatTypeId = userMasterViewModel.SeatTypeId;
                // airportmaster.PassengerDetails = userMasterViewModel.PassengerDetails;
                var pnrnumber = PnrGenerator();
                //if(db.BookingDetails.Where(x=>x.PnrNumber ==pnrnumber))
                airportmaster.PnrNumber = pnrnumber;
                if (userMasterViewModel.SeatTypeId == 1)
                {
                    var vacantseat = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).Select(x => x.VacantSeatRegularClass).FirstOrDefault();

                    foreach (var passengerDetail in userMasterViewModel.PassengerDetails)
                    {

                        PassengerDetail passengerslist = new PassengerDetail();
                        passengerslist.GenderId = passengerDetail.GenderId;
                        passengerslist.BookingId = passengerDetail.BookingId;
                        passengerslist.PassengerName = passengerDetail.PassengerName;
                        passengerslist.MealTypeId = passengerDetail.MealTypeId;
                        passengerslist.SeatNo = vacantseat;
                        vacantseat -= 1;
                        airportmaster.PassengerDetails.Add(passengerslist);
                    }
                    var flightscheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).FirstOrDefault();

                    flightscheduleday.VacantSeatRegularClass = flightscheduleday.VacantSeatRegularClass - userMasterViewModel.NoOfSeatsBook;
                    db.FlightScheduleDays.Update(flightscheduleday);
                }
                else if (userMasterViewModel.SeatTypeId == 2)
                {
                    var vacantseat = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).Select(x => x.VacantSeatBusinessClass).FirstOrDefault();

                    foreach (var passengerDetail in userMasterViewModel.PassengerDetails)
                    {
                        PassengerDetail passengerslist = new PassengerDetail();
                        passengerslist.GenderId = passengerDetail.GenderId;
                        passengerslist.BookingId = passengerDetail.BookingId;
                        passengerslist.PassengerName = passengerDetail.PassengerName;
                        passengerslist.MealTypeId = passengerDetail.MealTypeId;
                        passengerslist.SeatNo = vacantseat;
                        airportmaster.PassengerDetails.Add(passengerslist);
                        vacantseat -= 1;
                    }
                    var flightscheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).FirstOrDefault();

                    flightscheduleday.VacantSeatBusinessClass = flightscheduleday.VacantSeatBusinessClass - userMasterViewModel.NoOfSeatsBook;
                    db.FlightScheduleDays.Update(flightscheduleday);
                }

                db.BookingDetails.Add(airportmaster);
                var result = db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateBookingDetail(BookingDetailsViewModel userMasterViewModel)
        {

            try
            {
                if (db.BookingDetails.Any(x => x.PnrNumber == userMasterViewModel.PnrNumber))
                {
                    var airportmaster = db.BookingDetails.Where(x => x.PnrNumber == userMasterViewModel.PnrNumber).FirstOrDefault();
                    // UserMaster userMaster = new UserMaster();
                    // AirLineMaster airlinemaster = new AirLineMaster();
                    airportmaster.FlightId = userMasterViewModel.FlightId ?? airportmaster.FlightId;
                    airportmaster.DestinationId = userMasterViewModel.DestinationId ?? airportmaster.DestinationId;
                    airportmaster.SourceId = userMasterViewModel.SourceId ?? airportmaster.SourceId;
                    airportmaster.Address = userMasterViewModel.Address ?? airportmaster.Address;
                    airportmaster.AirLineId = userMasterViewModel.AirLineId ?? airportmaster.AirLineId;
                    airportmaster.ContactNo = userMasterViewModel.ContactNo ?? airportmaster.ContactNo;
                    airportmaster.FlightScheduleDayId = userMasterViewModel.FlightScheduleDayId ?? airportmaster.FlightScheduleDayId;
                    airportmaster.NoOfSeatsBook = userMasterViewModel.NoOfSeatsBook ?? airportmaster.NoOfSeatsBook;
                    airportmaster.PnrNumber = userMasterViewModel.PnrNumber ?? airportmaster.PnrNumber;
                    airportmaster.TotalPrice = userMasterViewModel.TotalPrice ?? airportmaster.TotalPrice;

                    if (userMasterViewModel.IsActive == false)
                    {
                        if (userMasterViewModel.SeatTypeId == 1)
                        {
                            var vacantseat = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).Select(x => x.VacantSeatRegularClass).FirstOrDefault();
                            foreach (var passsengers in airportmaster.PassengerDetails)
                            {
                                PassengerDetail passengerslist = new PassengerDetail();
                                passengerslist.IsActive = false;
                                airportmaster.PassengerDetails.Add(passengerslist);
                                vacantseat += 1;
                            }
                            var flightscheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).FirstOrDefault();

                            flightscheduleday.VacantSeatRegularClass = vacantseat;//flightscheduleday.VacantSeatBusinessClass - userMasterViewModel.NoOfSeatsBook;
                            db.FlightScheduleDays.Update(flightscheduleday);
                        }
                        else if (userMasterViewModel.SeatTypeId == 2)
                        {
                            var vacantseat = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).Select(x => x.VacantSeatBusinessClass).FirstOrDefault();
                            foreach (var passsengers in airportmaster.PassengerDetails)
                            {
                                PassengerDetail passengerslist = new PassengerDetail();
                                passengerslist.IsActive = false;
                                airportmaster.PassengerDetails.Add(passengerslist);
                                vacantseat += 1;
                            }
                            var flightscheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == userMasterViewModel.FlightScheduleDayId).FirstOrDefault();

                            flightscheduleday.VacantSeatBusinessClass = vacantseat;//flightscheduleday.VacantSeatBusinessClass - userMasterViewModel.NoOfSeatsBook;
                            db.FlightScheduleDays.Update(flightscheduleday);
                        }
                    }

                    airportmaster.IsActive = userMasterViewModel.IsActive ?? airportmaster.IsActive;

                    //userMaster. = userMasterViewModel.FullName;
                    db.BookingDetails.Update(airportmaster);
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

        public List<BookingDetailsViewModel> BookinghistoryDetails(string userEmailId)
        {
            try
            {
                List<BookingDetailsViewModel> bookingDetailsList = new List<BookingDetailsViewModel>();

                var Userid = db.UserMasters.Where(x => x.IsActive == true && x.EmailId == userEmailId).Select(x => x.UserId).FirstOrDefault();
                var bookinglist = db.BookingDetails.Where(x => x.UserId == Userid && x.IsActive==true).ToList();

                foreach (var booking in bookinglist)
                {
                    BookingDetailsViewModel bookingDetailsView = new BookingDetailsViewModel();
                    var scheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == booking.FlightScheduleDayId).FirstOrDefault()
; bookingDetailsView.BookingDatetime = booking.CreatedOn.Value.Date;
                    bookingDetailsView.PnrNumber = booking.PnrNumber;
                    bookingDetailsView.IsActive = booking.IsActive;
                    bookingDetailsView.NoOfSeatsBook = booking.NoOfSeatsBook;
                    bookingDetailsView.SourceId = booking.SourceId;
                    bookingDetailsView.DestinationId = booking.DestinationId;
                    bookingDetailsView.TotalPrice = booking.TotalPrice;
                    bookingDetailsView.SeatTypeId = booking.SeatTypeId;
                    bookingDetailsView.SeatTypeName = db.SeatTypeMasters.Where(x => x.SeatTypeId == booking.SeatTypeId).Select(x => x.SeatTypeName).FirstOrDefault();
                    bookingDetailsView.AirLineId = booking.AirLineId;
                    bookingDetailsView.BookingId = booking.BookingId;
                    bookingDetailsView.Address = booking.Address;
                    bookingDetailsView.AirLineName = db.AirLineMasters.Where(x => x.AirlineId == booking.AirLineId).Select(x => x.AirlineName).FirstOrDefault();
                    bookingDetailsView.ContactNo = booking.ContactNo;
                    bookingDetailsView.FlightScheduleDayId = booking.FlightScheduleDayId;
                    bookingDetailsView.JourneyDate = scheduleday.DepartureDate.Value.Date;
                    bookingDetailsView.DestinationName = db.AirportMasters.Where(x => x.AirportId == booking.DestinationId).Select(x => x.AirportName).FirstOrDefault();
                    bookingDetailsView.SourceName = db.AirportMasters.Where(x => x.AirportId == booking.SourceId).Select(x => x.AirportName).FirstOrDefault();

                    var passengerdetailList = db.PassengerDetails.Where(x => x.BookingId == booking.BookingId).ToList();
                    if (passengerdetailList.Count != 0)
                    {
                        foreach (var passenger in passengerdetailList)
                        {
                            PassengerDetailsViewModel passengerslist = new PassengerDetailsViewModel();
                            passengerslist.GenderId = passenger.GenderId;
                            passengerslist.GenderType = db.GenderTypeMasters.Where(x => x.GenderId == passenger.GenderId).Select(x => x.GenderType).First();
                            passengerslist.BookingId = passenger.BookingId;
                            passengerslist.PassengerName = passenger.PassengerName;
                            passengerslist.MealTypeId = passenger.MealTypeId;
                            passengerslist.MealType = db.MealTypeMasters.Where(x => x.MealTypeId == passenger.MealTypeId).Select(x => x.MealTypeName).FirstOrDefault();
                            passengerslist.SeatNo = passenger.SeatNo;
                            passengerslist.PassengerId = passenger.PassengerId;
                            passengerslist.IsActive = passenger.IsActive;
                            bookingDetailsView.PassengerDetails.Add(passengerslist);
                        }
                    }

                    //bookingDetailsView.BookingDatetime = booking.BookingDatetime;
                    //bookingDetailsView.PnrNumber = booking.PnrNumber;
                    //bookingDetailsView.NoOfSeatsBook = booking.NoOfSeatsBook;
                    //bookingDetailsView.SourceId = booking.SourceId;
                    //bookingDetailsView.AirLineId = booking.AirLineId;


                    bookingDetailsList.Add(bookingDetailsView);
                }
                return bookingDetailsList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public BookingDetailsViewModel findBookingPnrDetails(string pnrNumber)
        {
            BookingDetailsViewModel bookingDetailsView = new BookingDetailsViewModel();

           var bookingdetail= db.BookingDetails.Where(x => x.PnrNumber == pnrNumber).FirstOrDefault();

            var scheduleday = db.FlightScheduleDays.Where(x => x.FlightScheduleDayId == bookingdetail.FlightScheduleDayId).FirstOrDefault()
;            bookingDetailsView.BookingDatetime = bookingdetail.CreatedOn.Value.Date;
            bookingDetailsView.PnrNumber = bookingdetail.PnrNumber;
            bookingDetailsView.IsActive = bookingdetail.IsActive;
            bookingDetailsView.NoOfSeatsBook = bookingdetail.NoOfSeatsBook;
            bookingDetailsView.SourceId = bookingdetail.SourceId;
            bookingDetailsView.DestinationId = bookingdetail.DestinationId;
            bookingDetailsView.TotalPrice = bookingdetail.TotalPrice;
            bookingDetailsView.SeatTypeId = bookingdetail.SeatTypeId;
            bookingDetailsView.SeatTypeName = db.SeatTypeMasters.Where(x => x.SeatTypeId == bookingdetail.SeatTypeId).Select(x => x.SeatTypeName).FirstOrDefault();
            bookingDetailsView.AirLineId = bookingdetail.AirLineId;
            bookingDetailsView.BookingId = bookingdetail.BookingId;
            bookingDetailsView.Address = bookingdetail.Address;
            bookingDetailsView.AirLineName =db.AirLineMasters.Where(x=>x.AirlineId== bookingdetail.AirLineId).Select(x=>x.AirlineName).FirstOrDefault();
            bookingDetailsView.ContactNo = bookingdetail.ContactNo;
            bookingDetailsView.FlightScheduleDayId = bookingdetail.FlightScheduleDayId;
            bookingDetailsView.JourneyDate = scheduleday.DepartureDate.Value.Date;
            bookingDetailsView.DestinationName = db.AirportMasters.Where(x => x.AirportId == bookingdetail.DestinationId).Select(x => x.AirportName).FirstOrDefault();
            bookingDetailsView.SourceName = db.AirportMasters.Where(x => x.AirportId == bookingdetail.SourceId).Select(x => x.AirportName).FirstOrDefault();

            var passengerdetailList = db.PassengerDetails.Where(x => x.BookingId == bookingdetail.BookingId).ToList();
            if (passengerdetailList.Count != 0)
            {
                foreach (var passenger in passengerdetailList)
                {
                    PassengerDetailsViewModel passengerslist = new PassengerDetailsViewModel();
                    passengerslist.GenderId = passenger.GenderId;
                    passengerslist.GenderType = db.GenderTypeMasters.Where(x => x.GenderId == passenger.GenderId).Select(x => x.GenderType).First();
                    passengerslist.BookingId = passenger.BookingId;
                    passengerslist.PassengerName = passenger.PassengerName;
                    passengerslist.MealTypeId = passenger.MealTypeId;
                    passengerslist.MealType = db.MealTypeMasters.Where(x => x.MealTypeId == passenger.MealTypeId).Select(x => x.MealTypeName).FirstOrDefault();
                    passengerslist.SeatNo = passenger.SeatNo;
                    passengerslist.PassengerId = passenger.PassengerId;
                    passengerslist.IsActive = passenger.IsActive;
                    bookingDetailsView.PassengerDetails.Add(passengerslist);
                }
            }
            return bookingDetailsView;
        }
        private string PnrGenerator()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var Charsarr = new char[10];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            var pnrcount = db.BookingDetails.Where(x => x.PnrNumber == resultString).Count();
            if (pnrcount == 0)
            {
                return resultString;
            }
            else
            {
                return PnrGenerator();
            }
            //Console.WriteLine(resultString);

        }

    }
}
