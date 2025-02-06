import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Series } from '../../models/series';

@Injectable({
  providedIn: 'root'
})
export class SeriesService {
  private apiUrl = 'http://localhost:5167/bowlingLeagueManager/series';

  constructor(private http: HttpClient) {}

  getAllSeries(): Observable<Series[]> {
    return this.http.get<Series[]>(`${this.apiUrl}/getAll`);
  }

  getSeriesById(seriesId: number): Observable<Series> {
    return this.http.get<Series>(`${this.apiUrl}/get?seriesId=${seriesId}`);
  }

  createSeries(bowlerId: number, leagueId: number, weekId: number, game1: number, game2: number, game3: number, seriesTotal: number): Observable<Series> {
    const series: Series = {
      seriesId: 0,
      bowlerId,
      leagueId,
      weekId,
      game1,
      game2,
      game3,
      seriesTotal
    };
    return this.http.post<Series>(`${this.apiUrl}/create`, series);
  }

  updateSeries(seriesId: number, series: Series): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${seriesId}`, series);
  }

  deleteSeries(seriesId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${seriesId}`);
  }
}
