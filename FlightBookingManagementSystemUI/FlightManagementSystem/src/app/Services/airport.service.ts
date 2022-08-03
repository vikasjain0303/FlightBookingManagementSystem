import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';  
import { AirportMaster } from '../Models/airportmaster';

@Injectable({
  providedIn: 'root'
})
export class AirportService {

  url="https://localhost:44395/api/Airport";

  constructor(private http: HttpClient) {

  }
  getallAirport():Observable<AirportMaster[]>{

   return this.http.get<AirportMaster[]>(this.url +"/getall")
  }

  AddAirport(airprtRequest:any)
  {
    return this.http.post<any>(this.url + "/add", airprtRequest);
  }
}
