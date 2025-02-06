import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { BowlerLeagueCombo } from '../../models/bowler-league-combo'
import { BowlerLeagueComboService } from '../../services/bowler-league-combo/bowler-league-combo.service';
import { DtoBowlerOnly, DtoLeagueOnly, DtoTeamOnly } from '../../models/dto-interfaces'
import { DtoService } from '../../services/dto/dto.service';
import { NgFor } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-bowler-league-combo',
  standalone: true,
  imports: [MatSelectModule, ReactiveFormsModule, NgFor, MatButtonModule],
  templateUrl: './bowler-league-combo.component.html',
  styleUrl: './bowler-league-combo.component.css'
})
export class BowlerLeagueComboComponent implements OnInit {
  public bowlerLeagueCombos : BowlerLeagueCombo[] = [];
  public bowlerLeagueCombo : BowlerLeagueCombo = {bowlerLeagueComboId: -1, bowlerId: -1, leagueId: -1, teamId: -1, totalPins: 0, totalGamesBowled: 0, average: 0, highestGame: 0, highestSeries: 0};

  constructor(
    private bowlerLeagueComboService: BowlerLeagueComboService,
    private dtoService: DtoService
  ){}

  ngOnInit(): void {
    this.loadBowlers();
    this.loadLeagues();
    this.loadTeams();
  }

  public bowlers: DtoBowlerOnly[] = [];
  public leagues: DtoLeagueOnly[] = [];
  public teams: DtoTeamOnly[] = [];

  bowlerLeagueComboForm  = new FormGroup({
    bowlerId: new FormControl(""),
    leagueId: new FormControl(""),
    teamId: new FormControl("")
  });

  public getAllBowlerLeagueCombos(): void {
    this.bowlerLeagueComboService.getAllBowlerLeagueCombos().subscribe(
      (response: BowlerLeagueCombo[]) => {
        this.bowlerLeagueCombos = response;
        console.log(this.bowlerLeagueCombos);
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
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

  private loadTeams(): void {
    this.dtoService.getAllTeams().subscribe(
      (response: DtoTeamOnly[]) => {
        this.teams = response;
      },
      (error: HttpErrorResponse) => {
        console.error('Failed to load teams', error);
      }
    );
  }

  public createBowlerLeagueCombo(): void {
    if (this.bowlerLeagueComboForm.valid) {
      const bowlerId = this.bowlerLeagueComboForm.value.bowlerId;
      const leagueId = this.bowlerLeagueComboForm.value.leagueId;
      const teamId = this.bowlerLeagueComboForm.value.teamId;
  
      // Convert values to numbers and ensure they are not null or undefined
      const validBowlerId = bowlerId ? parseInt(bowlerId) : null;
      const validLeagueId = leagueId ? parseInt(leagueId) : null;
      const validTeamId = teamId ? parseInt(teamId) : null;
  
      if (validBowlerId !== null && validLeagueId !== null && validTeamId !== null) {
        this.bowlerLeagueComboService.createBowlerLeagueCombo(
          validBowlerId, 
          validLeagueId, 
          validTeamId
        ).subscribe(
          (response: BowlerLeagueCombo) => {
            console.log('Bowler-League Combo created:', response);
            // Optionally reset the form
            this.bowlerLeagueComboForm.reset();
          },
          (error: HttpErrorResponse) => {
            alert(`Error creating combo: ${error.message}`);
          }
        );
      } else {
        alert('Please fill in all fields.');
      }
    } else {
      alert('Form is invalid. Please ensure all fields are filled correctly.');
    }
  }
}
