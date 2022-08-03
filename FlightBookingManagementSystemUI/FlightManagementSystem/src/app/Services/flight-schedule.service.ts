import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FlightScheduleService {

  constructor(private http: HttpClient) { }
  scheduledDate:any;
  sourceId:any;
  destinationId:any;
  private _baseUrl = "https://localhost:44395/api/FlightSchedule";

  SearchSchedule(Journeydate:any,SourceId:any,DestinationId:any)
  {
    let queryparams=new HttpParams()
    queryparams=queryparams.append("Journeydate",Journeydate);
    queryparams=queryparams.append("SourceId",SourceId,);  
    queryparams=queryparams.append("DestinationId",DestinationId,);


    // this.sourceId=sourceLocationId;
    // this.destinationId=destinationLocationId
    return this.http.get<any>(this._baseUrl + "/find", {params:queryparams});
  }
}
