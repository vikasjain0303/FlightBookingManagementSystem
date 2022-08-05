import { Component, OnInit } from '@angular/core';
import { TicketHistoryModel } from '../Models/BookingticketHistory';
import { BookingDetailService } from '../Services/booking-detail.service';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

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
   let modalText = "PNR Number: " + this.ticketHistory.pnrNumber 
   + "\nContact no: " + this.ticketHistory.contactNo
   +"\nCustomer address: " + this.ticketHistory.address
   +"\nBooked On: " +  (new Date(this.ticketHistory.bookingDatetime)).toLocaleString()
   +"\nTravel Date: " + (new Date(this.ticketHistory.journeyDate)).toLocaleString()
   +"\nSource Location: " + this.ticketHistory.sourceName
   +"\nDestination Location: " + this.ticketHistory.destinationName
   +"\nIsBooked: " + this.ticketHistory.isActive
   +"\n SeatType: " + this.ticketHistory.seatTypeName
   +"\n\nBooking Passenger Details";

   for(let i = 0; i < this.ticketHistory.passengerDetails.length; i++)
   {
     //let seatType = this.ticketHistory.passengerDetails[i].MealTypeId ? "Business" : "Regular"
     modalText = modalText + "\n\nPassenger Name: " + this.ticketHistory.passengerDetails[i].passengerName
     //+"\nPassenger Age: " + this.ticketHistory.passengerDetails[i].passengerAge
     +"\nPassenger Gender: " + this.ticketHistory.passengerDetails[i].genderType
     +"\nSeat No: " + this.ticketHistory.passengerDetails[i].seatNo;
     //+"\nSeat Type: " + this.ticketHistory.passengerDetails[i].mealType;
   }

   this.DisplayModalPopup("Ticket Details", modalText);
}

CancelTicket(tickethistory:any)
{

  this._ticket.CancelTicket(tickethistory.pnrNumber).subscribe(res => {this.DisplayModalPopup("Success", "Ticket Cancel Successfully")}, err=> {this.DisplayModalPopup("Error", "An error occurred")});

}

public openPDF(): void {
  let DATA: any = document.getElementById('innerhtml');
  html2canvas(DATA).then((canvas) => {
    let fileWidth = 208;
    let fileHeight = (canvas.height * fileWidth) / canvas.width;
    const FILEURI = canvas.toDataURL('image/png');
    let PDF = new jsPDF('p', 'mm', 'a4');
    let position = 0;
    PDF.addImage(FILEURI, 'PNG', 0, position, fileWidth, fileHeight);
    PDF.save('ticketDownload.pdf');
  });

}


}
