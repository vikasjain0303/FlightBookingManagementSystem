import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FlightService {

  private _baseUrl = "https://localhost:44395/api/Flight";

  constructor(private http: HttpClient) { }

  
GetAllFlight()
{
  return this.http.get<any>(this._baseUrl + "/getall");
}
AddFlight(flightRequest:any)
  {
    return this.http.post<any>(this._baseUrl + "/add", flightRequest);
  }
}
