import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddAirLineComponent } from './add-air-line/add-air-line.component';
import { AddAirportComponent } from './add-airport/add-airport.component';
import { AddBookingComponent } from './add-booking/add-booking.component';
import { AddFlightComponent } from './add-flight/add-flight.component';
import { AddscheduleComponent } from './addschedule/addschedule.component';
import { AirPortMasterComponent } from './air-port-master/air-port-master.component';
import { AirlineMasterComponent } from './airline-master/airline-master.component';
import { FlightMasterComponent } from './flight-master/flight-master.component';
import { FlightScheduleMasterComponent } from './flight-schedule-master/flight-schedule-master.component';
import { SearchTicketByEmailIdComponent } from './search-ticket-by-email-id/search-ticket-by-email-id.component';
import { SearchTicketPnrComponent } from './search-ticket-pnr/search-ticket-pnr.component';

const routes: Routes = [
  { path: '', redirectTo: '/airportmasterlist', pathMatch: 'full' },
  { path: 'airportmasterlist', component: AirPortMasterComponent },
  {path:'AddAirPort', component:AddAirportComponent},
  { path: 'airLinemasterlist', component: AirlineMasterComponent },
  {path:'AddAirline', component:AddAirLineComponent},
  { path: 'flightmasterlist', component: FlightMasterComponent },
  {path:'AddFlight', component:AddFlightComponent},
  { path: 'searchSchedule', component: FlightScheduleMasterComponent },
  {path:'AddSchedule', component:AddscheduleComponent},
  {path:'searchticketbypnr', component:SearchTicketPnrComponent},
  {path:'searchticketbyemailId', component:SearchTicketByEmailIdComponent},
  {path:'addbooking',component:AddBookingComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
