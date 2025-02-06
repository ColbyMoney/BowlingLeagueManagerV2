import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Series } from '../../models/series';
import { SeriesService } from '../../services/series/series.service';
import { NgFor, NgIf } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { DtoBowlerOnly, DtoLeagueOnly } from '../../models/dto-interfaces'
import { DtoService } from '../../services/dto/dto.service';

@Component({
  selector: 'app-series',
  standalone: true,
  imports: [NgFor, NgIf, ReactiveFormsModule, MatSelectModule, MatButtonModule, MatInputModule],
  templateUrl: './series.component.html',
  styleUrl: './series.component.css'
})
export class SeriesComponent implements OnInit {

  public series: Series[] = [];
  public bowlers: DtoBowlerOnly[] = [];
  public leagues: DtoLeagueOnly[] = [];
  public selectedLeague: DtoLeagueOnly | null = null;  // Store selected league

  seriesForm = new FormGroup({
    bowlerId: new FormControl(""),
    leagueId: new FormControl(""),
    weekId: new FormControl(""),
    game1: new FormControl(""),
    game2: new FormControl(""),
    game3: new FormControl("")
  });

  constructor(
    private seriesService: SeriesService,
    private dtoService: DtoService
  ) {}

  ngOnInit(): void {
    this.loadBowlers();
    this.loadLeagues();
  }

  private loadBowlers(): void {
    this.dtoService.getAllBowlers().subscribe(
      (response: DtoBowlerOnly[]) => {
        this.bowlers = response;
      },
      (error: HttpErrorResponse) => {
        console.error('Failed to load bowlers', error);
      }
    );
  }

  private loadLeagues(): void {
    this.dtoService.getAllLeagues().subscribe(
      (response: DtoLeagueOnly[]) => {
        this.leagues = response;
      },
      (error: HttpErrorResponse) => {
        console.error('Failed to load leagues', error);
      }
    );
  }

  // Function to handle league change
  public onLeagueChange(): void {
    const selectedLeagueId = Number(this.seriesForm.get('leagueId')?.value);
    this.selectedLeague = this.leagues.find(league => league.leagueId === selectedLeagueId) || null;

    if (this.selectedLeague) {
      this.seriesForm.get('weekId')?.enable();  // Enable the week dropdown
    } else {
      this.seriesForm.get('weekId')?.disable();  // Disable the week dropdown if no league is selected
    }
  }

  public calculateSeries(): number {
    const game1 = Number(this.seriesForm.get('game1')?.value) || 0;
    const game2 = Number(this.seriesForm.get('game2')?.value) || 0;
    const game3 = Number(this.seriesForm.get('game3')?.value) || 0;

    return game1 + game2 + game3;
  }

  public createSeries(): void {
    const bowlerId = Number(this.seriesForm.get('bowlerId')?.value);
    const leagueId = Number(this.seriesForm.get('leagueId')?.value);
    const weekId = Number(this.seriesForm.get('weekId')?.value);
    const game1 = Number(this.seriesForm.get('game1')?.value);
    const game2 = Number(this.seriesForm.get('game2')?.value);
    const game3 = Number(this.seriesForm.get('game3')?.value);
    const seriesTotal = Number(game1 + game2 + game3);

    // Ensure that the form has all valid numbers
    if (isNaN(bowlerId) || isNaN(leagueId) || isNaN(game1) || isNaN(game2) || isNaN(game3)) {
      alert("Please enter valid numeric values.");
      return;
    }

    this.seriesService.createSeries(bowlerId, leagueId, weekId, game1, game2, game3, seriesTotal).subscribe(
      (response: Series) => {
        console.log(response);
        alert("Series successfully created!");
        // Optionally, push the new series to your local array to update the view
        this.series.push(response);
        this.seriesForm.reset(); // Reset the form after success
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }
}
