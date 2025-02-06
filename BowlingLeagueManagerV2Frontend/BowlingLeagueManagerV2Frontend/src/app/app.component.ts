import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BowlerComponent } from './components/bowler/bowler.component';
import { DtoComponent } from './components/dto/dto.component';
import { BowlerLeagueComboComponent } from "./components/bowler-league-combo/bowler-league-combo.component";
import { SeriesComponent } from './components/series/series.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, BowlerComponent, DtoComponent, BowlerLeagueComboComponent, SeriesComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'BowlingLeagueManagerV2Frontend';
}
