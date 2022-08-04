import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchTicketByEmailIdComponent } from './search-ticket-by-email-id.component';

describe('SearchTicketByEmailIdComponent', () => {
  let component: SearchTicketByEmailIdComponent;
  let fixture: ComponentFixture<SearchTicketByEmailIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchTicketByEmailIdComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchTicketByEmailIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
