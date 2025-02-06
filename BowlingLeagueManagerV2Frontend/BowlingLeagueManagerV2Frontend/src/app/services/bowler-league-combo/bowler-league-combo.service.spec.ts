import { TestBed } from '@angular/core/testing';

import { BowlerLeagueComboService } from './bowler-league-combo.service';

describe('BowlerLeagueComboService', () => {
  let service: BowlerLeagueComboService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BowlerLeagueComboService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
