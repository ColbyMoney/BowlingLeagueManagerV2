import { Component } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { LoginService } from '../../services/login/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule, MatInputModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm = new FormGroup({
    username: new FormControl(""),
    password: new FormControl("")
  });

  constructor(
    private loginService: LoginService,
    private router: Router
  ) {}


  public login(): void {
    const username = this.loginForm.get('username')?.value ?? '';
    const password = this.loginForm.get('password')?.value ?? '';

    // Assuming you have a service to handle authentication
    this.loginService.login(username, password).subscribe(
      (response: any) => {
        console.log('Login successful: ', response);
        // Handle successful login, e.g., navigate to dashboard, store token, etc.
        this.router.navigate(['/homepage'])
      },
      (error: HttpErrorResponse) => {
        console.error('Login failed: ', error.message);
        // Handle login error, e.g., display error message

      }
    );
  }

public navigateToSignUp() {
  this.router.navigate(["/signup"]);
}

}
