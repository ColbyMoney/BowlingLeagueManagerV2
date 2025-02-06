// dto.component.ts
import { Component } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { DtoBowler, DtoTeam, DtoLeague, DtoLeagueDetails } from '../../models/dto-interfaces';
import { DtoService } from '../../services/dto/dto.service';
import { NgFor } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-dto',
  standalone: true,
  imports: [NgFor, ReactiveFormsModule, MatCardModule, MatButtonModule, MatInputModule],
  templateUrl: './dto.component.html',
  styleUrls: ['./dto.component.css']
})
export class DtoComponent {

  public leagueDetails: DtoLeague[] = [];

  constructor(private dtoService: DtoService) {}

  leagueIdForm = new FormGroup({
    leagueId: new FormControl("")
  })

  public getLeagueDetailsByLeagueId(): void {
    const leagueId = this.leagueIdForm.get('leagueId')?.value;

    if (leagueId) {
      this.dtoService.getLeagueDetailsByLeagueId(Number(leagueId)).subscribe(
        (response: DtoLeagueDetails[]) => {
          // Transform the flat response into the nested structure
          this.leagueDetails = this.transformLeagueDetailsToNestedStructure(response);
          console.log(this.leagueDetails);
        },
        (error: HttpErrorResponse) => {
          alert(error.message);
        }
      );
    } else {
      alert('Please enter a valid League ID.');
    }
  }

  private transformLeagueDetailsToNestedStructure(data: DtoLeagueDetails[]): DtoLeague[] {
    const leaguesMap = new Map<number, DtoLeague>();
  
    data.forEach((entry) => {
      // Check if the league already exists in the map
      if (!leaguesMap.has(entry.leagueId)) {
        // Add the league if it's not already present
        leaguesMap.set(entry.leagueId, {
          leagueId: entry.leagueId,
          leagueName: entry.leagueName,
          leagueDescription: entry.leagueDescription,
          teams: [] // Initialize teams array
        });
      }
  
      const league = leaguesMap.get(entry.leagueId);
  
      // Check if the team already exists within the league
      let team = league?.teams.find(t => t.teamId === entry.teamId);
      if (!team) {
        // Add the team if it's not already present
        team = {
          teamId: entry.teamId,
          teamName: entry.teamName,
          bowlers: [] // Initialize bowlers array
        };
        league?.teams.push(team);
      }
  
      // Add the bowler to the correct team
      team.bowlers.push({
        bowlerName: `${entry.firstName} ${entry.lastName}`,
        bowlerImage: entry.bowlerImage,
        bowlerImageAltText: entry.bowlerImageAltText,
        bowlerId: entry.bowlerId,
        totalPins: entry.totalPins,
        totalGamesBowled: entry.totalGamesBowled,
        average: entry.average,
        highestGame: entry.highestGame,
        highestSeries: entry.highestSeries
      });
    });
  
    // Return an array of leagues
    return Array.from(leaguesMap.values());
  }
}
