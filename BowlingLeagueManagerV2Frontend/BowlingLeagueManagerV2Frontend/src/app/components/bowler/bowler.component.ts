import { Component } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { Bowler } from '../../models/bowler';
import { BowlerService } from '../../services/bowler/bowler.service';
import { NgFor } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-bowler',
  standalone: true,
  imports: [NgFor, ReactiveFormsModule, MatInputModule, MatButtonModule],
  templateUrl: './bowler.component.html',
  styleUrl: './bowler.component.css'
})
export class BowlerComponent {

  public bowlers : Bowler[] = [];
  public bowler : Bowler = {bowlerId: -1, firstName: "", lastName: "", bowlerImage: "", bowlerImageAltText: ""};

  constructor(private bowlerService: BowlerService){}

  bowlerForm  = new FormGroup({
    firstName: new FormControl(""),
    lastName: new FormControl(""),
    bowlerImage: new FormControl(""),
    bowlerImageAltText: new FormControl(""),
  });

  public getAllBowlers(): void {
    this.bowlerService.getAllBowlers().subscribe(
      (response: Bowler[]) => {
        this.bowlers = response;
        console.log(this.bowlers);
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }

  public getBowlerById(bowlerId: number): void {
    this.bowlerService.getBowlerById(bowlerId).subscribe(
      (response: Bowler) => {
        this.bowler = response;
        console.log(this.bowler);
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );
  }

  public createBowler(): void {
    this.bowlerService.createBowler(
      this.bowlerForm.value.firstName ?? '',
      this.bowlerForm.value.lastName ?? '',
      this.bowlerForm.value.bowlerImage ?? '',
      this.bowlerForm.value.bowlerImageAltText ?? ''
    ).subscribe(
      (response: Bowler) => {
        console.log(response);
      },
      (error: HttpErrorResponse) => {
        alert(error.message);
      }
    );

  }

  public updateBowler(): void {

  }

  public deleteBowler(): void {

  }
}
