import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DtoLeagueDetails } from '../../models/dto-interfaces';
import { DtoBowlerOnly, DtoLeagueOnly, DtoTeamOnly } from '../../models/dto-interfaces'

@Injectable({
  providedIn: 'root'
})
export class DtoService {
  private apiUrl = 'http://localhost:5167/bowlingLeagueManager';

  constructor(private http: HttpClient) {}

  getLeagueDetailsByLeagueId(leagueId: number): Observable<DtoLeagueDetails[]> {
    return this.http.get<DtoLeagueDetails[]>(`${this.apiUrl}/dto/leagueDetails?leagueId=${leagueId}`);
  }

  getAllBowlers(): Observable<DtoBowlerOnly[]> {
    return this.http.get<DtoBowlerOnly[]>(`${this.apiUrl}/bowler/getAll`);
  }

  getAllLeagues(): Observable<DtoLeagueOnly[]> {
    return this.http.get<DtoLeagueOnly[]>(`${this.apiUrl}/league/getAll`);
  }

  getAllTeams(): Observable<DtoTeamOnly[]> {
    return this.http.get<DtoTeamOnly[]>(`${this.apiUrl}/team/getAll`);
  }
}
