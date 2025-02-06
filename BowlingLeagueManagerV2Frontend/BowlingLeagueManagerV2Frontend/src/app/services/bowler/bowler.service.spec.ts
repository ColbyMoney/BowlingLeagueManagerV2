import { TestBed } from '@angular/core/testing';

import { BowlerService } from './bowler.service';

describe('BowlerService', () => {
  let service: BowlerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BowlerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
