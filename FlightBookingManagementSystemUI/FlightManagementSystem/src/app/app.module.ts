import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookingDetailsComponent } from './booking-details/booking-details.component';
import { AirlineMasterComponent } from './airline-master/airline-master.component';
import { AirPortMasterComponent } from './air-port-master/air-port-master.component';
import { DiscountMasterComponent } from './discount-master/discount-master.component';
import { FlightMasterComponent } from './flight-master/flight-master.component';
import { FlightScheduleMasterComponent } from './flight-schedule-master/flight-schedule-master.component';
import { UserMasterComponent } from './user-master/user-master.component';

@NgModule({
  declarations: [
    AppComponent,
    BookingDetailsComponent,
    AirlineMasterComponent,
    AirPortMasterComponent,
    DiscountMasterComponent,
    FlightMasterComponent,
    FlightScheduleMasterComponent,
    UserMasterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
