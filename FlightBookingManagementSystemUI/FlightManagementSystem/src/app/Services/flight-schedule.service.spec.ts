import { TestBed } from '@angular/core/testing';

import { FlightScheduleService } from './flight-schedule.service';

describe('FlightScheduleService', () => {
  let service: FlightScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlightScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
