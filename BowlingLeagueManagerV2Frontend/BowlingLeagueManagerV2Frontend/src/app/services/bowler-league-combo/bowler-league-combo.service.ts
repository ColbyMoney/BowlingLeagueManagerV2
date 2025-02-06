import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BowlerLeagueCombo } from '../../models/bowler-league-combo';
// import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BowlerLeagueComboService {
  private apiUrl = 'http://localhost:5167/bowlingLeagueManager/bowlerLeagueCombo';

  constructor(private http: HttpClient) {}

  getAllBowlerLeagueCombos(): Observable<BowlerLeagueCombo[]> {
    return this.http.get<BowlerLeagueCombo[]>(`${this.apiUrl}/getAll`);
  }

  getBowlerLeagueComboById(bowlerLeagueComboId: number): Observable<BowlerLeagueCombo> {
    return this.http.get<BowlerLeagueCombo>(`${this.apiUrl}/get?bowlerLeagueComboId=${bowlerLeagueComboId}`);
  }

  createBowlerLeagueCombo(bowlerId: number, leagueId: number, teamId: number): Observable<BowlerLeagueCombo> {
    const bowlerLeagueCombo: BowlerLeagueCombo = { bowlerLeagueComboId: 0, bowlerId, leagueId, teamId, totalPins: 0, totalGamesBowled: 0, average: 0, highestGame: 0, highestSeries: 0 };
    return this.http.post<BowlerLeagueCombo>(`${this.apiUrl}/create`, bowlerLeagueCombo);
  }

  updateBowlerLeagueCombo(bowlerLeagueComboId: number, bowlerLeagueCombo: BowlerLeagueCombo): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${bowlerLeagueComboId}`, bowlerLeagueCombo);
  }

  deleteBowlerLeagueCombo(bowlerLeagueComboId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${bowlerLeagueComboId}`);
  }
}
