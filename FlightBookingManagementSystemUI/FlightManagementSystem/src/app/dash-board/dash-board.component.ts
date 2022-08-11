import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    if(localStorage.getItem('userRole') == "1")
    {
       this.role = "Administrator";
    }
    else
    {
       this.role = "User";
    }
  }
role:string="";

}
