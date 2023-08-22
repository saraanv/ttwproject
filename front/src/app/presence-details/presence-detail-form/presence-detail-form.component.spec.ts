import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PresenceDetailFormComponent } from './presence-detail-form.component';

describe('PresenceDetailFormComponent', () => {
  let component: PresenceDetailFormComponent;
  let fixture: ComponentFixture<PresenceDetailFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PresenceDetailFormComponent]
    });
    fixture = TestBed.createComponent(PresenceDetailFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
