import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresenceDetailsComponent } from './presence-details.component';

describe('PresenceDetailsComponent', () => {
  let component: PresenceDetailsComponent;
  let fixture: ComponentFixture<PresenceDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PresenceDetailsComponent]
    });
    fixture = TestBed.createComponent(PresenceDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
