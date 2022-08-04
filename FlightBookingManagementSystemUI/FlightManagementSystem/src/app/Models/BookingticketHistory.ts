import { BookingPassengers } from "./BookingPassengers";

export class TicketHistoryModel {
    airLineId:number=0;
    airLineName:string="";
    sourceName:string="";
    destinationName:string="";
    bookingId:number=0;
    flightId:number=0;
    address:string="";
    contactNo:string="";
    noOfSeatsBook:number=0;
    
    pnrNumber:string="";
    journeyDate:any;
    bookingDatetime:any;
    totalPrice:any;
    isActive:boolean=false;
 
    seatTypeName:string="";
    passengerDetails:Array<BookingPassengers> = new Array<BookingPassengers>();
}