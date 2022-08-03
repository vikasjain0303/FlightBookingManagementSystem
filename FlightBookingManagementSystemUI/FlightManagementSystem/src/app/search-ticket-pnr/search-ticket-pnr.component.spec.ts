import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchTicketPnrComponent } from './search-ticket-pnr.component';

describe('SearchTicketPnrComponent', () => {
  let component: SearchTicketPnrComponent;
  let fixture: ComponentFixture<SearchTicketPnrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchTicketPnrComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchTicketPnrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
