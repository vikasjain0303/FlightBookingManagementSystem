import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

export class AddAirPortModel {

    airportId:any;
    airportName:string;
    country:string;
    state:string;
    airportCode:string;
    city :string;
    isActive:boolean=false;


    formAirportAddGroup:FormGroup;
    
    constructor() {
        var _builder = new FormBuilder();
        this.formAirportAddGroup = _builder.group({});
        this.formAirportAddGroup.addControl("airportNameControl", new FormControl('', Validators.required));
        this.formAirportAddGroup.addControl("countryControl", new FormControl('', Validators.required));
        this.formAirportAddGroup.addControl("stateControl", new FormControl('', Validators.required));
        this.formAirportAddGroup.addControl("airportCodeControl", new FormControl('', Validators.required));
        this.formAirportAddGroup.addControl("cityControl", new FormControl('', Validators.required));
    }
}
