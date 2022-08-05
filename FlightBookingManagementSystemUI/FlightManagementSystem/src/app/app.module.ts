import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookingDetailsComponent } from './booking-details/booking-details.component';
import { AirlineMasterComponent } from './airline-master/airline-master.component';
import { AirPortMasterComponent } from './air-port-master/air-port-master.component';
import { DiscountMasterComponent } from './discount-master/discount-master.component';
import { FlightMasterComponent } from './flight-master/flight-master.component';
import { FlightScheduleMasterComponent } from './flight-schedule-master/flight-schedule-master.component';
import { UserMasterComponent } from './user-master/user-master.component';
import { HttpClientModule } from '@angular/common/http';
import { AirportService } from './Services/airport.service';
import { AddAirportComponent } from './add-airport/add-airport.component';
import { AddAirLineComponent } from './add-air-line/add-air-line.component';
import { AirlineService } from './Services/airline.service';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { FlightService } from './Services/flight.service';
import { AddscheduleComponent } from './addschedule/addschedule.component';
import { FlightScheduleService } from './Services/flight-schedule.service';
import { SearchTicketPnrComponent } from './search-ticket-pnr/search-ticket-pnr.component';
import { SearchTicketByEmailIdComponent } from './search-ticket-by-email-id/search-ticket-by-email-id.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AddBookingComponent } from './add-booking/add-booking.component';
import { BookingDetailService } from './Services/booking-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    BookingDetailsComponent,
    AirlineMasterComponent,
    AirPortMasterComponent,
    DiscountMasterComponent,
    FlightMasterComponent,
    FlightScheduleMasterComponent,
    UserMasterComponent,
    AddAirportComponent,
    AddAirLineComponent,
    AddFlightComponent,
    AddscheduleComponent,
    SearchTicketPnrComponent,
    SearchTicketByEmailIdComponent,
    RegisterComponent,
    LoginComponent,
    AddBookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [AirportService, AirlineService,FlightService,FlightScheduleService,BookingDetailService,],
  bootstrap: [AppComponent]
})
export class AppModule { }
