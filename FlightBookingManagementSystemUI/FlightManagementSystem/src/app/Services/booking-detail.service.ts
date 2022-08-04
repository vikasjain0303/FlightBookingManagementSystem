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
}
