import { Component, OnInit } from '@angular/core';
import { TicketHistoryModel } from '../Models/BookingticketHistory';
import { BookingDetailService } from '../Services/booking-detail.service';

@Component({
  selector: 'app-search-ticket-pnr',
  templateUrl: './search-ticket-pnr.component.html',
  styleUrls: ['./search-ticket-pnr.component.css']
})
export class SearchTicketPnrComponent implements OnInit {

  constructor(private _ticket:BookingDetailService) { }

  ngOnInit(): void {
  }

  modalText:string="";
modalHeader:string="";
pnrNumber:string="";
ticketHistory:TicketHistoryModel = new TicketHistoryModel();
isShowNoResultFound:boolean=false;

DisplayModalPopup(modalHeader:string, modaltext:string)
{
  this.modalHeader = modalHeader;
  this.modalText=modaltext;
  document.getElementById("btnLaunchModal")?.click();
}

GetTicketHistory()
{
  
  this._ticket.GetTicketPnrHistory(this.pnrNumber).subscribe(res => { this.BindTicketHistoryResults(res)},
  err => { this.DisplayModalPopup("Error", err.error)});
}

BindTicketHistoryResults(response:any)
{
  this.ticketHistory = response;
  this.isShowNoResultFound = false;
}

SetNoResultFound()
{
  this.isShowNoResultFound = true;
}

ViewTicketDetails()
{
   let modalText = "PNR Number: " + this.ticketHistory.mealPlanId + "\nContact no: " + this.ticketHistory.contactNo
   +"\nCustomer address: " + this.ticketHistory.address
   +"\nBooked On: " + (new Date(this.ticketHistory.bookingDatetime)).toLocaleString()
   +"\nTravel Date: " + (new Date(this.ticketHistory.travelDate)).toLocaleString()
   +"\nSource Location: " + this.ticketHistory.sourceLocation
   +"\nDestination Location: " + this.ticketHistory.destinationLocation
   +"\nIsCancelled: " + this.ticketHistory.isCancelled
   +"\nMeal plan selected: " + this.ticketHistory.mealPlanType
   +"\n\nBooking Passenger Details";

   for(let i = 0; i < this.ticketHistory.passengerDetails.length; i++)
   {
     let seatType = this.ticketHistory.passengerDetails[i].isBusinessSeat ? "Business" : "Regular"
     modalText = modalText + "\n\nPassenger Name: " + this.ticketHistory.passengerDetails[i].passengerName
     +"\nPassenger Age: " + this.ticketHistory.passengerDetails[i].passengerAge
     +"\nPassenger Gender: " + this.ticketHistory.passengerDetails[i].genderType
     +"\nSeat No: " + this.ticketHistory.passengerDetails[i].seatNo
     +"\nSeat Type: " + seatType;
   }

   this.DisplayModalPopup("Ticket Details", modalText);
}

}
