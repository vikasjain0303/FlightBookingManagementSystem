import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAirLineComponent } from './add-air-line.component';

describe('AddAirLineComponent', () => {
  let component: AddAirLineComponent;
  let fixture: ComponentFixture<AddAirLineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAirLineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddAirLineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
