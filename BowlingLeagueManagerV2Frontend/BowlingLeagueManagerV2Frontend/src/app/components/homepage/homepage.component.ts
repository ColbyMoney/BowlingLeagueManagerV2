import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './homepage.component.html',
  styleUrl: './homepage.component.css'
})
export class HomepageComponent {

  constructor(
    private router: Router
  ) {}

  public navigateToBowler() {
    this.router.navigate(['/bowler']);
  }

  public navigateToBowlerLeagueCombo() {
    this.router.navigate(['/bowler-league-combo']);
  }

  public navigateToSeries() {
    this.router.navigate(['/series']);
  }

  public navigateToLeagueDetails() {
    this.router.navigate(['/league-details']);
  }
}
