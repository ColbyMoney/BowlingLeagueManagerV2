import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Bowler } from '../../models/bowler';
// import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BowlerService {
  private apiUrl = 'http://localhost:5167/bowlingLeagueManager/bowler';

  constructor(private http: HttpClient) {}

  getAllBowlers(): Observable<Bowler[]> {
    return this.http.get<Bowler[]>(`${this.apiUrl}/getAll`);
  }

  getBowlerById(bowlerId: number): Observable<Bowler> {
    return this.http.get<Bowler>(`${this.apiUrl}/get?bowlerId=${bowlerId}`);
  }

  createBowler(firstName: string, lastName: string, bowlerImage: string, bowlerImageAltText: string): Observable<Bowler> {
    const bowler: Bowler = { bowlerId: 0, firstName, lastName, bowlerImage, bowlerImageAltText};
    return this.http.post<Bowler>(`${this.apiUrl}/create`, bowler);
  }

  updateBowler(bowlerId: number, bowler: Bowler): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${bowlerId}`, bowler);
  }

  deleteBowler(bowlerId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${bowlerId}`);
  }
}
