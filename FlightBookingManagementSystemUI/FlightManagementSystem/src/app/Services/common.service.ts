import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
_dropDownUrl:string="https://localhost:44395/api/Common";
  constructor(private http: HttpClient) { }


  GetGenderTypes()
  {
    return this.http.get(this._dropDownUrl + "/getallGender");
  }

  GetInstrumentTypes()
  {
    return this.http.get(this._dropDownUrl + "/getallInstruments");
  }
  GetMealPlanTypes()
  {
    return this.http.get(this._dropDownUrl + "/getallmeal");
  }
  GetSeatTypes()
  {
    return this.http.get(this._dropDownUrl + "/getallSeat");
  }
  GetWeekdayTypes()
  {
    return this.http.get(this._dropDownUrl + "/getallWeekday");
  }

}

