export class FlightSearchResultParamaters {
    flightId:number=0;
    flightDayScheduleId:number=0;
    flightDateTime:any;
    flightNumber:string=""
    
    cost:any;
    mealPlanId:number=0;
    vacantBusinessSeats:number=0;
    vacantRegularSeats:number=0;
    isSelected:boolean=false;


    flightScheduleId:any;
    flightCode:string
    airlineId:any;
    airlineName:string;
    sourceName:string;
    sourceId:any;
    destinationName:string;
    destinationId:any
    isActive:boolean=false;
    departureDate:any;
    arivalDate:any;
    arrivalTime:string;
    departureTime:string;
}