import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

export class AddFlightScheduleModel {

    flightScheduleId:number=0;
    flightId:number=0;
    endDate:any;
    startDate:any;
    isActive:any;
    departureTime:string="";
    arrivalTime:string="";
    totalSeatBusinessClass:number=0;
    totalSeatRegularClass:number=0;
    vacantSeatBusinessClass:number=0;
    vacantSeatRegularClass:number=0;
    rowNo:number=0;
    ticketCost:number=0;
    weekdaysIds:string=""
    formFlightScheduleAddGroup:FormGroup;
    
    constructor() {
        var numericValidators = [];
        numericValidators.push(Validators.required);
        numericValidators.push(Validators.pattern("^[0-9]+$"));

        var priceValidators = [];
        priceValidators.push(Validators.required);
        priceValidators.push(Validators.pattern("^[0-9]+(\.[0-9]*)?$"));

        var _builder = new FormBuilder();
        this.formFlightScheduleAddGroup = _builder.group({});
        this.formFlightScheduleAddGroup.addControl("endDateControl", new FormControl('', Validators.required));
        this.formFlightScheduleAddGroup.addControl("startDateControl", new FormControl('', Validators.required));
        this.formFlightScheduleAddGroup.addControl("ticketCostControl", new FormControl('', Validators.compose(priceValidators)));
        //this.formFlightScheduleAddGroup.addControl("arrivalTimeControl", new FormControl('', Validators.required));
        //this.formFlightScheduleAddGroup.addControl("departureTimeControl", new FormControl('', Validators.required));
        this.formFlightScheduleAddGroup.addControl("totalSeatBusinessClassControl", new FormControl('', Validators.compose(numericValidators)));
        this.formFlightScheduleAddGroup.addControl("totalSeatRegularClassControl", new FormControl('', Validators.compose(numericValidators)));
        //this.formFlightScheduleAddGroup.addControl("vacantSeatBusinessClassControl", new FormControl('', Validators.required));
        //this.formFlightScheduleAddGroup.addControl("vacantSeatRegularClassControl", new FormControl('', Validators.compose(numericValidators)));
        this.formFlightScheduleAddGroup.addControl("rowNoControl", new FormControl('', Validators.compose(numericValidators)));
    }
}