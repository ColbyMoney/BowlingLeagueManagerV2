import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { SignupService } from '../../services/signup/signup.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [ReactiveFormsModule, MatInputModule, MatButtonModule],
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent {
  accountForm = new FormGroup({
    firstName: new FormControl(""),
    lastName: new FormControl(""),
    emailAddress: new FormControl(""),
    username: new FormControl(""),
    password: new FormControl("")
  })

  constructor(
    private signupService: SignupService,
    private router: Router
  ) {}

  public createAccount(): void {
    const firstName = this.accountForm.get('firstName')?.value ?? '';
    const lastName = this.accountForm.get('lastName')?.value ?? '';
    const emailAddress = this.accountForm.get('emailAddress')?.value ?? '';
    const username = this.accountForm.get('username')?.value ?? '';
    const password = this.accountForm.get('password')?.value ?? '';

    // Assuming you have a service to handle authentication
    this.signupService.createAccount(firstName, lastName, emailAddress, username, password).subscribe(
      (response: any) => {
        console.log('Account created successfully. ', response);
        // Handle successful login, e.g., navigate to dashboard, store token, etc.
      },
      (error: HttpErrorResponse) => {
        console.error('Unable to create account. ', error.message);
        // Handle login error, e.g., display error message

      }
    );
  }

}
