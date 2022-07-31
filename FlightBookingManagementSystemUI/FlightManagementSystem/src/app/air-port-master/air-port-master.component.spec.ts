import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AirPortMasterComponent } from './air-port-master.component';

describe('AirPortMasterComponent', () => {
  let component: AirPortMasterComponent;
  let fixture: ComponentFixture<AirPortMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AirPortMasterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AirPortMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
