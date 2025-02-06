import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Account } from '../../models/account';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  private apiUrl = 'http://localhost:5167/bowlingLeagueManager/account';

  constructor(private http: HttpClient) { }

  createAccount(firstName: string, lastName: string, emailAddress: string, username: string, passwordHash: string): Observable<Account> {
    const account: Account = { accountId: 0, bowlerId: -1, firstName, lastName, emailAddress, username, passwordHash, GUID: ""};
    return this.http.post<Account>(`${this.apiUrl}/create`, account);
  }
}
