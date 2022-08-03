import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AirlineService {
  private _baseUrl = "https://localhost:44395/api/AirLine";

  constructor(private http: HttpClient) { }

  
GetAllAirlines()
{
  return this.http.get<any>(this._baseUrl + "/getall");
}
AddAirline(airlineRequest:any)
  {
    return this.http.post<any>(this._baseUrl + "/add", airlineRequest);
  }
}
