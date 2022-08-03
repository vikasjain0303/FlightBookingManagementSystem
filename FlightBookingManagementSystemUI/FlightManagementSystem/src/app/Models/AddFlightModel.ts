import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

export class AddFlightModel {

    flightId:any;
    flightCode:string
    airlineId:any;
    airLineName:string;
    instrumentTypeName:string;
    instrumentId:any;
    isActive:boolean=false;


    formFlightAddGroup:FormGroup;
    
    constructor() {
        var _builder = new FormBuilder();
        this.formFlightAddGroup = _builder.group({});
        this.formFlightAddGroup.addControl("flightCodeControl", new FormControl('', Validators.required));
       // this.formFlightAddGroup.addControl("airLineNameControl", new FormControl('', Validators.required));
        //this.formFlightAddGroup.addControl("instrumentTypeNameControl", new FormControl('', Validators.required));
    }
}
