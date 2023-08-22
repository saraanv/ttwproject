import { TestBed } from '@angular/core/testing';

import { PresenceDetailService } from './presence-detail.service';

describe('PresenceDetailService', () => {
  let service: PresenceDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PresenceDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
