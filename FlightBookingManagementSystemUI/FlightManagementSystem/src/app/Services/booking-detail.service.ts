import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BookingDetailService {

  constructor(private http:HttpClient) { }

  private _baseUrl = "https://localhost:44380/api/Booking"

  GetTicketPnrHistory(pnrNumber:string)
  {
    let queryparams=new HttpParams()
    queryparams=queryparams.append("pnrnumber",pnrNumber);
    return this.http.get(this._baseUrl+"/findbookingpnr" , {params:queryparams});
  }
  GetTicketByEmailHistory(emailId:string)
  {

    let queryparams=new HttpParams()
    queryparams=queryparams.append("useremailid",emailId);
    return this.http.get(this._baseUrl+"/bookinghistory" , {params:queryparams});
  }

  SearchFlight(Journeydate:any,SourceId:any,DestinationId:any)
  {
    let url = "https://localhost:44395/api/FlightSchedule";

    let queryparams=new HttpParams()
    queryparams=queryparams.append("Journeydate",Journeydate);
    queryparams=queryparams.append("SourceId",SourceId,);  
    queryparams=queryparams.append("DestinationId",DestinationId,);


    // this.sourceId=sourceLocationId;
    // this.destinationId=destinationLocationId
    return this.http.get<any>(url + "/find", {params:queryparams});
  }

  BookFlightTicket(bookingRequest:any)
  {
    return this.http.post( "https://localhost:44380/api/Booking/add", bookingRequest);
  }
}
