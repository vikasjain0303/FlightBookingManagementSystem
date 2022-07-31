import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirlineMasterComponent } from './airline-master.component';

describe('AirlineMasterComponent', () => {
  let component: AirlineMasterComponent;
  let fixture: ComponentFixture<AirlineMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AirlineMasterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AirlineMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
