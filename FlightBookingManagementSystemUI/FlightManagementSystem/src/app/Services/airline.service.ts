import { HttpClient, HttpParams } from '@angular/common/http';
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

  RemoveAirline(airlineId:any)
  {
    let queryparams=new HttpParams()
    queryparams=queryparams.append("airlineId",airlineId);
    //queryparams=queryparams.append("SourceId",SourceId,);  
    //queryparams=queryparams.append("DestinationId",DestinationId,);

    return this.http.delete<any>(this._baseUrl + "/delete" , {params:queryparams});
  }
}
