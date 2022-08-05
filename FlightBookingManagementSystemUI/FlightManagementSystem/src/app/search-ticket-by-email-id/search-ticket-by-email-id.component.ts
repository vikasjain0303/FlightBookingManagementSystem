import { Component, OnInit } from '@angular/core';
import { TicketHistoryModel } from '../Models/BookingticketHistory';
import { TicketHistoryByEmailModel } from '../Models/SearchTicketbyEmailIdModel';
import { BookingDetailService } from '../Services/booking-detail.service';

@Component({
  selector: 'app-search-ticket-by-email-id',
  templateUrl: './search-ticket-by-email-id.component.html',
  styleUrls: ['./search-ticket-by-email-id.component.css']
})
export class SearchTicketByEmailIdComponent implements OnInit {

  constructor(private _ticket:BookingDetailService) { }

  ngOnInit(): void {
  }
  modalText:string="";
  modalHeader:string="";
  emailId:string="";
  ticketHistoryemailid:Array<TicketHistoryByEmailModel> = new Array<TicketHistoryByEmailModel>();
  isShowNoResultFound:boolean=false;
  
  DisplayModalPopup(modalHeader:string, modaltext:string)
  {
    this.modalHeader = modalHeader;
    this.modalText=modaltext;
    document.getElementById("btnLaunchModal")?.click();
  }
  
  GetTicketHistory()
  {
    
    this._ticket.GetTicketByEmailHistory(this.emailId).subscribe(res => { this.BindTicketHistoryResults(res)},
    err => { this.DisplayModalPopup("Error", err.error)});
  }
  
  BindTicketHistoryResults(response:any)
  {
    this.ticketHistoryemailid = response;
    this.isShowNoResultFound = false;
  }
  
  SetNoResultFound()
  {
    this.isShowNoResultFound = true;
  }
  
  ViewTicketDetails(result:any)
  {
   // let modalText=""
     let modalText = "PNR Number: " + result.pnrNumber 
     + "\nContact no: " + result.contactNo
     +"\nCustomer address: " + result.address
     +"\nBooked On: " +  (new Date(result.bookingDatetime)).toLocaleString()
     +"\nTravel Date: " + (new Date(result.journeyDate)).toLocaleString()
     +"\nSource Location: " + result.sourceName
     +"\nDestination Location: " + result.destinationName
     +"\nIsBooked: " + result.isActive
     +"\n SeatType: " + result.seatTypeName
     +"\n\nBooking Passenger Details";
  
     for(let i = 0; i < result.passengerDetails.length; i++)
     {
       //let seatType = this.ticketHistory.passengerDetails[i].MealTypeId ? "Business" : "Regular"
       modalText = modalText + "\n\nPassenger Name: " + result.passengerDetails[i].passengerName
       //+"\nPassenger Age: " + this.ticketHistory.passengerDetails[i].passengerAge
       +"\nPassenger Gender: " + result.passengerDetails[i].genderType
       +"\nSeat No: " + result.passengerDetails[i].seatNo;
       +"\nSeat Type: " + result.passengerDetails[i].mealType;
    }
  
     this.DisplayModalPopup("Ticket Details", modalText);
  }
  
}
