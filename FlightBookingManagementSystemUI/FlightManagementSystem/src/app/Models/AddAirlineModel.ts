import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

export class AddAirlineModel
{
    airlineId:string="";
    airlineName:string="";
    airlineCode:string="";
    logo:string="";
    contactNo:string="";
    address:string="";
    //airlineDescription:string="";
    isActive:boolean=false;
    emailId:string="";
    formAirlineAddGroup:FormGroup;
    
    constructor() {
        var _builder = new FormBuilder();
        this.formAirlineAddGroup = _builder.group({});
        this.formAirlineAddGroup.addControl("airlineNameControl", new FormControl('', Validators.required));
        this.formAirlineAddGroup.addControl("airlineCodeControl", new FormControl('', Validators.required));
        this.formAirlineAddGroup.addControl("contactNoControl", new FormControl('', Validators.required));
        this.formAirlineAddGroup.addControl("addressControl", new FormControl('', Validators.required));
        this.formAirlineAddGroup.addControl("emailIdControl", new FormControl('', Validators.required));
    }
}