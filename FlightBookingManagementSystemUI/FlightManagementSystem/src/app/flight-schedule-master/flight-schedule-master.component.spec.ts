import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightScheduleMasterComponent } from './flight-schedule-master.component';

describe('FlightScheduleMasterComponent', () => {
  let component: FlightScheduleMasterComponent;
  let fixture: ComponentFixture<FlightScheduleMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FlightScheduleMasterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FlightScheduleMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
