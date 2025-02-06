import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BowlerLeagueComboComponent } from './bowler-league-combo.component';

describe('BowlerLeagueComboComponent', () => {
  let component: BowlerLeagueComboComponent;
  let fixture: ComponentFixture<BowlerLeagueComboComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BowlerLeagueComboComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BowlerLeagueComboComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
